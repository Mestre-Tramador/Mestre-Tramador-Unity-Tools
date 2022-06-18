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
    ///     A Controller to act alongside Unity's <see cref="Camera" />.
    /// </summary>
    public class CameraController : Controller
    {               
        /// <summary>
        ///     An offset from the player's current position.
        /// </summary>
        /// <value>It defined only once.</value>
        private Vector3 Offset { get; set; }
       
        /// <inheritdoc />
        public override CameraControllerModes ModeValue<CameraControllerModes>()
        {
            return base.ModeValue<CameraControllerModes>();
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Also, the offset from the player is calculated and defined.
        /// </remarks>
        protected override void OnAwake()
        {
            base.OnAwake();

            Offset = transform.position - Player.transform.position;

            Mode = (int) CameraControllerModes.Following;
        }

        /// <summary>
        ///     On update, the Controller starts to manipulate
        ///     the camera according to the mode.
        /// </summary>
        protected override void OnUpdate()
        {            
            switch(ModeValue<CameraControllerModes>())
            {
                case CameraControllerModes.Static:
                return;

                case CameraControllerModes.Following:
                    transform.position = Player.transform.position + Offset;
                return;
            }
        }

        /// <summary>
        ///     On every resetation, the Mode is set to
        ///     <see cref="CameraControllerModes.Static" />.
        /// </summary>
        protected override void OnReset()
        {
            Mode = (int) CameraControllerModes.Static;
        }
    }
}