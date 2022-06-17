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
    ///     A Bullet Shot is a shot who travel to a single direction
    ///     quickly, ending only when reach some collision or the
    ///     end of screen.
    /// </summary>
    public class BulletShot : Shot
    {
        /// <summary>
        ///     On Start, the direction of the Bullet is set,
        ///     and so the movement.
        /// </summary>
        protected override void OnStart()
        {
            Vector2 vector = transform.right;            

            if(ShooterCharacter.IsTurnedTo == Directions2D.Left)
            {                
                vector = vector.InvertX();                
            }

            Body.velocity = vector * 20.0f;
        }

        /// <summary>
        ///     On Update, if the Bullet is not visible
        ///     to the camera, it is uninstantiated.
        /// </summary>
        protected override void OnUpdate()
        {
            if(!Camera.main.IsVisibleInViewPort(transform))
            {
                Destroy(gameObject);
            }
        }
      
        /// <summary>
        ///     On Reset, nothing occurs.
        /// </summary>
        protected override void OnReset() { }
    }
}