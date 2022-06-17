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
    ///     Extend the use of the <see cref="Camera" />
    ///     class into smart functions.
    /// </summary>
    public static class SmartCamera
    {
        /// <inheritdoc cref="SmartCamera.IsVisibleInViewPort(Camera, Vector3)" />
        /// <param name="transform">A Transform of a Game Object with a position.</param>
        public static bool IsVisibleInViewPort(this Camera camera, Transform transform)
        {
            return camera.IsVisibleInViewPort(transform.position);
        }

        /// <summary>
        ///     Check if a position is invisible to the Camera.
        /// </summary>
        /// <param name="camera">The Camera in use.</param>
        /// <param name="position">The vector which corresponds to the position.</param>
        /// <returns>It returns <see langword="true" /> if the position is outside the Camera viewport bounds.</returns>
        public static bool IsVisibleInViewPort(this Camera camera, Vector3 position)
        {
            Vector3 vector = camera.WorldToViewportPoint(position);

            return (vector.x >= 0.0f && vector.x <= 1.0f && vector.y >= 0.0f && vector.y <= 1.0f && vector.z > 0.0f);
        }
    }
}