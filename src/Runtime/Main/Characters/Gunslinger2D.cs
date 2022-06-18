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
        ///     Set the <see cref="ShooterCharacter2D.Crosshair" /> as invisible.
        /// </summary>
        /// <seealso cref="SetCrosshair(bool)" />
        public void HideCrosshair()
        {
            SetCrosshair(false);
        }

        /// <summary>
        ///     Set the <see cref="ShooterCharacter2D.Crosshair" /> as visible.
        /// </summary>
        /// <seealso cref="SetCrosshair(bool)" />
        public void ShowCrosshair()
        {
            SetCrosshair(true);
        }

        /// <summary>
        ///     Solely the aim event is fired.
        /// </summary>
        protected override void OnAim()
        {
            Ea.Use<AimEvent>(this);
        }

        /// <summary>
        ///     Solely the shoot event is fired.
        /// </summary>
        protected override void OnShoot()
        {
            Es.Use<ShootEvent>(this);
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
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.ShootMode" /></term>
        ///            <description><see cref="ShootModes.SingleClickShoot" /></description>
        ///         </item>
        ///         <item>
        ///            <term><see cref="ShooterCharacter2D.AimMode" /></term>
        ///            <description><see cref="ShootAimModes.HoldClickAim" /></description>
        ///         </item>
        ///     </list>
        /// </remarks>
        protected override void OnAwake()
        {
            base.OnAwake();

            Ammo = 0;
            MaxAmmo = MAX_AMMO;
            HasAmmoLimit = true;

            ShootMode = ShootModes.SingleClickShoot;
            AimMode = ShootAimModes.HoldClickAim;

            Shot = Resources.Load<GameObject>("Packages/io.github.mestretramador.tools/Prefabs/Shots/BulletShot");
            Crosshair =  GameObject.Find($"{gameObject.name}/Aim");
        }

        /// <summary>
        ///     Alongside all base resetations, a <see cref="ShooterCharacter2D.Crosshair" />
        ///     reference is created if none child Game Object was found.
        /// </summary>
        protected override void OnReset()
        {
            base.OnReset();

            if(!gameObject.HasChild("Aim"))
            {
                Crosshair = CreateAimCrossHair();

                #if UNITY_EDITOR
                    Debug.LogWarning($"Created aim crosshair point for the {gameObject.name}!");
                #endif
            }
        }

        /// <summary>
        ///     If present, the visibility of the crosshair is defined.
        /// </summary>
        /// <param name="visibility">A <see langword="true" /> value define as visible.</param>
        private void SetCrosshair(bool visibility)
        {
            SpriteRenderer sprite = Crosshair?.GetComponent<SpriteRenderer>();

            if(sprite)
            {
                sprite.color = visibility ? sprite.color.ToOpaque() : sprite.color.ToTransparent();
            }
        }

        /// <summary>
        ///     Create a simple and blank Object to use as
        ///     a reference for the
        ///     <see cref="ShooterCharacter2D.Crosshair" />
        /// </summary>
        /// <returns>
        ///     The new instance comes already positioned
        ///     relatively to the parent Game Object and
        ///     with a <see cref="SpriteRenderer" />.
        /// </returns>
        private GameObject CreateAimCrossHair()
        {
            GameObject crosshair = new GameObject("Aim");

            crosshair.transform.parent = transform;

            crosshair.transform.localPosition = new Vector3(4.0f, 0.25f, 0.0f);

            SpriteRenderer sprite = crosshair.AddComponent<SpriteRenderer>();

            sprite.color = sprite.color.ToTransparent();

            return crosshair;
        }
    }
}
