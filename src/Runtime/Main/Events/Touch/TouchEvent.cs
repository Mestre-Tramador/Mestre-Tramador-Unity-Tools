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
    ///     The Touch Event refers to any kind of collision on or of a Behaviour.
    /// </summary>
    public abstract class TouchEvent : Event
    {
        /// <inheritdoc cref="Event.On{B}(B, object?)" />
        /// <param name="behaviour">The instance of the Behaviour.</param>
        /// <param name="collision">The Collision mandatory argument.</param>
        public abstract void On<B>(B behaviour, Collision2D collision) where B : BaseMonoBehaviour;
    }
}
