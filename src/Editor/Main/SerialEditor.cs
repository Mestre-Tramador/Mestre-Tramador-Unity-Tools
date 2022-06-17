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

using System.Collections.Generic;
using UnityEditor;
using UEditor = UnityEditor.Editor;

namespace MestreTramador.Editor
{
    /// <summary>
    ///     All custom Editors derives from this class to facilitate Serialization.
    /// </summary>
    public abstract class SerialEditor : UEditor
    {
        #pragma warning disable CS8618
        /// <summary>
        ///     The serialized <see cref=" UEditor.target" /> of the Editor.
        /// </summary>
        /// <value>The state of the target can be changed, not its reference.</value>
        protected SerializedObject SerialTarget { get; private set; }

        /// <summary>
        ///     All the serialized properties of the current serialized <see cref=" UEditor.target" />.
        /// </summary>
        /// <value>The keys for the properties are set by its names.</value>
        protected Dictionary<string, SerializedProperty> SerialProperties { get; private set; }
        #pragma warning restore CS8618

        /// <summary>
        ///     What shall occur on the OnEnable method, ran on the
        ///     "opening" of the Editor.
        /// </summary>
        protected abstract void Enabling();

        /// <summary>
        ///     This function is called when the object is loaded..
        /// </summary>
        /// <seealso href="https://docs.unity3d.com/ScriptReference/ScriptableObject.OnEnable.html" />
        private void OnEnable()
        {
            SerialTarget = new SerializedObject(target);

            SerialProperties = new Dictionary<string, SerializedProperty>();

            // TODO: Load SerialProperties with SerialTarget.

            Enabling();
        }
    }
}
