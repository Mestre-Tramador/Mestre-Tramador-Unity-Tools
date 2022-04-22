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
    ///     A 2D Player is a special type of 2D Character that is controlled by the User.
    /// </summary>
    sealed public class Player2D : Character2D, Player2DEvents
    {
        /// <summary>
        ///     The Events Caller.
        /// </summary>
        /// <value>
        ///     It's a simple casting for the <see langword="interface" />.
        /// </value>
        private Player2DEvents E { get => this; }

        /// <inheritdoc />
        /// <remarks>
        ///     The 2D Player set the following values:
        ///     <list type="bullet">
        ///         <item>
        ///            <term><see cref="Character2D.Force" /></term>
        ///            <description><see langword="300.0f" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="Character2D.Speed" /></term>
        ///            <description><see langword="5.0f" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="Character2D.JumpMode" /></term>
        ///            <description><see cref="JumpModes.DoubleJump" /></description>
        ///         </item>
        ///     </list>
        /// </remarks>
        protected override void OnAwake()
        {
            base.OnAwake();

            Force = 300.0f;
            Speed = 5.0f;
        }

        /// <summary>
        ///     On Update, listen to its Events.
        /// </summary>
        protected override void OnUpdate()
        {
            E.ListenOnUpdate(this);
        }

        /// <summary>
        ///     On Reset, all base sets are made and then
        ///     a new Jump Mode is defined.
        /// </summary>
        protected override void OnReset()
        {
            base.OnReset();

            JumpMode = JumpModes.DoubleJump;
        }

        /// <summary>
        ///     On Enter of a 2D Collision, listen to its Events.
        /// </summary>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            E.ListenOnCollisionEnter2D(this, collision);
        }
    }
}
