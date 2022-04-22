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

namespace MestreTramador
{
    /// <summary>
    ///     The Move Event refers to any movement on a Behaviour.
    /// </summary>
    sealed public partial class MoveEvent : Event
    {
        #nullable enable
        #pragma warning disable CS8604
        /// <summary>
        ///     On the occurrence of the Move Event,
        ///     if it is a <see cref="Character2D" />,
        ///     then it calculates the movement based
        ///     on the controls properties and move the
        ///     Character.
        /// </summary>
        /// <inheritdoc cref="Event.On{B}(B, object?)" />
        public override void On<B>(B behaviour, object? arg = null)
        {
            if(behaviour is Player2D)
            {
                this.OnMovePlayer2D(behaviour as Player2D);

                return;
            }
        }
        #pragma warning restore CS8604
        #nullable disable
    }
}
