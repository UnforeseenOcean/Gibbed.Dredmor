﻿/* Copyright (c) 2011 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;

namespace Gibbed.Dredmor.Maximap.Game
{
    internal class Player
    {
        public int X;
        public int Y;

        // 1.0.3.1 (hotfix)
        private const uint OffsetX = 0x50;
        private const uint OffsetY = 0x54;

        public static Player Read(ProcessMemory memory, uint baseAddress)
        {
            if ((ClassVTableAddress)memory.ReadU32(baseAddress + 0x00) !=
                ClassVTableAddress.Player)
            {
                throw new InvalidOperationException("player class vtable mismatch, outdated class vtable addresses?");
            }

            var player = new Player();
            player.X = memory.ReadS32(baseAddress + OffsetX);
            player.Y = memory.ReadS32(baseAddress + OffsetY);
            return player;
        }
    }
}
