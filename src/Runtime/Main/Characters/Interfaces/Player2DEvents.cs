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
    ///     A 2D Player use the following Events:
    ///     <list type="bullet">
    ///         <item>
    ///            <term><see cref="MoveEvent" /></term>
    ///            <description>
    ///                 Listened on Update, it handles the movement of the
    ///                 2D Player on the screen.
    ///             </description>
    ///         </item>
    ///         <item>
    ///            <term><see cref="JumpEvent" /></term>
    ///            <description>
    ///                 Listened on Update, it handles the jumps actions of the
    ///                 2D Player on the screen.
    ///             </description>
    ///         </item>
    ///         <item>
    ///            <term><see cref="TouchFloorEvent" /></term>
    ///            <description>
    ///                 Listened on Enter of a 2D Collision, it handles if the
    ///                 2D Player touches the floor.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    public interface Player2DEvents : UseEvent<MoveEvent, Player2D>, UseEvent<JumpEvent, Player2D>, UseEvent<TouchFloorEvent, Player2D>
    {
        /// <summary>
        ///     Listen to the <see cref="MoveEvent" /> and <see cref="JumpEvent" /> on Update.
        /// </summary>
        /// <param name="player">The instance of the 2D Player on the scene.</param>
        void ListenOnUpdate(Player2D player)
        {
            if(typeof(Player2DEvents).IsAssignableFrom(typeof(Player2D)))
            {
                this.Use<MoveEvent>(player);
                this.Use<JumpEvent>(player);
            }
        }

        /// <summary>
        ///     Listen to the <see cref="TouchFloorEvent" /> on Enter of a 2D Collision.
        /// </summary>
        /// <param name="player">The instance of the 2D Player on the scene.</param>
        /// <param name="collision">The instance of the entered 2D collision.</param>
        void ListenOnCollisionEnter2D(Player2D player, Collision2D collision)
        {
            if(typeof(Player2DEvents).IsAssignableFrom(typeof(Player2D)))
            {
                this.Use<TouchFloorEvent>(player, collision);
            }
        }
    }
}
