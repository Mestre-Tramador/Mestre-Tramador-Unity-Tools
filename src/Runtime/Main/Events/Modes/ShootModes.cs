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
    ///     All modes (ways) of shoots a Shooter Character can use.
    /// </summary>
    public enum ShootModes
    {
        /// <summary>It cannot shoots.</summary>
        NoShoot = 0,

        /// <summary>It shoots in a single click.</summary>
        SingleClickShoot = 1,

        /// <summary>It shoots while clicking.</summary>
        HoldClickShoot = 2
    }
}
