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
using UnityEditor;
using UnityEngine;

namespace MestreTramador.Editor
{

    /// <summary>
    ///     A Editor referencing the <see cref="CameraController" />,
    ///     enabling viewing of the operations in course.
    /// </summary>
    [CustomEditor(typeof(CameraController), true)]
    public class CameraControllerEditor : SerialEditor
    {
        /// <summary>
        ///     The current Controller (Camera) on scene.
        /// </summary>
        /// <value>
        ///     The object is the <see cref="UnityEditor.Editor.target" />
        ///     unserialized, for reference.
        /// </value>

        private CameraController Controller { get; set; }

        /// <summary>
        ///     On Enable, the objects being edited are set.
        /// </summary>
        protected override void Enabling()
        {
            Controller = (CameraController) target;
        }

        /// <summary>
        ///     <para>
        ///         The custom editor consists on a single row:
        ///     </para>
        ///     <list type="bullet">
        ///         <item>
        ///            <term><see cref="Controller.ModeValue{M}" /></term>
        ///            <description>The current Mode on use.</description>
        ///         </item>
        ///     </list>
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
                GUILayout.BeginVertical();
                    GUILayout.Label("Mode:");
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal();
                    EditorGUILayout.Popup(
                        (int) Controller.ModeValue<CameraControllerModes>(),
                        Enum.GetNames(typeof(CameraControllerModes))
                    );
                GUILayout.EndHorizontal();
            EditorGUI.EndDisabledGroup();
        }
    }
}
