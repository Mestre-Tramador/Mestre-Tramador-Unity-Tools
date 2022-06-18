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
    ///     All modes (ways) of aiming a Shooter Character can use.
    /// </summary>
    public enum ShootAimModes
    {
        /// <summary>It cannot aim.</summary>
        NoAim = 0,

        /// <summary>It aims in a single click.</summary>
        SingleClickAim = 1,

        /// <summary>It aims while clicking.</summary>
        HoldClickAim = 2,

        /// <summary>It aims with directional controls.</summary>
        SmoothAim = 3,

        /// <summary>The aim is the POV of the Shooter Character.</summary>
        POVAim = 4,

        /// <summary>The aim is the Cursor.</summary>
        MouseAim = 5
    }
}
