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
    ///     Assign a Character with a 2D Body and all it constraints.
    /// </summary>
    public interface HasBody2D
    {
        #region Body
        /// <summary>
        ///     The Collider defines the shape, or hitbox if you will, of the Character.
        /// </summary>
        /// <value>
        ///     Its a proper Component with a <see cref="Character2DCollider.Type" /> to
        ///     determine the shape.
        /// </value>
        Character2DCollider Collider { get; }

        /// <summary>
        ///     The Body creates the physics of the Character and is necessary to create
        ///     all the movement, jumps, and cinetic interactions.
        /// </summary>
        /// <value>
        ///     The only constraint initially set is the
        ///     <see cref="RigidbodyConstraints2D.FreezeRotation" />.
        /// </value>
        Rigidbody2D Body { get; }
        #endregion

        #region Movement
        /// <summary>
        ///     Recommended minimum value of <see cref="Speed" />.
        /// </summary>
        public const float MIN_SPEED = 2.0f;

        /// <summary>
        ///     Recommended maximum value of <see cref="Speed" />.
        /// </summary>
        public const float MAX_SPEED = 5.0f;

        /// <summary>
        ///     Determines the speed of the Character's movement.
        /// </summary>
        /// <value>
        ///     Generally it stays on a scale of <see langword="2.0f" />
        ///     to <see langword="5.0f" />.
        /// </value>
        float Speed { get; }

        /// <summary>
        ///     Indicates the direction the Character is facing.
        /// </summary>
        /// <value>
        ///     Currently it only can be <see cref="Directions2D.Right" /> of
        ///     <see cref="Directions2D.Left" />, as it is a 2D context.
        /// </value>
        Directions2D IsTurnedTo { get; }

        /// <summary>
        ///     Turn the Character to its oposite direction, also resetting its Body's velocity.
        /// </summary>
        void Turn();
        #endregion

        #region Jump
        /// <summary>
        ///     Recommended minimum value of <see cref="Force" />.
        /// </summary>
        public const float MIN_FORCE = 250.0f;

        /// <summary>
        ///     Recommended maximum value of <see cref="Force" />.
        /// </summary>
        public const float MAX_FORCE = 400.0f;

        /// <summary>
        ///     Determines the force of the Character's jump.
        /// </summary>
        /// <value>
        ///     Generally, as it represent force, it stays on a scale of
        ///     <see langword="250.0f" /> to <see langword="400.0f" />.
        /// </value>
        float Force { get; }

        /// <summary>
        ///     Determine the mode of the Character's jumps.
        /// </summary>
        /// <value>
        ///     It can also be converted to the <see langword="int" /> limit of jumps.
        /// </value>
        JumpModes JumpMode { get; }

        /// <summary>
        ///     Store and handle the count of the Character's jumps.
        /// </summary>
        /// <value>
        ///     If the Character cannot jump by any motive, it is allways <see langword="0" />,
        ///     otherwise it is the current count.
        /// </value>
        int Jumps { get; }
        #endregion
    }
}
