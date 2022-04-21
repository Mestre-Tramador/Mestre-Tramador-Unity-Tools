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
    ///     Tange through all <c>Vector</c> <see langword="struct" />,
    ///     reducing encapsulating new instances with extensions.
    /// </summary>
    public static class TangibleVectors
    {
        /// <summary>
        ///     Tange from a existing <c>Vector</c> to create a new one
        ///     with the given values and reusing the others that weren't given.
        /// </summary>
        /// <param name="vector">The current <c>Vector</c>.</param>
        /// <param name="x">A <see langword="float" /> value to be the new X.</param>
        /// <param name="y">A <see langword="float" /> value to be the new Y.</param>
        /// <param name="z">A <see langword="float" /> value to be the new Z.</param>
        /// <returns>The tanged <c>Vector</c>.</returns>
        public static Vector3 Tange(this Vector3 vector, object? x = null, object? y = null, object? z = null)
        {
            return new Vector3(
                x == null ? vector.x : (float) x,
                y == null ? vector.y : (float) y,
                z == null ? vector.x : (float) z
            );
        }

        /// <summary>
        ///     Invert the X of a <c>Vector</c>.
        /// </summary>
        /// <param name="vector">The current <c>Vector</c>.</param>
        /// <returns>The same <c>Vector</c>, but with its X inverted.</returns>
        public static Vector3 InvertX(this Vector3 vector)
        {
            return vector.Tange(x: vector.x * -1.0f);
        }
    }
}
