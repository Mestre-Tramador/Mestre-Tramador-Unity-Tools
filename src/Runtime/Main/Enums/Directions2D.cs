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
    ///     All Directions a Character can face on a 2D scene.
    /// </summary>
    public enum Directions2D
    {
        /// <summary>Is facing the Left side.</summary>
        Left = -1,

        /// <summary>Is facing the Right side.</summary>
        Right = 1,

        /// <summary>Technically, is facing you.</summary>
        FourthWall = 4,

        /// <summary>Technically, it turned its back on you.</summary>
        Back = 0
    }
}
