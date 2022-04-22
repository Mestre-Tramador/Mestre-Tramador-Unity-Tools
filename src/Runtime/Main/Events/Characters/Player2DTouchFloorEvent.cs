#region License
// This is a ClassLib to help Unity Developers, Game Designers or Students.
// Copyright (C) 2022  Mestre-Tramador
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion

using UnityEngine;

namespace MestreTramador
{
    /// <summary>
    ///     The Touch Floor Event refers to any kind of collision on or of a Behaviour in a Floor.
    /// </summary>
    sealed public partial class TouchFloorEvent : TouchEvent
    {
        /// <summary>
        ///     When the 2D Player touches the Floor, its <see cref="Character2D.Jumps" />
        ///     are set to <see langword="0" /> and reenabled if the <see cref="Character2D.JumpMode" /> permits.
        /// </summary>
        /// <param name="player">The instance of the Player.</param>
        /// <param name="collision">The Floor collided.</param>
        private void OnTouchFloorPlayer2D(Player2D player, Collision2D collision)
        {
            // TODO: Verify if is a "floor".

            if(player.JumpMode != JumpModes.NoJump)
            {
               if(!player.CanJump)
                {
                    player.Jumps = 0;
                    player.CanJump = true;
                }
            }
        }
    }
}
