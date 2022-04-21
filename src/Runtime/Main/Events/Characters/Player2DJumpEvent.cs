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
    ///     The Jump Event, as the name suggests, refers to any jump on a Behaviour.
    /// </summary>
    sealed public partial class JumpEvent : Event
    {
        /// <summary>
        ///     If the 2D Player can jump and has a valid mode of jumping,
        ///     then a <see cref="Vector2.up" /> is calculated with the
        ///     <see cref="Character2D.Force" /> and added to the Player's Body.
        /// </summary>
        /// <param name="player">The instance of the Player.</param>
        private void OnJumpPlayer2D(Player2D player)
        {
            if(!player.CanJump || player.JumpMode == JumpModes.NoJump)
            {
                return;
            }

            if(Input.GetKeyDown(KeyCode.Space) && player.Jumps <= 1)
            {
                player.Body.AddForce(Vector2.up * player.Force);

                player.Jumps++;
            }
        }
    }
}
