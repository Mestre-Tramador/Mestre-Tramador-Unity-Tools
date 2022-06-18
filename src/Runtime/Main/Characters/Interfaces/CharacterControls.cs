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
    ///     All Characters have controls that determine the Events they shall use.
    /// </summary>
    public interface CharacterControls
    {
        /// <summary>
        ///     Determines if the Character can execute a <see cref="MoveEvent" />.
        /// </summary>
        /// <value>
        ///     Internally, <see langword="true" /> indicates that the Character can move.
        /// </value>
        bool CanMove { get; }

        /// <summary>
        ///     Determines if the Character can execute a <see cref="JumpEvent" />.
        /// </summary>
        /// <value>
        ///     Internally, <see langword="true" /> indicates that the Character can jump.
        /// </value>
        bool CanJump { get; }

        /// <summary>
        ///     Determines if the Character can execute a <see cref="ShootEvent" />.
        /// </summary>
        /// <value>
        ///     Internally, <see langword="true" /> indicates that the Character can shoot.
        /// </value>
        bool CanShoot { get; }

        /// <summary>
        ///     Determines if the Character can execute a <see cref="AimEvent" />.
        /// </summary>
        /// <value>
        ///     Internally, <see langword="true" /> indicates that the Character can aim.
        /// </value>
        bool CanAim { get; }
    }
}
