#region License
// This is a Package to help Unity Developers, Game Designers or Students.
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
    ///     The Move Event refers to any movement on a Behaviour.
    /// </summary>
    sealed public partial class MoveEvent : Event
    {
        /// <summary>
        ///     If the 2D Player can move, then its new X is calculated based on the
        ///     <see cref="Character2D.Speed" />, <see cref="Input.GetAxis(string)" />
        ///     and <see cref="Time.deltaTime" />, so a <c>Tanged Vector3</c> is translated
        ///     on the Player's <c>Transform</c>.
        /// </summary>
        /// <param name="player">The instance of the Player.</param>
        private void OnMovePlayer2D(Player2D player)
        {
            if(!player.CanMove)
            {
                return;
            }

            float axis = Input.GetAxis("Horizontal");

            float x = axis * player.Speed * Time.deltaTime;

            Directions2D dir = player.IsTurnedTo;            

            if((x > 0.0f && dir == Directions2D.Left) || (x < 0.0f && dir == Directions2D.Right))
            {
                player.Turn();
            }

            player.transform.Translate(Vector3.zero.Tange(x: x));
        }
    }
}
