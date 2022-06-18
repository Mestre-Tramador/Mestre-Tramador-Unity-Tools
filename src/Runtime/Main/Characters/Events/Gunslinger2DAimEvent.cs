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
    ///     The Shoot Event, as the name suggests, refers to any aiming on a Behaviour.
    /// </summary>
    sealed public partial class AimEvent : Event
    {
        /// <summary>
        ///     If the 2D Gunslinger can aim, then the mode defines how it
        ///     is shown on screen.
        /// </summary>
        /// <param name="gunslinger">The instance of the Gunslinger.</param>
        private void OnAimGunslinger2D(Gunslinger2D gunslinger)
        {
            if(!gunslinger.CanAim || gunslinger.AimMode == ShootAimModes.NoAim)
            {
                return;
            }
        
            // TODO: Handle Aim Mode.            
            
            switch(gunslinger.AimMode)
            {
                case ShootAimModes.HoldClickAim:
                    if(Input.GetKey(KeyCode.LeftShift))
                    {
                        gunslinger.ShowCrosshair();

                        return;
                    }

                    gunslinger.HideCrosshair();
                break;
            }
        }        
    }
}