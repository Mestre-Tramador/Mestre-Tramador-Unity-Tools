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
    ///     An Event is an action occurred on some Behaviour.
    /// </summary>
    public abstract class Event
    {
        /// <inheritdoc cref="On{B}(B, object?)" />
        public void On<B>(B behaviour) where B : BaseMonoBehaviour
        {
            this.On<B>(behaviour, null);
        }

        /// <summary>
        ///     On the occurrence of the Event...
        /// </summary>
        /// <param name="behaviour">The instance of the Behaviour.</param>
        /// <param name="arg">Some additional data to the Event.</param>
        /// <typeparam name="B">On any type of Behaviour can occur an Event.</typeparam>
        public abstract void On<B>(B behaviour, object? arg = null) where B : BaseMonoBehaviour;
    }
}
