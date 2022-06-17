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
    ///     Assign a Characters as a 2D Shooter.
    /// </summary>
    public interface IsShooter2D
    {
        #region Core
        /// <summary>
        ///     The Object (Bullet, Arrow, others...) that is shot.
        /// </summary>
        /// <value>
        ///     It serves more as reference than an actual scene Game Object.
        /// </value>
        GameObject Shot { get; }

        /// <summary>
        ///     Determine the mode of the Shooter's shots.
        /// </summary>
        /// <value>
        ///     It can also determine the Shooter's controls.
        /// </value>
        ShootModes ShootMode { get; }

        /// <summary>
        ///     Determine the mode of the Shooter's aiming.
        /// </summary>
        /// <value>
        ///     It can also determine the Shooter's controls.
        /// </value>
        ShootAimModes AimMode { get; }
        #endregion
        
        #region Config
        /// <summary>
        ///     Configure if the Shooter as a limit of <see cref="Ammo" />.
        /// </summary>
        /// <value>
        ///     A <see langword="true" /> value determine that
        ///     the ammunition is finite.
        /// </value>
        bool HasAmmoLimit { get; }
        #endregion

        #region Extras
        #nullable enable     
        /// <summary>
        ///     Act as the current ammo.
        /// </summary>
        /// <value>
        ///     It is <see langword="nullable" /> in cases that
        ///     the Shooter does not have a ammunition limit. 
        /// </value>   
        int? Ammo { get; }

        /// <summary>
        ///     Act as the maximum ammo possible to have.
        /// </summary>
        /// <value>
        ///     It is <see langword="nullable" /> in cases that
        ///     the Shooter does not have a ammunition limit. 
        /// </value>   
        int? MaxAmmo { get; }

        /// <summary>        
        ///     Is the current strength using to make a shot.
        ///     <br />
        ///     Generally is used on the
        ///     <see cref="ShootModes.HoldClickShoot" /> mode.
        /// </summary>
        /// <value>
        ///     Depending on the <see cref="ShootMode" />, it
        ///     can be <see langword="null" />.
        /// </value>
        float? Strength { get; }

        /// <summary>
        ///     The crosshair used for aiming.
        /// </summary>
        /// <value>
        ///     It serves more as reference than an actual
        ///     scene Game Object, but also <see langword="null" />
        ///     if the <see cref="AimMode" /> prevents having a crosshair.
        /// </value>
        GameObject? Crosshair { get; }               
        #nullable disable        
        #endregion
    }
}
