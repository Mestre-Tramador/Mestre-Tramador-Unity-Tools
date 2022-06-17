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
    ///     All 2D Players who are Shooters are extensions of this base class.
    /// </summary>
    public abstract class ShooterCharacter2D : Player2D, IsShooter2D, UseEvent<ShootEvent, ShooterCharacter2D>
    {
        #region Shooting
        /// <inheritdoc />
        public GameObject Shot { get; protected set; }

        /// <inheritdoc />
        public ShootModes ShootMode { get; protected set; }

        /// <inheritdoc />
        public ShootAimModes AimMode { get; protected set; }

        /// <inheritdoc />
        public bool HasAmmoLimit { get; protected set; }

        #nullable enable    
        /// <inheritdoc />
        public int? Ammo { get; set; }

        /// <inheritdoc />
        public int? MaxAmmo { get; set; }

        /// <inheritdoc />
        public float? Strength { get; protected set; }

        /// <inheritdoc />
        public GameObject? Crosshair { get; protected set; }
        #nullable disable
    
        /// <summary>
        ///     The shooter point where all shots are fired.
        /// </summary>
        /// <value>
        ///     This reference is of a Game Object present on the scene,
        ///     and also a child of the one holding this script.
        /// </value>
        protected GameObject Shooter { get; private set; }
        #endregion

        #region Events
        /// <summary>
        ///     The Shoot Event Caller.
        /// </summary>
        /// <value>
        ///     It's a simple casting for the <see langword="interface" />.
        /// </value>
        protected UseEvent<ShootEvent, ShooterCharacter2D> E { get => this; }
        #endregion

        #region Behaviour
        /// <summary>
        ///     What shall occur on the Shoot event,
        ///     ran <see cref="BaseMonoBehaviour.OnUpdate()" />.
        /// </summary>
        protected abstract void OnShoot();

        /// <summary>
        ///     Alongside the base definitions, all Shooter 2D Characters
        ///     set the following values:
        ///     <list type="bullet">
        ///         <item>
        ///            <term><see cref="Character2D.CanShoot" /></term>
        ///            <description><see langword="true" /></description>
        ///         </item>
        ///     </list>
        /// </summary>
        protected override void OnAwake()
        {
            base.OnAwake();

            CanShoot = true;

            Shooter = GameObject.Find($"{gameObject.name}/Shooter");
        }

        /// <inheritdoc />
        protected override void OnUpdate()
        {
            base.OnUpdate();

            OnShoot();
        }        

        /// <summary>
        ///     Alongside all base resetations, a <see cref="Shooter" />
        ///     reference is created if none child Game Object was found.
        /// </summary>
        protected override void OnReset()
        {
            base.OnReset();

            if(!gameObject.HasChild("Shooter"))
            {
                Shooter = CreateShooterPoint();

                #if UNITY_EDITOR
                    Debug.LogWarning($"Created shooter point for the {gameObject.name}!");
                #endif
            }
        }        
        #endregion

        #region Creation
        /// <summary>
        ///     Create a simple and blank Object to use as
        ///     a reference for the <see cref="Shooter" />
        ///     point.
        /// </summary>
        /// <returns>
        ///     The new instance comes already positioned
        ///     relatively to the parent Game Object.
        /// </returns>
        private GameObject CreateShooterPoint()
        {
            GameObject shooter = new GameObject("Shooter");

            shooter.transform.parent = transform;

            shooter.transform.localPosition = new Vector3(0.5f, 0.25f, 0.0f);

            return shooter;
        }
        #endregion
    }
}