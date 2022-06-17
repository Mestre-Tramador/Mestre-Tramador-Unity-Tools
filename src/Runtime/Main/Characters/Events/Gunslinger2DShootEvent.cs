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
    ///     The Shoot Event, as the name suggests, refers to any shooting on a Behaviour.
    /// </summary>
    sealed public partial class ShootEvent : Event
    {
        /// <summary>
        ///     If the 2D Gunslinger can shoot, then the <see cref="ShooterCharacter2D.HasAmmoLimit" />
        ///     is verified alongside the <see cref="ShooterCharacter2D.Ammo" />, and if everything is
        ///     OK, a <see cref="BulletShot" /> is instantiated.
        /// </summary>
        /// <param name="gunslinger">The instance of the Gunslinger.</param>
        private void OnShootGunslinger2D(Gunslinger2D gunslinger)
        {
            if(!gunslinger.CanShoot || gunslinger.ShootMode == ShootModes.NoShoot)            
            {
                return;
            }

            // TODO: Handle Shoot Mode.

            if(!gunslinger.HasAmmoLimit || (gunslinger.HasAmmoLimit && gunslinger.Ammo > 0 && gunslinger.Ammo <= gunslinger.MaxAmmo))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    gunslinger.Ammo--;
                    
                    GameObject bullet = GameObject.Instantiate(
                        gunslinger.Shot,
                        gunslinger.transform.position,
                        gunslinger.transform.rotation
                    );

                    bullet.GetComponent<BulletShot>().ShooterCharacter = gunslinger;
                }
            }
        }
    }
}