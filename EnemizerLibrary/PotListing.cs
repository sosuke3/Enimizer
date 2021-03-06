﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnemizerLibrary
{
    /*
    0x0 = "Nothing",
    0x1 = "Rupee",
    0x2 = "RockCrab",
    0x3 = "Bee",
    0x4 = "Random",
    0x5 = "Bomb",
    0x6 = "Heart",
    0x7 = "Blue Rupee",
    0x8 = "Key",
    0x9 = "Arrow",
    0xA = "Bomb",
    0xB = "Heart",
    0xC = "Magic",
    0xD = "Big Magic",
    0xE = "Chicken",
    0xF = "Green Soldier",
    0x10 = "AliveRock?",
    0x11 = "Blue Soldier",
    0x12 = "Ground Bomb",
    0x13 = "Heart",
    0x14 = "Fairy",
    0x15 = "Heart",
    //? = "Nothing",
    0x80 = "Hole",
    0x82 = "Warp",
    0x84 = "Staircase",
    0x86 = "Bombable",
    0x88 = "Switch"

    if ((room.items[i].id & 0x80) == 0x80)
    {
        nid = (byte)(((room.items[i].id - 0x80) / 2) + 0x17);
    }
    */
    public partial class Randomization
    {
        public static GameRoom[] roomList = new GameRoom[]{
        //Game Rooom 4
        new GameRoom(4,new EmptyPot[]{ new EmptyPot(0xA2,0x19),new EmptyPot(0x98,0x19),new EmptyPot(0x98,0x16),
        new EmptyPot(0xA2,0x16),new EmptyPot(0xF0,0x13),new EmptyPot(0xCC,0x13)},new byte[]{0x0A,0x0A}),
        //Game Room 9
        new GameRoom(9,new EmptyPot[]{
        new EmptyPot(0x0C,0x04),new EmptyPot(0x30,0x04),new EmptyPot(0x0C,0x0C)},new byte[]{0x01,0x0B,0x88}),
        //Game Room 10
        new GameRoom(10,new EmptyPot[]{new EmptyPot(0xCC,0x0B),new EmptyPot(0x9C,0x11),new EmptyPot(0x60,0x08),
        new EmptyPot(0x64,0x07),new EmptyPot(0xA0,0x11),new EmptyPot(0x68,0x08),new EmptyPot(0x64,0x09)},
        new byte[]{0x0B,0x0B,0x88}),
        //Game Room 17
        new GameRoom(17,new EmptyPot[]{new EmptyPot(0x98,0x13),new EmptyPot(0x98,0x0F),new EmptyPot(0x90,0x0F),
        new EmptyPot(0x0A,0x0F),new EmptyPot(0x90,0x13),new EmptyPot(0xA0,0x13) },new byte[]{0x0B,0x0B,0x0B,0x0B}),
        //Game Room 21
        new GameRoom(21,new EmptyPot[]{new EmptyPot(0x60,0x04),new EmptyPot(0x64,0x04),new EmptyPot(0x68,0x04),
        new EmptyPot(0x6C,0x04),new EmptyPot(0x70,0x04),new EmptyPot(0x0C,0x06),new EmptyPot(0x10,0x06),
        new EmptyPot(0x14,0x06),new EmptyPot(0x46,0x0B),},new byte[]{0x01,0x07,0x09,0x09,0x0A,0x0B,0x0C,0x0C,0x0D}),
        //Game Room 22
        new GameRoom(22,new EmptyPot[]{new EmptyPot(0xBC,0x03),new EmptyPot(0xC0,0x03),new EmptyPot(0xBC,0x04),
        new EmptyPot(0xC0,0x04),new EmptyPot(0xBC,0x05),new EmptyPot(0xC0,0x05),new EmptyPot(0xBC,0x06),
        new EmptyPot(0xC0,0x06),new EmptyPot(0xF0,0x13),},new byte[]{0x08,0x09,0x09,0x0A,0x0A,0x0B,0x0B,0x0C,0x0C}),
        //Game Room 26
        new GameRoom(26,new EmptyPot[]{new EmptyPot(0xE8,0x13),new EmptyPot(0xD4,0x13),new EmptyPot(0x1C,0x05),
        new EmptyPot(0x20,0x05),new EmptyPot(0x1C,0x1B),new EmptyPot(0x20,0x1B),},new byte[]{0x0A,0x0A,0x0A,0x0A}),
        //Game Room 33
        new GameRoom(33,new EmptyPot[]{new EmptyPot(0x64,0x1C),new EmptyPot(0xA8,0x18),new EmptyPot(0x30,0x1C),
        new EmptyPot(0x52,0x1C),new EmptyPot(0xA0,0x14),new EmptyPot(0x68,0x1C),},new byte[]{0x0B,0x0C,0x0C}),
        //Game Room 35
        new GameRoom(35,new EmptyPot[]{new EmptyPot(0x56,0x1A),new EmptyPot(0x5A,0x1A),new EmptyPot(0x5E,0x1A),
        new EmptyPot(0x62,0x1A),new EmptyPot(0x66,0x1A),},new byte[]{0x01,0x0A,0x0B}),
        //Game Room 36
        new GameRoom(36,new EmptyPot[]{new EmptyPot(0x0C,0x04),new EmptyPot(0x30,0x04),new EmptyPot(0x0C,0x0C),
        new EmptyPot(0x30,0x0C),},new byte[]{0x01,0x0B,0x0C,0x07}),
        //Game Room
        new GameRoom(38,new EmptyPot[]{new EmptyPot(0x1C,0x04),new EmptyPot(0x0C,0x08),new EmptyPot(0x96,0x13,2),
        new EmptyPot(0x16,0x1A,2),new EmptyPot(0xDC,0x1A), },new byte[]{0x07,0x09,0x0A,0x0C,0x88}),
        //Game Room 39
        new GameRoom(39,new EmptyPot[]{new EmptyPot(0xD6,0x13),new EmptyPot(0xD6,0x14),new EmptyPot(0xA6,0x14),
        new EmptyPot(0xD6,0x15),new EmptyPot(0x28,0x1C),new EmptyPot(0x2C,0x1C),new EmptyPot(0x50,0x1C),
        new EmptyPot(0x54,0x1C),new EmptyPot(0x66,0x11),new EmptyPot(0x62,0x11),new EmptyPot(0x6A,0x11),
        new EmptyPot(0xA6,0x15),new EmptyPot(0xA6,0x13),new EmptyPot(0x5C,0x0C),new EmptyPot(0xA0,0x0C),},
        new byte[]{0x01,0x01,0x0A,0x0B,0x07,0x07}),
        //Game Room 43
        new GameRoom(43,new EmptyPot[]{new EmptyPot(0x10,0x05,2),new EmptyPot(0x2C,0x05,2),new EmptyPot(0x10,0x06,2),
        new EmptyPot(0x2C,0x06,2),new EmptyPot(0x10,0x07,2),new EmptyPot(0x2C,0x07,2),new EmptyPot(0x92,0x15),
        new EmptyPot(0xAA,0x15),new EmptyPot(0x92,0x16),new EmptyPot(0xAA,0x16),},
        new byte[]{0x09,0x09,0x0A,0x0A,0x0A,0x0A,0x0B,0x0B,0x0B,0x88}),
        //Game Room 47
        new GameRoom(47,new EmptyPot[]{new EmptyPot(0x1C,0x07),new EmptyPot(0x20,0x07),new EmptyPot(0x1C,0x09),
        new EmptyPot(0x20,0x09),new EmptyPot(0xAC,0x13),new EmptyPot(0xB4,0x13),new EmptyPot(0x68,0x1B),
        new EmptyPot(0x68,0x1C),},new byte[]{0x07,0x07,0x07,0x07,0x0B,0x0B,0x0B,0x0B}),
        //Game Room 53

        new GameRoom(53,new EmptyPot[]{new EmptyPot(0x3C,0x06,1),new EmptyPot(0x14,0x08),new EmptyPot(0x18,0x08),
        new EmptyPot(0x1C,0x08),new EmptyPot(0x20,0x08),new EmptyPot(0x24,0x08),new EmptyPot(0x30,0x14),
        new EmptyPot(0x4C,0x17,1),new EmptyPot(0x58,0x17,1),new EmptyPot(0x64,0x1B,1),new EmptyPot(0xF2,0x1C,1),
        new EmptyPot(0xF0,0x16,1),new EmptyPot(0x4C,0x1C,1),},new byte[]{0x07,0x07,0x07,0x07,0x07,0x08,0x0B}),
        //Game Room 54
        new GameRoom(54,new EmptyPot[]{
        new EmptyPot(0x6C,0x04),
        new EmptyPot(0x70,0x04),
        new EmptyPot(0x0A,0x10),
        new EmptyPot(0x72,0x10),},new byte[]{0x08,0x0A,0x0B}),
        //Game Room 55
        new GameRoom(55,new EmptyPot[]{new EmptyPot(0x30,0x14),new EmptyPot(0x3C,0x06),},new byte[]{0x08}),
        //Game Room 56
        new GameRoom(56,new EmptyPot[]{new EmptyPot(0xA4,0x0C),new EmptyPot(0xA4,0x0D),new EmptyPot(0xA4,0x12),
        new EmptyPot(0xA4,0x13), },new byte[]{0x08,0x07,0x0A,0x0A}),
        //Game Room 57
        new GameRoom(57,new EmptyPot[]{new EmptyPot(0x0C,0x14),new EmptyPot(0x64,0x16),new EmptyPot(0x64,0x1A),
        new EmptyPot(0x30,0x1C),},new byte[]{0x09,0x09,0x0B,0x0C}),
        //Game Room 60
        new GameRoom(60,new EmptyPot[]{new EmptyPot(0x18,0x08),new EmptyPot(0x40,0x0C),new EmptyPot(0x14,0x0E),
        new EmptyPot(0x44,0x12),new EmptyPot(0x60,0x13),new EmptyPot(0x40,0x14),new EmptyPot(0x40,0x1A),},
        new byte[]{0x01,0x07,0x07,0x07,0x07,0x0B,0x0C}),
        //Game Room 61
        new GameRoom(61,new EmptyPot[]{new EmptyPot(0x4C,0x0C),new EmptyPot(0x70,0x0C),new EmptyPot(0x18,0x16),
        new EmptyPot(0x28,0x16),new EmptyPot(0x20,0x18),new EmptyPot(0x14,0x1A),new EmptyPot(0x24,0x1A),},
        new byte[]{0x09,0x07,0x0A,0x0A,0x0B,0x0B,0x0D}),
        //Game Room 62
        new GameRoom(62,new EmptyPot[]{new EmptyPot(0x60,0x06),new EmptyPot(0x64,0x06),new EmptyPot(0x58,0x0A),
        new EmptyPot(0x5C,0x0A),},new byte[]{0x0A,0x0B,0x0C,0x0C}),
        //Game Room 63
        new GameRoom(63,new EmptyPot[]{new EmptyPot(0x0C,0x19),new EmptyPot(0x14,0x19),new EmptyPot(0x0C,0x1A),
        new EmptyPot(0x14,0x1A),new EmptyPot(0x0C,0x1B),new EmptyPot(0x14,0x1B),new EmptyPot(0x1C,0x17),},
        new byte[]{0x01,0x01,0x08,0x0A,0x0A,0x0B,0x88}),
        //Game Room 65
        new GameRoom(65,new EmptyPot[]{new EmptyPot(0x64,0x0A),new EmptyPot(0x34,0x0F),new EmptyPot(0x34,0x10),
        new EmptyPot(0x94,0x16),},new byte[]{0x01,0x0B,0x0C,0x0C}),
        //Game Room 67
        new GameRoom(67,new EmptyPot[]{new EmptyPot(0x70,0x1C,1),new EmptyPot(0x4C,0x1C,1),new EmptyPot(0x4C,0x14,1),
        new EmptyPot(0x42,0x04),new EmptyPot(0x4E,0x04),new EmptyPot(0x42,0x09),new EmptyPot(0x4E,0x09),
        new EmptyPot(0x70,0x14,1), },new byte[]{0x08,0x09,0x0B,0x0B,0x0C}),
        //Game Room 69
        new GameRoom(69,new EmptyPot[]{new EmptyPot(0x0C,0x04),new EmptyPot(0x6C,0x0B),new EmptyPot(0x30,0x0C),
        new EmptyPot(0xDC,0x10),new EmptyPot(0xEC,0x10),},new byte[]{0x09,0x09,0x0B,0x0B,0x0C}),
        //Game Room 73
        new GameRoom(73,new EmptyPot[]{new EmptyPot(0x9C,0x1B),new EmptyPot(0xAC,0x18),new EmptyPot(0xAC,0x17),
        new EmptyPot(0x90,0x14),new EmptyPot(0x68,0x0F),new EmptyPot(0x68,0x10),new EmptyPot(0x90,0x13),
        new EmptyPot(0xAC,0x14),new EmptyPot(0x90,0x1B),new EmptyPot(0xAC,0x1C),new EmptyPot(0xA0,0x1B),},
        new byte[]{0x0B,0x0B,0x0C,0x0C,0x0C,0x0C}),
        ////Game Room 74 - PoD entrance
        //new GameRoom(74, new EmptyPot[] 
        //    {
        //        //new EmptyPot(0x0E, 0x05), // switch
        //        new EmptyPot(0x20, 0x05),
        //        new EmptyPot(0x5C, 0x05),
        //        //new EmptyPot(0x6E, 0x05), // switch

        //        new EmptyPot(0x38, 0x08),
        //        new EmptyPot(0x44, 0x08),

        //        new EmptyPot(0x0E, 0x0B),
        //        new EmptyPot(0x20, 0x0B),
        //        new EmptyPot(0x5C, 0x0B),
        //        new EmptyPot(0x6E, 0x0B),
        //    },
        //    new byte[]
        //    {
        //        0x0B, 0x0B, 0x0A, 0x0A, 0x0A, 0x0A, 0x01, 0x01//, 0x88, 0x88
        //    }
        //),
        //Game Room 78
        new GameRoom(78,new EmptyPot[]{new EmptyPot(0x30,0x0A,2),new EmptyPot(0x8C,0x0B,2),new EmptyPot(0x1C,0x0C,2),
        new EmptyPot(0x70,0x0C),},new byte[]{0x88,0x0B,0x0C}),
        //Game Room 83
        new GameRoom(83,new EmptyPot[]{new EmptyPot(0x5C,0x0B),new EmptyPot(0x60,0x0B),
        new EmptyPot(0x64,0x0B),new EmptyPot(0x68,0x0B),},new byte[]{0x08,0x0B,0x0B,0x0C}),
        //Game Room 84
        new GameRoom(84,new EmptyPot[]{new EmptyPot(0xBA,0x19),new EmptyPot(0xBA,0x1A),new EmptyPot(0xBA,0x1B),
        new EmptyPot(0xBA,0x1C),},new byte[]{0x07,0x0B,0x0B,0x0B}),
        //Game Room 86
        new GameRoom(86,new EmptyPot[]{new EmptyPot(0x64,0x06,1),new EmptyPot(0x60,0x0A,1),new EmptyPot(0x5C,0x0A,1),
        new EmptyPot(0x30,0x14,1),new EmptyPot(0x14,0x06),new EmptyPot(0x28,0x06),new EmptyPot(0x18,0x07),
        new EmptyPot(0x24,0x07),new EmptyPot(0x0C,0x08),new EmptyPot(0x30,0x08),new EmptyPot(0x18,0x09),
        new EmptyPot(0x24,0x09),new EmptyPot(0x14,0x0A),new EmptyPot(0x28,0x0A),new EmptyPot(0x0C,0x14,1),},
        new byte[]{0x07,0x07,0x0B,0x0B,0x08,0x0C,0x0C,0x0C,0x0C,0x0C,0x0C}),
        //Game Room 87
        new GameRoom(87,new EmptyPot[]{new EmptyPot(0x5C,0x07),new EmptyPot(0x0C,0x14,2),new EmptyPot(0x5C,0x17),
        new EmptyPot(0x64,0x17),new EmptyPot(0x54,0x19),new EmptyPot(0x4C,0x1B),new EmptyPot(0x30,0x14,2),
        new EmptyPot(0x1E,0x16,2),},new byte[]{0x07,0x0A,0x0B,0x0C,0x0C,0x0C,0x0D,0x88}),
        //Game Room 88
        new GameRoom(88,new EmptyPot[]{new EmptyPot(0x60,0x09),new EmptyPot(0x5C,0x08),new EmptyPot(0x6C,0x08),
        new EmptyPot(0x6C,0x06),new EmptyPot(0x68,0x05),new EmptyPot(0x5C,0x06),new EmptyPot(0x0C,0x0C),
        new EmptyPot(0x10,0x07),new EmptyPot(0x60,0x05),new EmptyPot(0x64,0x05),new EmptyPot(0x0C,0x07),
        new EmptyPot(0x5C,0x07),new EmptyPot(0x6C,0x07),new EmptyPot(0x10,0x08),new EmptyPot(0x64,0x09),
        new EmptyPot(0x68,0x09),},new byte[]{0x0A,0x0A,0x0B,0x0B,0x0C,0x0C,0x0C,0x0C}),
        //Game Room 91
        new GameRoom(91,new EmptyPot[]{new EmptyPot(0xDA,0x25),new EmptyPot(0xDE,0x25),
        new EmptyPot(0xE2,0x25),},new byte[]{0x88}),
        //Game Room 92
        new GameRoom(92,new EmptyPot[]{new EmptyPot(0xE4,0x19),new EmptyPot(0x68,0x18),new EmptyPot(0xE4,0x16),
        new EmptyPot(0xD8,0x19),new EmptyPot(0x54,0x18),new EmptyPot(0xD8,0x16),new EmptyPot(0x5E,0x16),
        new EmptyPot(0x5E,0x1A),},new byte[]{0x0A,0x0D}),
        //Game Room 93
        new GameRoom(93,new EmptyPot[]{new EmptyPot(0x10,0x05),new EmptyPot(0x2C,0x05),new EmptyPot(0x10,0x0B),
        new EmptyPot(0x2C,0x0B),new EmptyPot(0x0C,0x14),new EmptyPot(0x30,0x14),new EmptyPot(0x0C,0x1C),
        new EmptyPot(0x30,0x1C),},new byte[]{0x01,0x07,0x09,0x09,0x0A,0x0A,0x0A,0x0C}),
        //Game Room 94
        new GameRoom(94,new EmptyPot[]{new EmptyPot(0x5C,0x04),new EmptyPot(0x60,0x04),new EmptyPot(0x4C,0x08),
        new EmptyPot(0x70,0x08),},new byte[]{0x0B,0x0B,0x0C,0x0C}),
        //Game Room 99
        new GameRoom(99,new EmptyPot[]{new EmptyPot(0x30,0x04),new EmptyPot(0x0C,0x04),new EmptyPot(0x0C,0x08),
        new EmptyPot(0x30,0x0C),new EmptyPot(0x30,0x08),new EmptyPot(0x0C,0x0C),},new byte[]{0x08,0x0B}),
        //Game Room 100
        new GameRoom(100,new EmptyPot[]{new EmptyPot(0x0C,0x16),new EmptyPot(0x10,0x16),new EmptyPot(0x14,0x16),
        new EmptyPot(0x24,0x1C),new EmptyPot(0x28,0x1C),new EmptyPot(0x2C,0x1C),new EmptyPot(0x30,0x1C),},
        new byte[]{0x0A,0x0A,0x0A,0x0A,0x0C,0x0C,0x88}),
        //Game Room 102
        new GameRoom(102,new EmptyPot[]{new EmptyPot(0x30,0x25),new EmptyPot(0x34,0x25),new EmptyPot(0x38,0x25),
        new EmptyPot(0x54,0x05),new EmptyPot(0x68,0x05),new EmptyPot(0x30,0x26),new EmptyPot(0x34,0x26),
        new EmptyPot(0x38,0x26),new EmptyPot(0x54,0x06),new EmptyPot(0x68,0x06),},
        new byte[]{0x07,0x07,0x09,0x09,0x09,0x0A,0x0A,0x0A,0x0B,0x0B}),
        //Game Room 103
        new GameRoom(103,new EmptyPot[]{new EmptyPot(0x16,0x1A),new EmptyPot(0x12,0x16),new EmptyPot(0x5C,0x09),
        new EmptyPot(0x54,0x1C),new EmptyPot(0x0C,0x07),new EmptyPot(0x30,0x07),new EmptyPot(0x60,0x13),
        new EmptyPot(0x4A,0x14),new EmptyPot(0x12,0x17),new EmptyPot(0x12,0x1A),new EmptyPot(0x68,0x1C),},
        new byte[]{0x09,0x0B,0x0B,0x0B,0x0C,0x0C,0x0C}),
        //Game Room 104
        new GameRoom(104,new EmptyPot[]{new EmptyPot(0x54,0x0E),new EmptyPot(0x54,0x0D),new EmptyPot(0x58,0x0C),
        new EmptyPot(0x58,0x06),new EmptyPot(0x58,0x05),new EmptyPot(0x58,0x04),new EmptyPot(0x40,0x11),
        new EmptyPot(0x40,0x0F),new EmptyPot(0x40,0x07),new EmptyPot(0x58,0x07),new EmptyPot(0x40,0x10),
        new EmptyPot(0x40,0x18),new EmptyPot(0x40,0x19),},new byte[]{0x0B,0x0B,0x0B,0x0C,0x0C}),
        //Game Room 115
        new GameRoom(115,new EmptyPot[]{new EmptyPot(0x9A,0x15),new EmptyPot(0x9E,0x15),new EmptyPot(0x14,0x17),
        new EmptyPot(0x24,0x17),new EmptyPot(0x90,0x18),new EmptyPot(0xA8,0x18),new EmptyPot(0x14,0x1A),
        new EmptyPot(0x24,0x1A),new EmptyPot(0x9A,0x1B),new EmptyPot(0x9E,0x1B),},
        new byte[]{0x01,0x01,0x0B,0x0B,0x07,0X07,0x09,0x09,0x0C,0x88}),
        //Game Room 116
        new GameRoom(116,new EmptyPot[]{new EmptyPot(0x1E,0x05),new EmptyPot(0x3E,0x05),new EmptyPot(0x5E,0x05),
        new EmptyPot(0x0E,0x0B),new EmptyPot(0x2E,0x0B),new EmptyPot(0x4E,0x0B),new EmptyPot(0x6E,0x0B),},
        new byte[]{0x09,0x09,0x0B,0x0B,0x0C,0x0C,0x88}),
        //Game Room 117
        new GameRoom(117,new EmptyPot[]{new EmptyPot(0x94,0x16),new EmptyPot(0xA0,0x16),new EmptyPot(0xAC,0x16),},
        new byte[]{0x09,0x0B,0x0C}),
        //Game Room 123
        new GameRoom(123,new EmptyPot[]{new EmptyPot(0x30,0x0A),new EmptyPot(0x58,0x0A),new EmptyPot(0x4C,0x07),
        new EmptyPot(0x3C,0x04),new EmptyPot(0x40,0x04),},new byte[]{0x0B,0x08}),
        //Game Room 124
        new GameRoom(124,new EmptyPot[]{new EmptyPot(0x24,0x15),new EmptyPot(0x18,0x0B),new EmptyPot(0x1C,0x04),
        new EmptyPot(0x20,0x04),},new byte[]{0x0B,0x0B}),
        //Game Room 125
        new GameRoom(125,new EmptyPot[]{new EmptyPot(0x2C,0x0C),new EmptyPot(0x2C,0x06),new EmptyPot(0x70,0x06),
        new EmptyPot(0x6C,0x14),new EmptyPot(0x72,0x14),new EmptyPot(0x4C,0x1C),},new byte[]{0x09,0x0A,0x0A,0x0B}),
        //Game Room 126
        new GameRoom(126,new EmptyPot[]{new EmptyPot(0x56,0x0F),new EmptyPot(0x52,0x1A),new EmptyPot(0x64,0x1A),
        new EmptyPot(0x68,0x1A),},new byte[]{0x0B,0x0C,0x88}),
        //Game Room 130
        new GameRoom(130,new EmptyPot[]{new EmptyPot(0x32,0x05),new EmptyPot(0x32,0x0A),new EmptyPot(0x4C,0x32),},
        new byte[]{0x0B}),
        //Game Room 131
        new GameRoom(131,new EmptyPot[]{new EmptyPot(0x4C,0x04),new EmptyPot(0x50,0x04),new EmptyPot(0x4C,0x1C),
        new EmptyPot(0x50,0x1C),},new byte[]{0x01,0x07,0x09,0x09}),
        //Game Room 132
        new GameRoom(132,new EmptyPot[]{new EmptyPot(0x40,0x11),new EmptyPot(0x3C,0x11),new EmptyPot(0x50,0x0E),
        new EmptyPot(0x2C,0x0E),new EmptyPot(0x64,0x06),new EmptyPot(0x18,0x06),new EmptyPot(0x18,0x07),
        new EmptyPot(0x64,0x07),},new byte[]{0x09,0x09}),
        //Game Room 135
        new GameRoom(135,new EmptyPot[]{new EmptyPot(0x0C,0x0B),new EmptyPot(0x4C,0x14),new EmptyPot(0x70,0x14),
        new EmptyPot(0x10,0x0C),new EmptyPot(0x28,0x0C),new EmptyPot(0x20,0x0C),new EmptyPot(0x18,0x0C),
        new EmptyPot(0x10,0x0B),},new byte[]{0x0C,0x0D}),
        //Game Room 139
        new GameRoom(139,new EmptyPot[]{new EmptyPot(0x4C,0x14),new EmptyPot(0x4C,0x0C,1),new EmptyPot(0x20,0x17,1),
        new EmptyPot(0x1C,0x17,1),new EmptyPot(0x70,0x0C,1),new EmptyPot(0x20,0x09,1),new EmptyPot(0x4C,0x1C),},
        new byte[]{0x08,0x0B,0x0C}),
        //Game Room 140
        new GameRoom(140,new EmptyPot[]{new EmptyPot(0x4C,0x0C,2),new EmptyPot(0x70,0x0C,2),new EmptyPot(0x4C,0x14),
        new EmptyPot(0x5C,0x14),new EmptyPot(0x64,0x15),new EmptyPot(0x68,0x1A),new EmptyPot(0x58,0x1B),},
        new byte[]{0x09,0x0A,0x0A,0x0A,0x0A,0x0C,0x88}),
        //Game Room 145
        new GameRoom(145,new EmptyPot[]{new EmptyPot(0x54,0x04),new EmptyPot(0x68,0x04),},new byte[]{0x0B,0x0C}),
        //Game Room 150
        new GameRoom(150,new EmptyPot[]{new EmptyPot(0x0E,0x12),new EmptyPot(0x20,0x05),new EmptyPot(0x20,0x11),
        new EmptyPot(0x20,0x18),new EmptyPot(0x4C,0x15),new EmptyPot(0x70,0x15),new EmptyPot(0x0E,0x18),},
        new byte[]{0x0B,0x0C,0x0C,0x0D}),
        //Game Room 155
        new GameRoom(155,new EmptyPot[]{new EmptyPot(0x30,0x04),new EmptyPot(0x30,0x0C),},new byte[]{0x08,0x0C}),
        //Game Room 157
        new GameRoom(157,new EmptyPot[]{new EmptyPot(0x20,0x07),new EmptyPot(0x28,0x09),new EmptyPot(0x4C,0x04),
        new EmptyPot(0x54,0x04),},new byte[]{0x0A,0x0C}),
        //Game Room 159
        new GameRoom(159,new EmptyPot[]{new EmptyPot(0x8A,0x14),new EmptyPot(0x8A,0x13),new EmptyPot(0xB2,0x13),
        new EmptyPot(0x28,0x15),new EmptyPot(0x8A,0x15),new EmptyPot(0x14,0x1B),new EmptyPot(0x8A,0x1B),
        new EmptyPot(0xB2,0x1C),new EmptyPot(0xB2,0x15),new EmptyPot(0xB2,0x14),new EmptyPot(0x28,0x1B),
        new EmptyPot(0xB2,0x1B),new EmptyPot(0xB2,0x1A),new EmptyPot(0x8A,0x1C),new EmptyPot(0x8A,0x1A),
        new EmptyPot(0x14,0x15),},new byte[]{0x08,0x0B,0x0B,0x0B,0x0B,0x0B,0x88}),
        //Game Room 161
        new GameRoom(161,new EmptyPot[]{new EmptyPot(0x60,0x1B),new EmptyPot(0x5C,0x15),new EmptyPot(0x96,0x06),
        new EmptyPot(0x64,0x0B),new EmptyPot(0x68,0x0C),new EmptyPot(0x6C,0x0D),new EmptyPot(0x70,0x0E),
        new EmptyPot(0x60,0x17),new EmptyPot(0x4C,0x1C),new EmptyPot(0x70,0x1C),},new byte[]{0x08,0x0B,0x0B,0x0B,0x0C,0x0C}),
        //Game Room 168
        new GameRoom(168,new EmptyPot[]{new EmptyPot(0x8A,0x1C),new EmptyPot(0xB2,0x1C),new EmptyPot(0xB2,0x13),
        new EmptyPot(0x8A,0x13),new EmptyPot(0x1E,0x18),},new byte[]{0x01,0x0B}),
        //Game Room 169
        new GameRoom(169,new EmptyPot[]{new EmptyPot(0x0C,0x13),new EmptyPot(0x70,0x13),new EmptyPot(0x90,0x2B),
        new EmptyPot(0xEC,0x2B),new EmptyPot(0x90,0x2C),new EmptyPot(0xEC,0x2C),new EmptyPot(0x10,0x14),
        new EmptyPot(0x6C,0x14),},new byte[]{0x0B,0x0B,0x0B,0x09,0x09,0x09}),
        //Game Room 170
        new GameRoom(170,new EmptyPot[]{new EmptyPot(0xD4,0x0A,2),new EmptyPot(0xE8,0x0A,2),new EmptyPot(0xE8,0x05,2),
        new EmptyPot(0xD4,0x05,2),new EmptyPot(0x5E,0x08,2),new EmptyPot(0x6C,0x37),new EmptyPot(0x6C,0x38),
        new EmptyPot(0x6C,0x39),},new byte[]{0x0B,0x0B,0x0B,0x0B,0x88}),
        //Game Room 176
        new GameRoom(176,new EmptyPot[]{new EmptyPot(0x14,0x1B),new EmptyPot(0x18,0x18),new EmptyPot(0x2C,0x19),
        new EmptyPot(0x14,0x15),new EmptyPot(0x1C,0x15),new EmptyPot(0x20,0x15),new EmptyPot(0x28,0x15),
        new EmptyPot(0x10,0x17),new EmptyPot(0x2C,0x17),new EmptyPot(0x24,0x18),new EmptyPot(0x10,0x19),
        new EmptyPot(0x1C,0x1B),new EmptyPot(0x28,0x1B),new EmptyPot(0x20,0x1B)},
        new byte[]{0x01,0x01,0x07,0x07,0x09,0x09,0x0A,0x0A,0x0B,0x0B}),
        //Game Room 179
        new GameRoom(179,new EmptyPot[]{new EmptyPot(0x0C,0x14),new EmptyPot(0x30,0x14),new EmptyPot(0x30,0x1C),},
        new byte[]{0x08,0x0C,0x88}),
        //Game Room 180
        new GameRoom(180,new EmptyPot[]{new EmptyPot(0x2C,0x1C),new EmptyPot(0x30,0x1C),},new byte[]{0x0B,0x0D}),
        //Game Room 181
        new GameRoom(181,new EmptyPot[]{new EmptyPot(0x70,0x04),new EmptyPot(0x70,0x0F),new EmptyPot(0x4C,0x10),
        new EmptyPot(0x70,0x10),new EmptyPot(0x70,0x11),new EmptyPot(0x70,0x1C),},new byte[]{0x07,0x0A,0x0B,0x0B,0x0D,0x88}),
        //Game Room 184
        new GameRoom(184,new EmptyPot[]{new EmptyPot(0x60,0x0D),new EmptyPot(0x58,0x10),new EmptyPot(0x68,0x10),},
        new byte[]{0x0B,0x0B,0x88}),
        //Game Room 185
        new GameRoom(185,new EmptyPot[]{new EmptyPot(0x5C,0x12),new EmptyPot(0x60,0x12),new EmptyPot(0x68,0x12),
        new EmptyPot(0x6C,0x12),},new byte[]{0x01,0x01,0x07,0x07}),
        //Game Room
        new GameRoom(186,new EmptyPot[]{new EmptyPot(0x64,0x08),new EmptyPot(0x58,0x08),new EmptyPot(0x5E,0x04),
        new EmptyPot(0x4C,0x06),new EmptyPot(0x70,0x06),new EmptyPot(0x4C,0x0A),new EmptyPot(0x70,0x0A),
        new EmptyPot(0x5E,0x0C),},new byte[]{0x01,0x01,0x08,0x0B,0x0B,0x0C}),
        //Game Room 188
        new GameRoom(188,new EmptyPot[]{new EmptyPot(0x8A,0x03,2),new EmptyPot(0xB2,0x03,2),new EmptyPot(0x56,0x04,1),
        new EmptyPot(0x66,0x04,1),new EmptyPot(0x8A,0x0C,2),new EmptyPot(0xB2,0x0C,2),new EmptyPot(0x30,0x14),
        new EmptyPot(0x1C,0x15),new EmptyPot(0x20,0x15),new EmptyPot(0x1C,0x1B),new EmptyPot(0x20,0x1B),
        new EmptyPot(0x0C,0x1C),new EmptyPot(0x30,0x1C),},new byte[]{0x07,0x07,0x07,0x07,0x08,0x0A,0x0A,0x0A,0x0A,0x0A,0x0B,0x0B,0x88}),
        //Game Room 191
        new GameRoom(191,new EmptyPot[]{new EmptyPot(0x28,0x14),new EmptyPot(0x2C,0x14),new EmptyPot(0x30,0x14),
        new EmptyPot(0x28,0x1C),new EmptyPot(0x2C,0x1C),new EmptyPot(0x30,0x1C),},new byte[]{0x09,0x0A,0x0B,0x0C,0x0C,0x0C}),
        //Game Room 192
        new GameRoom(192,new EmptyPot[]{new EmptyPot(0x30,0x0A),new EmptyPot(0x0C,0x0E),new EmptyPot(0x0C,0x1A),
        new EmptyPot(0x1C,0x1B),},new byte[]{0x01,0x07,0x0A,0x0B}),
        //Game Room 192
        new GameRoom(194,new EmptyPot[]{new EmptyPot(0xB4,0x07),new EmptyPot(0x64,0x2E),new EmptyPot(0x44,0x30),
        new EmptyPot(0x40,0x34),},new byte[]{0x01,0x09,0x0C,0x88}),
        //Game Room 196
        new GameRoom(196,new EmptyPot[]{new EmptyPot(0x54,0x09),new EmptyPot(0x18,0x0E),new EmptyPot(0x38,0x11),
        new EmptyPot(0x54,0x11),new EmptyPot(0x0C,0x15),new EmptyPot(0x4C,0x17),new EmptyPot(0x30,0x19),
        new EmptyPot(0x0C,0x1A),},new byte[]{0x01,0x09,0x0C,0x07,0x0A,0x0A,0x0B,0x0B}),
        //Game Room 199
        new GameRoom(199,new EmptyPot[]{new EmptyPot(0x0C,0x0A),new EmptyPot(0x0C,0x0B),new EmptyPot(0x0C,0x16),
        new EmptyPot(0x0C,0x1C),},new byte[]{0x09,0x0C,0x0B,0x0D}),
        //Game Room 201
        new GameRoom(201,new EmptyPot[]{new EmptyPot(0x1E,0x16),new EmptyPot(0x5E,0x16),new EmptyPot(0x3C,0x16),},
        new byte[]{0x01,0x01,0x88}),
        //Game Room 203
        new GameRoom(203,new EmptyPot[]{new EmptyPot(0x58,0x10),new EmptyPot(0x58,0x1C),},new byte[]{0x07,0x0B}),
        //Game Room 204
        new GameRoom(204,new EmptyPot[]{new EmptyPot(0x24,0x04),new EmptyPot(0x70,0x04),new EmptyPot(0x24,0x1C),
        new EmptyPot(0x70,0x1C),},new byte[]{0x07,0x0B,0x07,0x0A}),
        //Game Room 206
        new GameRoom(206,new EmptyPot[]{new EmptyPot(0x4C,0x08),new EmptyPot(0x50,0x08),new EmptyPot(0x6C,0x0C),
        new EmptyPot(0x70,0x0C),new EmptyPot(0xCC,0x0B,3),},new byte[]{0x09,0x0C,0x0C,0x0A,0x80}),
        //Game Room 208
        new GameRoom(208,new EmptyPot[]{new EmptyPot(0x9E,0x05),new EmptyPot(0x8C,0x0B),new EmptyPot(0x2A,0x0D),
        new EmptyPot(0x30,0x10),new EmptyPot(0xB0,0x14),new EmptyPot(0x92,0x17),new EmptyPot(0x0C,0x1C),},
        new byte[]{0x01,0x01,0x07,0x0B,0x0B,0x0C,0x0C}),
        //Game Room 209
        new GameRoom(209,new EmptyPot[]{new EmptyPot(0x4C,0x0C),new EmptyPot(0x30,0x04),new EmptyPot(0x4C,0x04),
        new EmptyPot(0x70,0x04),new EmptyPot(0xA8,0x07),new EmptyPot(0x70,0x0C),},new byte[]{0x09,0x01,0x01,0x01,0x0D}),
        //Game Room 214
        new GameRoom(214,new EmptyPot[]{new EmptyPot(0x5C,0x16),new EmptyPot(0x60,0x16),},new byte[]{0x0A,0x0D}),
        //Game Room 216
        new GameRoom(216,new EmptyPot[]{new EmptyPot(0xCA,0x08),new EmptyPot(0xF2,0x08),new EmptyPot(0xCA,0x0A),
        new EmptyPot(0xF2,0x0A),new EmptyPot(0xCA,0x0C),new EmptyPot(0xF2,0x0C),new EmptyPot(0x5C,0x18),
        new EmptyPot(0x60,0x18),},new byte[]{0x09,0x09,0x09,0x09,0x09,0x0B,0x0B,0x0B}),
        //Game Room 218
        new GameRoom(218,new EmptyPot[]{new EmptyPot(0x18,0x17),new EmptyPot(0x24,0x17),new EmptyPot(0x18,0x19),
        new EmptyPot(0x24,0x19),},new byte[]{0x09,0x09,0x0B,0x88}),
        //Game Room 219
        new GameRoom(219,new EmptyPot[]{new EmptyPot(0x0C,0x04),new EmptyPot(0x3E,0x13),new EmptyPot(0x70,0x04),
        new EmptyPot(0x58,0x10),},new byte[]{0x07,0x0B}),
        //Game Room 220
        new GameRoom(220,new EmptyPot[]{new EmptyPot(0x38,0x04),new EmptyPot(0x70,0x04),new EmptyPot(0x44,0x10),
        new EmptyPot(0x0C,0x1C),},new byte[]{0x07,0x09,0x0A,0x0B}),
        //Game Room 235
        new GameRoom(235,new EmptyPot[]{new EmptyPot(0xCE,0x08),new EmptyPot(0xD2,0x08),new EmptyPot(0x58,0x0E),
        new EmptyPot(0x5C,0x0E),new EmptyPot(0x60,0x0E),},new byte[]{0x07,0x07,0x0B,0x0C,0x0C}),


        };

        public void randomizePots(int seed)
        {
            fixRetroArrows();


            Random r = new Random(seed);
            foreach (GameRoom g in roomList)
            {
                //scan all items and pots to see if there is a key or switch and pots reserved
                bool reservedkey = false;
                bool reservedswitch = false;
                List<byte> roomItems = new List<byte>();
                List<EmptyPot> roomEmptyPots = new List<EmptyPot>();
                List<FilledPot> roomPots = new List<FilledPot>();
                for (int i = 0; i < g.items.Length; i++)
                {
                    if (g.items[i] != 0x80) // if it a hole we don't want it
                    {
                        roomItems.Add(g.items[i]);
                    }

                }

                for (int i = 0; i < g.pots.Length; i++)
                {
                    if (g.pots[i].reserved == 3)
                    {
                        roomPots.Add(new FilledPot(g.pots[i].x, g.pots[i].y, 0x80)); //if it a hole it stay in the default pot
                    }
                    else
                    {
                        roomEmptyPots.Add(g.pots[i]); // as long as it not a hole we push a possible pot in empty pots list
                    }
                    if (g.pots[i].reserved == 1)
                    {
                        reservedkey = true;
                    }
                    if (g.pots[i].reserved == 2)
                    {
                        reservedswitch = true;
                    }


                }

                if (g.id == 201)
                {
                    //Debug.WriteLine("(Room201)NBR ITEMS ORIG: " + g.items.Length + " / copied items :" + roomItems.Count + "Original pots :" + g.pots.Length + " / copied pots : " + roomEmptyPots.Count);
                }

                while (reservedkey || reservedswitch) // loop until we find a spot for a key and switch if they have reserved spot
                {

                    if (reservedkey)//try to place a key in a reserved pot
                    {
                        int pid = r.Next(0, roomEmptyPots.Count);
                        if (g.pots[pid].reserved == 1)
                        {
                            roomItems.Remove(0x08);
                            roomPots.Add(new FilledPot(g.pots[pid].x, g.pots[pid].y, 0x08));
                            roomEmptyPots.Remove(g.pots[pid]);
                            reservedkey = false;
                        }
                    }

                    if (reservedswitch)//try to place a switch in a reserved pot
                    {
                        int pid = r.Next(0, roomEmptyPots.Count);
                        if (g.pots[pid].reserved == 2)
                        {
                            roomItems.Remove(0x88);
                            roomPots.Add(new FilledPot(g.pots[pid].x, g.pots[pid].y, 0x88));
                            roomEmptyPots.Remove(g.pots[pid]);

                            reservedswitch = false;
                        }
                    }
                }

                while (roomItems.Count > 0) // as long we have items to place we place them in an empty pot and remove the empty pot from the list
                {
                    int pid = r.Next(0, roomEmptyPots.Count);
                    byte oid = (byte)roomItems[r.Next(0, roomItems.Count)];
                    if (optionFlags.HeroMode == true)
                    {
                        if (oid == 0x0B)
                        {
                            byte nid = 0;
                            while (true)
                            {
                                nid = (byte)r.Next(0, 0x13);
                                if (nid != 0x08 && nid != 0x0F && nid != 0x10 && nid != 0x11 && nid != 0x0B)
                                {
                                    break;
                                }

                            }
                            roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, 0x0B));
                            roomItems.Remove(oid);
                            roomEmptyPots.RemoveAt(pid);
                            continue;
                        }

                        //Also need to remove hearts in hera
                        for (int i = 0; i < 12; i++)
                        {

                        }
                    }


                    roomPots.Add(new FilledPot(roomEmptyPots[pid].x, roomEmptyPots[pid].y, oid));
                    roomItems.Remove(oid);
                    roomEmptyPots.RemoveAt(pid);
                    if (roomItems.Count == 0)
                    {
                        break;
                    }
                }


                //Zarby Note : wow what is that code :scream:
                byte[] itemPointer = new byte[4];
                itemPointer[2] = 01;//
                itemPointer[0] = ROM_DATA[(0xDB67 + ((int)g.id * 2)) + 0];
                itemPointer[1] = ROM_DATA[(0xDB67 + ((int)g.id * 2)) + 1];
                int itemaddress = BitConverter.ToInt32(itemPointer, 0);
                int addr = Utilities.SnesToPCAddress(itemaddress);

                // TODO: unused - Zarby: was used to list all the pots in the console i think
                byte[] exportPots = new byte[roomPots.Count * 3];

                //replace hearts in hera if hero mode is on
                if (optionFlags.HeroMode == true)
                {
                    if (g.id == 23) // if room id == 23 then change all the pots by something else than hearts
                    for (int i = 0; i < 12; i++)
                    {
                        byte nid = 0;
                        while (true)
                        {
                            nid = (byte)r.Next(0, 0x13);
                            if (nid != 0x08 && nid != 0x0F && nid != 0x10 && nid != 0x11 && nid != 0x0B)
                            {
                                ROM_DATA[addr + (i * 3)+2] = nid;
                                break;
                            }

                        }

                    }
                }



                for (int i = 0; i < roomPots.Count; i++)
                {
                    ROM_DATA[addr + (i * 3) + 0] = roomPots[i].x;
                    ROM_DATA[addr + (i * 3) + 1] = roomPots[i].y;
                    ROM_DATA[addr + (i * 3) + 2] = roomPots[i].id;
                }





            }
        }

        void fixRetroArrows()
        {
            // check if retro mode arrows set
            if(ROM_DATA[0x180175] == 0x0)
            {
                return;
            }

            foreach (GameRoom g in roomList)
            {
                for(var i=0; i<g.items.Length; ++i)
                {
                    if(g.items[i] == 0x9) // arrows
                    {
                        g.items[i] = 0x7; // blue rupees
                    }
                }
            }

        }


    }

        public class GameRoom
        {
            public int id;
            public EmptyPot[] pots;
            public byte[] items;
            public GameRoom(int id, EmptyPot[] pots, byte[] items)
            {
                this.id = id;
                this.pots = pots;
                this.items = items;
            }

        }

        public class EmptyPot
        {
            public byte x, y, reserved;
            public EmptyPot(byte x, byte y, byte reserved = 0)
            {
                //Reserved
                //0 anything can go here, 1 reserved for key, 2 reserved for switch, 3 [0x80 go there]
                this.x = x;
                this.y = y;
                this.reserved = reserved;
            }
        }

        public class FilledPot
        {
            public byte x, y, id;
            public FilledPot(byte x, byte y, byte id)
            {
                this.x = x;
                this.y = y;
                this.id = id;
            }
        }

}
