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

namespace MestreTramador
{
    /// <summary>
    ///     Lists all shapes, or types, a <see cref="Character2DCollider" /> can assume.
    /// </summary>
    public enum Character2DColliders
    {
        /// <summary>
        ///     Represent a <see cref="UnityEngine.BoxCollider2D" />.
        /// </summary>
        Box = 0,

        /// <summary>
        ///     Represent a <see cref="UnityEngine.CircleCollider2D" />.
        /// </summary>
        Circle = 1,

        /// <summary>
        ///     Represent a <see cref="UnityEngine.CapsuleCollider2D" />.
        /// </summary>
        Capsule = 2
    }
}
