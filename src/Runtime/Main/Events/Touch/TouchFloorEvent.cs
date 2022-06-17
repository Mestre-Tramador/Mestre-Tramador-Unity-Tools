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

using System;
using UnityEngine;

namespace MestreTramador
{
    /// <summary>
    ///     The Touch Floor Event refers to any kind of collision on or of a Behaviour in a Floor.
    /// </summary>
    sealed public partial class TouchFloorEvent : TouchEvent
    {
        #pragma warning disable CS8604
        /// <summary>
        ///     On the occurrence of the Touch Floor Event,
        ///     if it is a <see cref="Character2D" />,then
        ///     it sets the Character's Jumps to zero.
        /// </summary>
        /// <inheritdoc cref="TouchEvent.On{B}(B, Collision2D)" />
        public override void On<B>(B behaviour, Collision2D collision)
        {
            if(behaviour is Player2D)
            {
                this.OnTouchFloorPlayer2D(behaviour as Player2D, collision);

                return;
            }
        }

        #nullable enable
        /// <inheritdoc cref="On{B}(B, Collision2D)" />
        /// <remarks>
        ///     The argument must be a <see cref="Collision2D" />.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when there is no <see cref="Collision2D" /> as argument.</exception>
        public override void On<B>(B behaviour, object? arg = null)
        {
            if(arg is Collision2D)
            {
                this.On<B>(behaviour, arg as Collision2D);

                return;
            }

            throw new InvalidOperationException("Not a Touch Event!");
        }
        #nullable disable
        #pragma warning restore CS8604
    }
}
