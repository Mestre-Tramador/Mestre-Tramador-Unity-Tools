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
    ///     A 2D Gunslinger is a Player who shots bullets quickly controlled by the User.
    /// </summary>
    public class Gunslinger2D : ShooterCharacter2D
    {
        /// <summary>
        ///     As usually the maximum ammunition of a revolver.
        /// </summary>
        public const int MAX_AMMO = 6;

        /// <summary>
        ///     Solely the event is fired.
        /// </summary>
        protected override void OnShoot()
        {
            E.Use<ShootEvent>(this);
        }

        /// <inheritdoc />
        /// <remarks>
        ///     A 2D Gunslinger also set:
        ///     <list type="bullet">
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.Ammo" /></term>
        ///            <description><see langword="0" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.MaxAmmo" /></term>
        ///            <description><see cref="MAX_AMMO" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.HasAmmoLimit" /></term>
        ///            <description><see langword="true" /></description>
        ///         </item>
        ///     </list>
        /// </remarks>
        protected override void OnAwake()
        {
            base.OnAwake();

            Ammo = 0;
            MaxAmmo = MAX_AMMO;
            HasAmmoLimit = true;

            Shot = Resources.Load<GameObject>("Packages/io.github.mestretramador.tools/Prefabs/Shots/BulletShot");
        }

        /// <summary>
        ///     When reseting, the Shoot and Aim modes are set to:
        ///     <list type="bullet">
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.ShootMode" /></term>
        ///            <description><see cref="ShootModes.SingleClickShoot" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.AimMode" /></term>
        ///            <description><see cref="ShootAimModes.HoldClickAim" /></description>
        ///         </item>
        ///     </list>
        /// </summary>
        protected override void OnReset()
        {
            base.OnReset();

            ShootMode = ShootModes.SingleClickShoot;

            AimMode = ShootAimModes.HoldClickAim;
        }
    }
}
