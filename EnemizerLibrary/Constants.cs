﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemizerLibrary
{
    // TODO: replace with enums that which can be replaced with enums

    public class ItemConstants
    {
        public static readonly byte Nothing = 0xFF,
            Arrow_1 = 0x43,
            Rupee_1 = 0x34,
            Bombs_3 = 0x28,
            Rupee_5 = 0x35,
            Arrow_10 = 0x44,
            Bomb_10 = 0x31,
            Rupee_20 = 0x36,
            Rupee_20_2 = 0x47,
            Rupee_50 = 0x41,
            Rupee_100 = 0x40,
            Rupee_300 = 0x46,
            Bee_NoBottle = 0x0E,
            BigKey = 0x32,
            BlueMail = 0x22,
            FighterShield = 0x04,
            BluePotion_NoBottle = 0x30,
            BookOfMudora = 0x1D,
            BlueBoomerang = 0x0C,
            Bombos = 0x0F,
            Bomb = 0x27,
            Bottle = 0x16,
            Bottle_RedPotion = 0x2B,
            Bottle_GreenPotion = 0x2C,
            Bottle_BluePotion = 0x2D,
            Bottle_Bee = 0x3C,
            Bottle_Fairy = 0x3D,
            Bottle_GoldBee = 0x48,
            BowAndArrows = 0x3A,
            BowAndSilverArrows = 0x3B,
            Bow = 0x0B,
            BugNet = 0x21,
            CaneOfSomaria = 0x15,
            CaneOfByrna = 0x18,
            Compass = 0x25,
            Crystal_WILL_CRASH_GAME = 0x20,
            Ether = 0x10,
            Flippers = 0x1E,
            GreenPotion_NoBottle = 0x2F,
            Hammer = 0x09,
            HeartContainer_NoDialog = 0x26,
            SanctuaryHeart = 0x3F,
            Heart = 0x42,
            BossHeart = 0x3E,
            Hookshot = 0x0A,
            FireRod = 0x07,
            IceRod = 0x08,
            Key = 0x24,
            L1SwordAndShield = 0x00,
            L1Sword = 0x49,
            L2Sword = 0x50,
            L3Sword = 0x02,
            L4Sword = 0x03,
            Lamp = 0x12,
            MagicCape = 0x19,
            MagicMirror = 0x1A,
            Map = 0x33,
            MirrorShield = 0x06,
            Mushroom = 0x29,
            MoonPearl = 0x1F,
            OcarinaActive = 0x4A,
            OcarinaInactive = 0x14,
            PegasusBoots = 0x4B,
            PieceOfHeart = 0x17,
            PendantOfCourage = 0x37,
            PendantOfWisdom = 0x38,
            PendantOfPower = 0x39,
            Powder = 0x0D,
            PowerGloves = 0x1B,
            Quake = 0x11,
            FireShield = 0x05,
            RedBoomerang = 0x2A,
            RedMail = 0x23,
            RedPotion_NoBottle = 0x2E,
            Shovel = 0x13,
            SmallMagic = 0x45,
            TitansMitt = 0x1C,
            MaxBombs = 0x4C,
            MaxArrows = 0x4D,
            HalfMagic = 0x4E,
            QuarterMagic = 0x4F,
            MaxBombs_5 = 0x51,
            MaxBombs_10 = 0x52,
            MaxArrows_5 = 0x53,
            MaxArrows_10 = 0x54,
            Trap1 = 0x55,
            Trap2 = 0x56,
            Trap3 = 0x57,
            SilverArrows = 0x58,
            Rupoor = 0x59,
            NullItem = 0x5A, // ??
            RedClock = 0x5B,
            BlueClock = 0x5C,
            GreenClock = 0x5D,
            ProgressiveSword = 0x5E,
            ProgressiveShield = 0x5F,
            ProgressiveArmor = 0x60,
            ProgressiveLiftingGlove = 0x61,
            RNGPoolItem_Single = 0x62,
            RNGPoolItem_Multi = 0x63,
            GoalItem_Single_Triforce = 0x6A,
            GoalItem_Multi_PowerStar = 0x6B,
            Maps = 0x70,
            Compasses = 0x80,
            BigKeys = 0x90, // not sure what this is compared to big key
            SmallKeys = 0xA0;

        public static IEnumerable<byte> ImportantItems = new byte[]
        {
            ItemConstants.BigKey,
            ItemConstants.BookOfMudora,
            ItemConstants.Bottle,
            ItemConstants.Bottle_RedPotion,
            ItemConstants.Bottle_GreenPotion,
            ItemConstants.Bottle_BluePotion,
            ItemConstants.Bottle_Bee,
            ItemConstants.Bottle_Fairy,
            ItemConstants.Bottle_GoldBee,
            ItemConstants.BowAndArrows,
            ItemConstants.BowAndSilverArrows,
            ItemConstants.Bow,
            ItemConstants.CaneOfSomaria,
            ItemConstants.CaneOfByrna,
            ItemConstants.Bombos,
            ItemConstants.Ether,
            ItemConstants.Quake,
            ItemConstants.FireRod,
            ItemConstants.IceRod,
            ItemConstants.Flippers,
            ItemConstants.Hammer,
            ItemConstants.Hookshot,
            ItemConstants.Key,
            ItemConstants.Lamp,
            ItemConstants.MagicCape,
            ItemConstants.MagicMirror,
            ItemConstants.Mushroom,
            ItemConstants.MoonPearl,
            ItemConstants.OcarinaInactive,
            ItemConstants.PegasusBoots,
            ItemConstants.Powder,
            ItemConstants.PowerGloves,
            ItemConstants.Shovel,
            ItemConstants.TitansMitt,
            ItemConstants.ProgressiveSword,
            ItemConstants.ProgressiveLiftingGlove
        };

        public static int
            MasterSwordPedestalAddress = 0x289B0;
    }

    public class BossConstants
    {
        public static byte
            KholdstareGraphics = 22,
            MoldormGraphics = 12,
            MothulaGraphics = 26,
            VitreousGraphics = 22,
            HelmasaurGraphics = 21,
            ArmosGraphics = 9,
            LanmolaGraphics = 11,
            BlindGraphics = 32,
            ArrghusGraphics = 20,
            TrinexxGraphics = 23;

        public static byte[] BossGraphics = 
        {
            KholdstareGraphics, MoldormGraphics, MothulaGraphics, VitreousGraphics,
            HelmasaurGraphics, ArmosGraphics, LanmolaGraphics, BlindGraphics, ArmosGraphics, TrinexxGraphics
        };

        public static string
            KholdstareName = "Kholdstare",
            MoldormName = "Moldorm",
            MothulaName = "Mothula",
            VitreousName = "Vitreous",
            HelmasaurName = "Helmasaur King",
            ArmosName = "Armos Knights",
            LanmolaName = "Lanmola",
            BlindName = "Blind",
            ArrghusName = "Arrghus",
            TrinexxName = "Trinexx";

        public static string[] BossNames =
        {
            KholdstareName, MoldormName, MothulaName, VitreousName, HelmasaurName,
            ArmosName, LanmolaName, BlindName, ArrghusName, TrinexxName
        };

        public static int
            TowerOfHeraBossDropItemAddress = 0x180152,
            EasternPalaceBossDropItemAddress = 0x180150,
            SkullWoodsBossDropItemAddress = 0x180155,
            DesertPalaceBossDropItemAddress = 0x180151,
            PalaceOfDarknessBossDropItemAddress = 0x180153,
            MyseryMireBossDropItemAddress = 0x180158,
            ThievesTownBossDropItemAddress = 0x180156,
            SwampPalaceBossDropItemAddress = 0x180154,
            IcePalaceBossDropItemAddress = 0x180157,
            TurtleRockBossDropItemAddress = 0x180159,
            GanonTower1BossDropItemAddress = 0x0,
            GanonTower2BossDropItemAddress = 0x0,
            GanonTower3BossDropItemAddress = 0x0;

        public static int[] BossDropItemAddresses =  
        {
            TowerOfHeraBossDropItemAddress,
            EasternPalaceBossDropItemAddress,
            SkullWoodsBossDropItemAddress,
            DesertPalaceBossDropItemAddress,
            PalaceOfDarknessBossDropItemAddress,
            MyseryMireBossDropItemAddress,
            ThievesTownBossDropItemAddress,
            SwampPalaceBossDropItemAddress,
            IcePalaceBossDropItemAddress,
            TurtleRockBossDropItemAddress,
            GanonTower1BossDropItemAddress,
            GanonTower2BossDropItemAddress,
            GanonTower3BossDropItemAddress
        };

        public static byte[] 
            KholdstarePointer = { 0x01, 0xEA },
            MoldormPointer = { 0xC3, 0xD9 },
            MothulaPointer = { 0x31, 0xDC },
            VitreousPointer = { 0x57, 0xE4 },
            HelmasaurPointer = { 0x49, 0xE0 },
            ArmosPointer = { 0x87, 0xE8 },
            LanmolaPointer = { 0xCB, 0xDC },
            BlindPointer = { 0x54, 0xE6 },
            ArrghusPointer = { 0x97, 0xD9 },
            TrinexxPointer = { 0xBA, 0xE5 };

        public static byte[][] BossPointers =
        {
            KholdstarePointer,
            MoldormPointer,
            MothulaPointer,
            VitreousPointer,
            HelmasaurPointer,
            ArmosPointer,
            LanmolaPointer,
            BlindPointer,
            ArrghusPointer,
            TrinexxPointer
        };
    }

    public class CrystalConstants
    {
        public static int CrystalTypeBaseAddress = 0x180052;
        public static int
            TowerOfHeraOffset = 8,
            EasternPalaceOffset = 0,
            SkullWoodsOffset = 6,
            DesertPalaceOffset = 1,
            PalaceOfDarknessOffset = 4,
            MyseryMireOffset = 5,
            ThievesTownOffset = 9,
            SwampPalaceOffset = 3,
            IcePalaceOffset = 7,
            TurtleRockOffset = 10;

        public static int[] CrystalTypeAddresses =
        {
            CrystalTypeBaseAddress + TowerOfHeraOffset,
            CrystalTypeBaseAddress + EasternPalaceOffset,
            CrystalTypeBaseAddress + SkullWoodsOffset,
            CrystalTypeBaseAddress + DesertPalaceOffset,
            CrystalTypeBaseAddress + PalaceOfDarknessOffset,
            CrystalTypeBaseAddress + MyseryMireOffset,
            CrystalTypeBaseAddress + ThievesTownOffset,
            CrystalTypeBaseAddress + SwampPalaceOffset,
            CrystalTypeBaseAddress + IcePalaceOffset,
            CrystalTypeBaseAddress + TurtleRockOffset,
            0, 0, 0 // Ganon Tower
        };


        public static int CrystalBaseAddress = 0x1209D;
        public static int[] CrystalAddresses = 
        {
            CrystalBaseAddress + TowerOfHeraOffset,
            CrystalBaseAddress + EasternPalaceOffset,
            CrystalBaseAddress + SkullWoodsOffset,
            CrystalBaseAddress + DesertPalaceOffset,
            CrystalBaseAddress + PalaceOfDarknessOffset,
            CrystalBaseAddress + MyseryMireOffset,
            CrystalBaseAddress + ThievesTownOffset,
            CrystalBaseAddress + SwampPalaceOffset,
            CrystalBaseAddress + IcePalaceOffset,
            CrystalBaseAddress + TurtleRockOffset,
            0, 0, 0 // Ganon Tower
        };
    }
}