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
    ///     BaseMonoBehaviour is a class which extends <see cref="MonoBehaviour" /> and
    ///     add abstractions to guarantee certain triggers.
    /// </summary>
    public abstract class BaseMonoBehaviour : MonoBehaviour
    {
        /// <summary>
        ///     What shall occur on the Awake method, ran on the
        ///     start of the script.
        /// </summary>
        protected abstract void OnAwake();

        /// <summary>
        ///     What shall occur on the Update method, ran continuosly
        ///     on the script runtime.
        /// </summary>
        protected abstract void OnUpdate();

        /// <summary>
        ///     What shall occur on the Reset method, ran on the
        ///     addition or resetion of the script.
        /// </summary>
        protected abstract void OnReset();

        /// <summary>
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html" />
        private void Awake()
        {
            OnAwake();
        }

        /// <summary>
        ///     Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html" />
        private void Update()
        {
            OnUpdate();
        }

        /// <summary>
        ///     Reset is called when the user hits the Reset button in the Inspector's context menu
        ///     or when adding the component the first time.
        /// </summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/MonoBehaviour.Reset.html" />
        private void Reset()
        {
            OnReset();
        }
    }
}
