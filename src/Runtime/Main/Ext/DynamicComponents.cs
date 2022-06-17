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
    ///     Extend the average use of the <see cref="Component" />
    ///     classes to be more dynamic.
    /// </summary>
    public static class DynamicComponents
    {
        /// <summary>
        ///     Check if the current object has a child with a specific name.
        /// </summary>
        /// <param name="gObj">The instanced Game Object.</param>
        /// <param name="childName">Any acceptable name.</param>
        /// <returns>If an Game Object is found, then returns <see langword="true" />.</returns>
        public static bool HasChild(this GameObject gObj, string childName)
        {
            return GameObject.Find($"{gObj.name}/{childName}");
        }

        /// <summary>
        ///     Check if the current object has attached a specific <see cref="Component" />.
        /// </summary>
        /// <param name="gObj">The instanced Game Object.</param>
        /// <typeparam name="C">Any attachable <see cref="Component" /> can be checked.</typeparam>
        /// <returns>
        ///     If the <see cref="Component" /> is attached, then returns <see langword="true" />.
        /// </returns>
        public static bool HasComponent<C>(this GameObject gObj) where C : Component
        {
            return gObj.GetComponent<C>();
        }

        /// <summary>
        ///     Attach a specific <see cref="Component" /> to the current object.
        /// </summary>
        /// <param name="gObj">The instanced Game Object.</param>
        /// <typeparam name="C">
        ///     Any attachable <see cref="Component" /> can be attached,
        ///     if it is not already.
        /// </typeparam>
        /// <returns>
        ///     If the <see cref="Component" /> is already attached,
        ///     then returns itself, otherwise the new instance is returned.
        /// </returns>
        public static C AddComponentIfNotExist<C>(this GameObject gObj) where C : Component
        {
            if(!gObj.HasComponent<C>())
            {
                return gObj.AddComponent<C>();
            }

            return gObj.GetComponent<C>();
        }
    }
}
