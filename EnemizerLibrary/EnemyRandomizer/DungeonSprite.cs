﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemizerLibrary
{
    public class DungeonSprite
    {
        public byte byte0 { get; set; }
        public byte byte1 { get; set; }

        public byte spriteId;
        public byte SpriteId
        {
            get
            {
                return spriteId;
            }
            set
            {
                spriteId = value;
                IsOverlord = false;
            }
        }

        public int Address { get; set; }
        public bool IsOverlord { get; set; }
        public bool HasAKey { get; set; }
        public string SpriteName
        {
            get
            {
                return SpriteConstants.GetSpriteName(SpriteId);
            }
        }

        RomData romData;

        public DungeonSprite(RomData romData, int address)
        {
            this.romData = romData;
            this.Address = address;

            byte0 = romData[address];
            byte1 = romData[address + 1];
            SpriteId = romData[address + 2];

            IsOverlord = (byte1 & SpriteConstants.StatisMask) != 0;

            if (romData[address + 3] != 0xFF && (romData[address + 5] == SpriteConstants.KeySprite || romData[address + 5] == SpriteConstants.BigKeySprite))
            {
                HasAKey = true;
            }
        }

        public void UpdateRom()
        {
            if (spriteId == 3 && IsOverlord == false)
            {
                throw new Exception("SpriteID 3 will crash the game");
            }

            if (IsOverlord == false)
            {
                romData[Address + 1] = (byte)(romData[Address + 1] & SpriteConstants.OverlordRemoveMask);
            }
            romData[Address + 2] = spriteId;
        }
    }
}
