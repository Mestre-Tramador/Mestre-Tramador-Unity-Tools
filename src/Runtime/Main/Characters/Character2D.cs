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
    ///     All 2D Characters are extensions of this base class.
    /// </summary>
    public abstract class Character2D : BaseMonoBehaviour, CharacterControls, HasBody2D
    {
        #region Controls
        /// <inheritdoc />
        public bool CanMove { get; protected set; }

        /// <inheritdoc />
        public bool CanJump { get; protected set; }
        #endregion

        #region Body
        #pragma warning disable CS8618
        /// <inheritdoc />
        public Collider2D Collider { get; private set; }

        /// <inheritdoc />
        public Rigidbody2D Body { get; private set; }
        #pragma warning restore CS8618
        #endregion

        #region Movement
        /// <inheritdoc />
        public float Speed { get; protected set; }

        /// <inheritdoc />
        public Directions2D IsTurnedTo { get => gameObject.transform.localScale.x > 0 ? Directions2D.Right : Directions2D.Left; }

        /// <inheritdoc />
        public void Turn()
        {
            gameObject.transform.localScale = gameObject.transform.localScale.InvertX();

            Body.velocity = Vector2.zero;
        }
        #endregion

        #region Jump
        /// <inheritdoc />
        public float Force { get; protected set; }

        /// <inheritdoc />
        public JumpModes JumpMode { get; protected set; }

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

                CanJump = _jumps < ((int) JumpMode);

                Jumps = 0;
            }
        }

        /// <summary>
        ///     Counting of the Character's jumps.
        /// </summary>
        private int _jumps;
        #endregion

        #region Behaviour
        /// <summary>
        ///  On Awake, all properties are defined to default values.
        /// </summary>
        protected override void OnAwake()
        {
            Body     = gameObject.GetComponent<Rigidbody2D>();
            Collider = gameObject.GetComponent<BoxCollider2D>();

            Force = 0.0f;
            Speed = 0.0f;

            Jumps = 0;

            JumpMode = JumpModes.NoJump;

            CanMove = true;
            CanJump = true;
        }

        /// <summary>
        ///     On Reset, a <see cref="Rigidbody2D" /> and a <see cref="BoxCollider2D" />
        ///     components are added by default (if not already present), and the basic constraints
        ///     are also set.
        /// </summary>
        protected override void OnReset()
        {
            Rigidbody2D body = gameObject.AddComponentIfNotExist<Rigidbody2D>();

            gameObject.AddComponentIfNotExist<BoxCollider2D>();

            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        #endregion
    }
}
