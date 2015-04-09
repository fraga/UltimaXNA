﻿/***************************************************************************
 *   TargetObjectPacket.cs
 *   
 *   begin                : May 31, 2009
 *   email                : poplicola@ultimaxna.com
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
#region usings
using UltimaXNA.Core.Network.Packets;
using UltimaXNA.Ultima.Entities;
#endregion

namespace UltimaXNA.Ultima.Network.Client
{
    public class TargetObjectPacket : SendPacket
    {
        public TargetObjectPacket(AEntity entity, int cursorID)
            : base(0x6C, "Target Object", 19)
        {
            Stream.Write((byte)0x00); // BYTE[1] type: 0x00 = Select Object; 0x01 = Select X, Y, Z
            Stream.Write((int)cursorID); // BYTE[4] cursorID 
            Stream.Write((byte)0x00); // BYTE[1] Cursor Type; 3 to cancel.
            Stream.Write((int)entity.Serial); // BYTE[4] Clicked On ID. Not used in this packet.
            Stream.Write((short)entity.X); // BYTE[2] click xLoc
            Stream.Write((short)entity.Y); // BYTE[2] click yLoc
            Stream.Write((byte)0x00); // BYTE unknown (0x00)
            Stream.Write((byte)entity.Z); // BYTE click zLoc
            Stream.Write((short)0); // BYTE[2] model # (if a static tile, 0 if a map/landscape tile)
        }
    }
}
