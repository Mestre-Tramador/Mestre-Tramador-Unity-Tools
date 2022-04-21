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
    ///     All modes (limit) of jumps a Character can have.
    /// </summary>
    public enum JumpModes
    {
        /// <summary>It cannot jump.</summary>
        NoJump = 0,

        /// <summary>It can do a single jump.</summary>
        OneJump = 1,

        /// <summary>It can do an extra jump, apart from the first.</summary>
        DoubleJump = 2
    }
}
