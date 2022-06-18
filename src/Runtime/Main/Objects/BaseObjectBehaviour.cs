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
    ///     All Objects (props) are extensions of this base class.
    /// </summary>
    public abstract class BaseObjectBehaviour : BaseMonoBehaviour
    {
        // TODO: Create BaseObject2D class and isObject2D interface.

        #nullable enable
        /// <summary>
        ///     The Body creates the physics of the Object and is necessary
        ///     to create all the movement, jumps, and cinetic interactions.
        /// </summary>
        /// <value>It comes as the Prefab.</value>
        protected Rigidbody2D? Body { get; private set; }

        /// <summary>
        ///     The Collider defines the shape, or hitbox if you will,
        ///     of the Object.
        /// </summary>
        /// <value>It comes as the Prefab.</value>
        protected Collider2D? Collider { get; private set; }
        #nullable disable

        /// <summary>
        ///     What shall occur on the Start method, ran on the
        ///     initialization of the script.
        /// </summary>
        protected abstract void OnStart();

        /// <summary>
        ///      On Awake, all properties are defined to default values.
        /// </summary>
        protected override void OnAwake()
        {
            Body = GetComponent<Rigidbody2D>();
            Collider = GetComponent<Collider2D>();
        }

        /// <summary>
        ///     Start is called on the frame when a script is enabled
        ///     just before any of the Update methods are called the first time.
        /// </summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html" />
        private void Start()
        {
            OnStart();
        }
    }
}
