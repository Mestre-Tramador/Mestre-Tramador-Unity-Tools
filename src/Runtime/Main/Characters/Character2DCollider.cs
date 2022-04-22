#region License
// This is a ClassLib to help Unity Developers, Game Designers or Students.
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
    ///     All 2D Characters can have one out of three primitive 2D Colliders.
    /// </summary>
    public class Character2DCollider : BaseMonoBehaviour
    {
        #region Type
        /// <summary>
        ///     Determines the "shape" of the Collider component.
        /// </summary>
        /// <value>The Type allways matches with the <see cref="Component" />.</value>
        /// <seealso cref="Character2DColliders"/>
        public Character2DColliders Type
        {
            get
            {
                if(_type == null)
                {
                    _type = Get();
                }

                return (Character2DColliders) _type;
            }
            set
            {
                _type = value;

                switch(_type)
                {
                    case Character2DColliders.Box:
                        Component = gameObject.AddComponentIfNotExist<BoxCollider2D>();
                    return;

                    case Character2DColliders.Circle:
                        Component = gameObject.AddComponentIfNotExist<CircleCollider2D>();
                    return;

                    case Character2DColliders.Capsule:
                        Component = gameObject.AddComponentIfNotExist<CapsuleCollider2D>();
                    return;
                }
            }
        }

        #nullable enable
        /// <summary>
        ///      Serialize the Type.
        /// </summary>
        [SerializeField]
        private Character2DColliders? _type;
        #nullable disable
        #endregion

        #region Collider
        /// <summary>
        ///     A Unity Component Collider2D matching with the <see cref="Type" />.
        /// </summary>
        /// <value>There is allways one Component per Character.</value>
        public Collider2D Component
        {
            get => _component;
            private set
            {
                Collider2D component = GetComponent<Collider2D>();

                if(_component == null && value != component)
                {
                    _component = component;
                }

                if(_component != null)
                {
                    DestroyImmediate(_component);

                    Component = value;

                    return;
                }

                _component = value;

                _component.hideFlags = HideFlags.HideInInspector;
            }
        }

        /// <summary>
        ///     Holds the Component reference.
        /// </summary>
        private Collider2D _component;
        #endregion

        #region Properties
        /// <summary>
        ///     A simple check to determine if a Collider exists.
        /// </summary>
        /// <value>It return <see langword="true" /> if any is attached.</value>
        public bool Has
        {
            get => (
                GetComponent<BoxCollider2D>()    ||
                GetComponent<CircleCollider2D>() ||
                GetComponent<CapsuleCollider2D>()
            );
        }
        #endregion

        #region Auxiliar Methods
        /// <summary>
        ///     Get the Type by the current attached Component.
        /// </summary>
        /// <returns>If no matches were found, then it returns the <see cref="Character2DColliders.Box" /></returns>
        private Character2DColliders Get()
        {
            if(TryGetComponent<BoxCollider2D>(out BoxCollider2D box))
            {
                return Character2DColliders.Box;
            }
            else if(TryGetComponent<CircleCollider2D>(out CircleCollider2D circle))
            {
                return Character2DColliders.Circle;
            }
            else if(TryGetComponent<CapsuleCollider2D>(out CapsuleCollider2D capsule))
            {
                return Character2DColliders.Capsule;
            }

            return Character2DColliders.Box;
        }
        #endregion

        #region Behaviour
        /// <summary>
        ///     On Awake, the Type is got.
        /// </summary>
        protected override void OnAwake()
        {
            Type = Get();
        }

        /// <summary>
        ///     On Reset, the Type is set to a default value
        ///     if it has none and some constraints are set.
        /// </summary>
        protected override void OnReset()
        {
            if(!Has)
            {
                Type = Character2DColliders.Box;
            }

            hideFlags = HideFlags.HideInInspector;
        }

        /// <summary>
        ///     Currently it does nothing On Update.
        /// </summary>
        protected override void OnUpdate() { }
        #endregion
    }
}
