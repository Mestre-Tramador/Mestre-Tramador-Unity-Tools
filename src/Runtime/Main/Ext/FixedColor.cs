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
    ///     Extends and fixes the use of the Unity's <see cref="Color" />.
    /// </summary>
    public static class FixedColor
    {
        /// <summary>
        ///     Make a color opaque.
        /// </summary>
        /// <param name="color">The current color to convert.</param>
        /// <returns>
        ///     The RGB values are the same,
        ///     just the Alpha is set to <see langword="255.0f" />.
        /// </returns>
        public static Color ToOpaque(this Color color)
        {
            return new Color(color.r, color.g, color.b, 1.0f);
        }

        /// <summary>
        ///     Make a color transparent.
        /// </summary>
        /// <param name="color">The current color to convert.</param>
        /// <returns>
        ///     The RGB values are the same,
        ///     just the Alpha is set to <see langword="0.0f" />.
        /// </returns>
        public static Color ToTransparent(this Color color)
        {
            return new Color(color.r, color.g, color.b, 0.0f);
        }
    }
}
