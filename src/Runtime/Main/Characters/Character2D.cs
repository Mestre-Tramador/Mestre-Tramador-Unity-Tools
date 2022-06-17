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
    ///     All 2D Characters are extensions of this base class.
    /// </summary>
    public abstract class Character2D : BaseMonoBehaviour, CharacterControls, HasBody2D
    {
        #region Controls
        /// <inheritdoc />
        public bool CanMove { get; set; }

        /// <inheritdoc />
        public bool CanJump { get; set; }

        /// <inheritdoc />
        public bool CanShoot { get; set; }
        #endregion

        #region Body
        #pragma warning disable CS8618
        /// <inheritdoc />
        public Character2DCollider Collider
        {
            get
            {
                if(_collider == null)
                {
                    _collider = GetComponent<Character2DCollider>();
                }

                return _collider;
            }
            private set => _collider = value;
        }

        /// <summary>
        ///     Holds the Component reference.
        /// </summary>
        private Character2DCollider _collider;

        /// <inheritdoc />
        public Rigidbody2D Body { get; private set; }
        #pragma warning restore CS8618
        #endregion

        #region Movement
        /// <inheritdoc />
        public float Speed { get; set; }

        /// <inheritdoc />
        public Directions2D IsTurnedTo { get => transform.localScale.x > 0 ? Directions2D.Right : Directions2D.Left; }

        /// <inheritdoc />
        public void Turn()
        {
            transform.localScale = transform.localScale.InvertX();

            Body.velocity = Vector2.zero;
        }
        #endregion

        #region Jump
        /// <inheritdoc />
        public float Force { get; set; }

        /// <inheritdoc />
        public JumpModes JumpMode
        {
            get => _jumpMode;
            set => _jumpMode = value;
        }

        /// <summary>
        ///     Serialize the Jump Mode.
        /// </summary>
        [SerializeField]
        private JumpModes _jumpMode;

        /// <inheritdoc />
        public int Jumps
        {
            get => _jumps;
            set
            {
                if(!CanJump || JumpMode == JumpModes.NoJump)
                {
                    _jumps = 0;

                    return;
                }

                _jumps = value;

                bool canNextJump = _jumps < (int) JumpMode;

                if(!canNextJump && JumpMode != JumpModes.NoJump)
                {
                    CanJump = false;
                }
            }
        }

        /// <summary>
        ///     Counting of the Character's jumps.
        /// </summary>
        private int _jumps;
        #endregion

        #region Behaviour
        /// <summary>
        ///      On Awake, all properties are defined to default values.
        /// </summary>
        protected override void OnAwake()
        {
            Body = GetComponent<Rigidbody2D>();

            Collider = GetComponent<Character2DCollider>();

            CanMove = true;
            CanJump = true;
            CanShoot = false;

            Force = 0.0f;
            Speed = 0.0f;

            Jumps = 0;
        }

        /// <summary>
        ///     On Reset, a <see cref="Rigidbody2D" /> and a <see cref="Character2DCollider" />
        ///     components are added by default (if not already present), and the basic constraints
        ///     are also set.
        /// </summary>
        protected override void OnReset()
        {
            Body = gameObject.AddComponentIfNotExist<Rigidbody2D>();

            Body.constraints = RigidbodyConstraints2D.FreezeRotation;
            Body.hideFlags = HideFlags.HideInInspector;

            Collider = gameObject.AddComponentIfNotExist<Character2DCollider>();

            JumpMode = JumpModes.NoJump;
        }
        #endregion
    }
}
