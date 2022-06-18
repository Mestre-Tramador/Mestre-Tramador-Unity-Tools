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

using System;
using UnityEngine;

namespace MestreTramador
{
    /// <summary>
    ///     A Controller is a class that handle in game mechanics.
    ///     All controllers extends from this base class.
    /// </summary>
    public abstract class Controller : BaseMonoBehaviour
    {
        /// <summary>
        ///     The Player whose is in control.
        /// </summary>
        /// <value>
        ///     The Game Object is present on the scene
        ///     and may have various components.
        /// </value>
        protected GameObject Player { get; private set; }
        
        /// <summary>
        ///     It defines the actions of the Controller.
        /// </summary>
        /// <value>
        ///     The integer value matches a Enumeration
        ///     used on a child class.
        /// </value>
        protected int Mode { get; set; }
        
        /// <summary>
        ///     A conversion of the Mode th the Enumeration index.
        /// </summary>
        /// <typeparam name="M">It is an Enum.</typeparam>
        /// <returns>The parsed Enum index.</returns>
        public virtual M ModeValue<M>()
        {
            return (M) Enum.Parse(typeof(M), Mode.ToString());
        }

        /// <summary>
        ///     On Awake, the current Player of the scene is defined.
        /// </summary>
        protected override void OnAwake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}