﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace EnemizerLibrary
{
    public class Room
    {

        public string RoomName
        {
            get
            {
                return RoomIdConstants.GetRoomName(RoomId);
            }
        }
        public int RoomId { get; set; }
        public int GraphicsBlockId { get; set; }
        public bool IsShutterRoom
        {
            get
            {
                return RoomIdConstants.NeedKillable_doors.Contains(RoomId);
            }
        }
        public bool IsWaterRoom
        {
            get
            {
                return RoomIdConstants.WaterRoom.Contains(RoomId);
            }
        }

        public List<DungeonSprite> Sprites { get; set; } = new List<DungeonSprite>();
        //public List<RoomRequirement> Requirements { get; set; }

        int RoomHeaderBaseAddress
        {
            get
            {
                byte[] snesBytes = new byte[3];
                snesBytes[0] = romData[AddressConstants.dungeonHeaderPointerTableBaseAddress + (RoomId * 2)];
                snesBytes[1] = romData[AddressConstants.dungeonHeaderPointerTableBaseAddress + (RoomId * 2) + 1];
                snesBytes[2] = romData[XkasSymbols.Instance.Symbols["moved_room_header_bank_value_address"]]; // AddressConstants.MovedRoomBank;

                int pcAddress = Utilities.SnesToPCAddress(Utilities.SnesByteArrayTo24bitSnesAddress(snesBytes));

                return pcAddress;
            }
        }

        public SpriteGroup SpriteGroup
        {
            get
            {
                return spriteGroupCollection.SpriteGroups.First(x => x.DungeonGroupId == this.GraphicsBlockId);
            }
        }

        public bool AllSpritesValid
        {
            get
            {
                var ret = true;
                foreach (var s in this.Sprites)
                {
                    var sr = spriteRequirementCollection.SpriteRequirements.Where(x => x.SpriteId == s.SpriteId).FirstOrDefault();
                    if (sr == null)
                    {
                        //Debugger.Break();
                        //return false;
                        continue;
                    }

                    if (!(sr.SubGroup0.Count == 0 || sr.SubGroup0.Contains((byte)this.SpriteGroup.SubGroup0)))
                    {
                        //Debugger.Break();
                        return false;
                    }
                    if (!(sr.SubGroup1.Count == 0 || sr.SubGroup1.Contains((byte)this.SpriteGroup.SubGroup1)))
                    {
                        //Debugger.Break();
                        return false;
                    }
                    if (!(sr.SubGroup2.Count == 0 || sr.SubGroup2.Contains((byte)this.SpriteGroup.SubGroup2)))
                    {
                        //Debugger.Break();
                        return false;
                    }
                    if (!(sr.SubGroup3.Count == 0 || sr.SubGroup3.Contains((byte)this.SpriteGroup.SubGroup3)))
                    {
                        //Debugger.Break();
                        return false;
                    }
                }

                return ret;
            }
        }

        RomData romData { get; set; }
        SpriteGroupCollection spriteGroupCollection;
        SpriteRequirementCollection spriteRequirementCollection;

        public Room(int roomId, RomData romData, SpriteGroupCollection spriteGroupCollection, SpriteRequirementCollection spriteRequirementCollection)
        {
            this.RoomId = roomId;
            this.romData = romData;
            this.spriteGroupCollection = spriteGroupCollection;
            this.spriteRequirementCollection = spriteRequirementCollection;
        }

        public void LoadRoom()
        {
            LoadHeader();

            LoadSprites();
        }

        public void UpdateRom()
        {
            UpdateHeader();

            UpdateSprites();
        }

        private void UpdateSprites()
        {
            foreach(var s in Sprites)
            {
                s.UpdateRom();

                //if(s.SpriteId == 3 && s.IsOverlord == false)
                //{
                //    throw new Exception("SpriteID 3 will crash the game");
                //}

                //if (s.IsOverlord == false)
                //{
                //    romData[s.Address + 1] = (byte)(romData[s.Address + 1] & SpriteConstants.OverlordRemoveMask);
                //}
                //romData[s.Address + 2] = s.SpriteId;
            }
        }

        private void UpdateHeader()
        {
            romData[RoomHeaderBaseAddress + 3] = (byte)(this.GraphicsBlockId);
        }

        void LoadHeader()
        {
            this.GraphicsBlockId = romData[RoomHeaderBaseAddress + 3];
        }

        void LoadSprites()
        {
            int spriteTableBaseSnesAddress = (09 << 16) // bank 9
                + (romData[AddressConstants.dungeonSpritePointerTableBaseAddress + (RoomId * 2) + 1] << 8)
                + (romData[AddressConstants.dungeonSpritePointerTableBaseAddress + (RoomId * 2)]);
            int roomSpriteBaseAddress = Utilities.SnesToPCAddress(spriteTableBaseSnesAddress);

            /*
            Byte 0: Stored to $0FB3. Corresponds with "Sort Spr" in Hyrule Magic. In a layered room this indicates sprites in the foreground are to be drawn on top of sprites in the background.

            Bit 0 - If 0, sprites will sort
            Bits 7,6,5,4,3,2,1 - Unknown, should all be 1
            */
            //byte byte0 = romData[roomSpriteBaseAddress];

            int i = 1; // skip byte0

            while(romData[roomSpriteBaseAddress + i] != 0xFF)
            {
                Sprites.Add(new DungeonSprite(romData, roomSpriteBaseAddress + i));
                i += 3; // sprites are 3 byte chunks
            }
        }

        public void RandomizeSprites(Random rand, OptionFlags optionFlags, SpriteGroupCollection spriteGroupCollection, SpriteRequirementCollection spriteRequirementCollection)
        {
            SpriteGroup spriteGroup = null;
            int[] possibleSprites = new int[0];

            spriteGroup = spriteGroupCollection.SpriteGroups.First(x => x.DungeonGroupId == this.GraphicsBlockId);

            possibleSprites = spriteGroup.GetPossibleEnemySprites(this, optionFlags).Select(x => x.SpriteId).ToArray();

            if (possibleSprites.Length > 0)
            {
                var spritesToUpdate = this.Sprites.Where(x => spriteRequirementCollection.RandomizableSprites.Select(y => y.SpriteId).Contains(x.SpriteId))
                    .ToList();

                // TODO: something less hacky for shutters.
                var keySprites = spritesToUpdate.Where(x => x.HasAKey).ToList();
                var shutterSprites = spritesToUpdate.Where(x => this.IsShutterRoom && !x.HasAKey).ToList();

                var killableSprites = spriteRequirementCollection.KillableSprites.Where(x => possibleSprites.Contains(x.SpriteId)).Select(x => x.SpriteId).ToList();
                var killableKeySprites = spriteRequirementCollection.KillableSprites.Where(x => x.CannotHaveKey == false && possibleSprites.Contains(x.SpriteId)).Select(x => x.SpriteId).ToList();
                var waterSprites = spriteRequirementCollection.WaterSprites.Where(x => possibleSprites.Contains(x.SpriteId)).Select(x => x.SpriteId).ToList();

                if (keySprites.Count > 0 && killableKeySprites.Count == 0)
                {
                    throw new Exception("Key in room without any killable enemies");
                }
                if (shutterSprites.Count > 0 && killableSprites.Count == 0)
                {
                    throw new Exception("Shutter room without any killable enemies");
                }
                if(this.IsWaterRoom && waterSprites.Count == 0)
                {
                    throw new Exception("Water room without any water sprites");
                }

                Debug.Assert(possibleSprites.Contains(SpriteConstants.EmptySprite) == false);
                Debug.Assert(killableSprites.Contains(SpriteConstants.EmptySprite) == false);
                Debug.Assert(killableKeySprites.Contains(SpriteConstants.EmptySprite) == false);
                Debug.Assert(waterSprites.Contains(SpriteConstants.EmptySprite) == false);

                int[] possibleAbsorbableSprites = GetAbsorbableSprites(spriteRequirementCollection, optionFlags);
                int stalCount = 0;

                if (this.IsWaterRoom)
                {
                    spritesToUpdate.ToList()
                        .ForEach(x => x.SpriteId = waterSprites[rand.Next(waterSprites.Count)]);

                    return;
                }
                else
                {
                    // remove water sprites
                    possibleSprites = possibleSprites.Where(x => waterSprites.Contains(x) == false).ToArray();
                }

                foreach (var s in spritesToUpdate.Where(x => x.HasAKey == false).ToList())
                {
                    int spriteId = -1;

                    if (optionFlags.EnemiesAbsorbable && optionFlags.AbsorbableSpawnRate > 0 && optionFlags.AbsorbableTypes.Where(x => x.Value).Count() > 0)
                    {
                        if (rand.Next(0, 100) <= optionFlags.AbsorbableSpawnRate)
                        {
                            spriteId = possibleAbsorbableSprites[rand.Next(possibleAbsorbableSprites.Length)];
                        }
                        else
                        {
                            if (rand.Next(0, 100) <= 5)
                            {
                                //spawn a stal
                                spriteId = SpriteConstants.StalSprite;
                            }
                            else
                            {
                                spriteId = possibleSprites[rand.Next(possibleSprites.Length)];
                            }
                        }
                    }
                    else
                    {
                        if (rand.Next(0, 100) <= 5)
                        {
                            //spawn a stal
                            spriteId = SpriteConstants.StalSprite;
                        }
                        else
                        {
                            spriteId = possibleSprites[rand.Next(possibleSprites.Length)];
                        }
                    }

                    s.SpriteId = spriteId;

                    // leave this out for now
                    
                    if(spriteId == SpriteConstants.StalSprite)
                    {
                        stalCount++;
                        if (stalCount > 2)// && possibleSprites.Count() > 1) // max 2 in a room
                        {
                            possibleSprites = possibleSprites.Where(x => x != SpriteConstants.StalSprite).ToArray();
                        }
                    }
                    //*/
                }

                spritesToUpdate.Where(x => x.HasAKey).ToList()
                    .ForEach(x => x.SpriteId = killableKeySprites[rand.Next(killableKeySprites.Count)]);

                // TODO: something less hacky for shutters.
                spritesToUpdate.Where(x => !x.HasAKey && this.IsShutterRoom).ToList()
                    .ForEach(x => x.SpriteId = killableSprites[rand.Next(killableSprites.Count)]);
            }
            else if (!RoomIdConstants.BossRooms.Contains(this.RoomId))
            {
                // TODO: log this because it's not a boss room
                Console.WriteLine($"Skipped randomizing sprites in room {this.RoomId}");
            }
        }

        public void RandomizePotSprites(Random rand, SpriteGroupCollection spriteGroupCollection, SpriteRequirementCollection spriteRequirementCollection)
        {
            var spriteGroup = spriteGroupCollection.SpriteGroups.First(x => x.DungeonGroupId == this.GraphicsBlockId);

            var possibleSprites = spriteGroup.GetPossibleEnemySprites(this).Where(x => x.Overlord == false).Select(x => x.SpriteId).ToArray();

            if(possibleSprites.Length > 0)
            {
                romData[SpriteConstants.RandomizedPotEnemyTableBaseAddress + this.RoomId] = (byte)possibleSprites[rand.Next(possibleSprites.Length)];
            }
        }

        public int[] GetAbsorbableSprites(SpriteRequirementCollection spriteRequirementCollection, OptionFlags optionFlags)
        {
            var absorbables = spriteRequirementCollection.SpriteRequirements
                                    .Where(x => x.Absorbable == true)
                                    .Where(x => optionFlags.AbsorbableTypes
                                                            .Where(y => y.Value)
                                                            .Select(y => (int)y.Key + 0xD8)
                                                            .Contains(x.SpriteId)
                                            )
                                    .Select(x => x.SpriteId)
                                    .ToArray();

            return absorbables;
        }
    }
}
