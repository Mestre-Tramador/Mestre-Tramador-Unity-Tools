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

using System;

namespace MestreTramador
{
    /// <summary>
    ///     Mark an Event as Usable by a Behaviour.
    /// </summary>
    /// <typeparam name="E">Any kind of Event can be used.</typeparam>
    /// <typeparam name="B">Any Behaviour can use an Event.</typeparam>
    public interface UseEvent<E, B>
    where E : Event
    where B : BaseMonoBehaviour
    {
        /// <inheritdoc cref="Use{Ev}(B, object?)" />
        void Use<Ev>(B behaviour) where Ev : E
        {
            Activator.CreateInstance<Ev>().On<B>(behaviour);
        }

        /// <summary>
        ///     Activate and use the Event.
        /// </summary>
        /// <param name="behaviour">The instance of the Behaviour using the Event.</param>
        /// <param name="arg">The optional argument, if needed.</param>
        /// <typeparam name="Ev">The Event on use.</typeparam>
        void Use<Ev>(B behaviour, object? arg = null) where Ev : E
        {
            Activator.CreateInstance<Ev>().On<B>(behaviour, arg);
        }
    }
}
