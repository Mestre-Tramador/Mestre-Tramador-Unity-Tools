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
    ///     A Editor referencing the <see cref="Player2D" />,
    ///     enabling customization of some controls and view of
    ///     current stats.
    /// </summary>
    [CustomEditor(typeof(Player2D), true)]
    public class Player2DEditor : SerialEditor
    {
        #region Properties
        #pragma warning disable CS8618
        /// <summary>
        ///     The current 2D Player on scene.
        /// </summary>
        /// <value>
        ///     The object is the <see cref="UnityEditor.Editor.target" />
        ///     unserialized, for reference.
        /// </value>
        private Player2D Player { get; set; }

        /// <summary>
        ///     The Collider of the 2D Player.
        /// </summary>
        /// <value>
        ///     The object represents the current <see cref="Player" />
        ///     Collider, for reference on edition.
        /// </value>
        private Character2DCollider Collider { get; set; }
        #pragma warning restore CS8618
        #endregion

        #region Enabled
        /// <summary>
        ///     On Enable, the objects being edited are set.
        /// </summary>
        protected override void Enabling()
        {
            Player = (Player2D) target;
            Collider = Player.Collider;
        }
        #endregion

        #region Editor
        /// <summary>
        ///     <para>
        ///         The custom editor consists on two rows:
        ///     </para>
        ///
        ///     <para>
        ///         The first row enables on the Play mode and
        ///         shows the Controls and Stats of player with
        ///         labels and explanatory info.
        ///
        ///         <br />
        ///
        ///         The current Controls that can be set are:
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="Character2D.CanMove" /></term>
        ///                <description>Enable/Disable the Movement.</description>
        ///             </item>
        ///             <item>
        ///                <term><see cref="Character2D.CanJump" /></term>
        ///                <description>Enable/Disable the Jump.</description>
        ///             </item>
        ///         </list>
        ///
        ///         <br />
        ///
        ///         The current Stats that are shown:
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="Character2D.IsTurnedTo" /></term>
        ///                <description>Direction the Player is Facing.</description>
        ///             </item>
        ///             <item>
        ///                <term><see cref="Character2D.Jumps" /></term>
        ///                <description>Current jumps made.</description>
        ///             </item>
        ///         </list>
        ///
        ///         <br />
        ///
        ///         The current Stats that can be set are:
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="Character2D.Speed" /></term>
        ///                <description>Determine the Speed of Movement.</description>
        ///             </item>
        ///             <item>
        ///                <term><see cref="Character2D.Force" /></term>
        ///                <description>Determine the Force of Jump.</description>
        ///             </item>
        ///         </list>
        ///     </para>
        ///
        ///     <para>
        ///         The second row is allways enabled on Edit mode and
        ///         contains some properties that can be changed, as show:
        ///
        ///         <br />
        ///
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="Character2DCollider.Type" /></term>
        ///                <description>Determine the Shape of the 2D Player.</description>
        ///             </item>
        ///             <item>
        ///                <term><see cref="Character2D.JumpMode" /></term>
        ///                <description>Determine the mode of Jumping.</description>
        ///             </item>
        ///         </list>
        ///
        ///         <br />
        ///
        ///         Additionally, these values may or not be edited on Play,
        ///         but not directly by the Editor.
        ///     </para>
        /// </summary>
        public override void OnInspectorGUI()
        {
            #region Variables
            int type;
            #endregion

            #region On Play
            EditorGUI.BeginDisabledGroup(!EditorApplication.isPlaying);
                #region Controls
                GUILayout.BeginVertical();
                    GUILayout.Label("Controls:");
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal();
                    Player.CanMove = EditorGUILayout.ToggleLeft("Move", Player.CanMove, GUILayout.Width(55.0f));
                    Player.CanJump = EditorGUILayout.ToggleLeft("Jump", Player.CanJump, GUILayout.Width(55.0f));
                    AdditionalControls();
                GUILayout.EndHorizontal();
                #endregion

                GUILayoutTags.Break();

                #region Stats
                GUILayout.BeginVertical();
                    GUILayout.Label("Stats:");
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal();
                    GUILayout.Label($"Turned to: {Player.IsTurnedTo}");
                    GUILayout.Label($"Jumps: {Player.Jumps}");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                    GUILayout.Label("Speed:");
                    Player.Speed = EditorGUILayout.Slider(Player.Speed, 0.0f, HasBody2D.MAX_SPEED);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                    GUILayout.Label("Force:");
                    Player.Force = EditorGUILayout.Slider(Player.Force, 0.0f, HasBody2D.MAX_FORCE);
                GUILayout.EndHorizontal();

                AdditionalStats();
                #endregion
            EditorGUI.EndDisabledGroup();
            #endregion

            GUILayoutTags.Break();

            #region On Editor
            EditorGUI.BeginDisabledGroup(EditorApplication.isPlaying);
                #region Collider
                GUILayout.BeginVertical();
                    GUILayout.Label("Collider:");
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal();
                    type = EditorGUILayout.Popup((int) Collider.Type, Enum.GetNames(typeof(Character2DColliders)));
                GUILayout.EndHorizontal();
                #endregion

                GUILayoutTags.Break();

                #region Jump Mode
                GUILayout.BeginVertical();
                    GUILayout.Label("Jump Mode:");
                GUILayout.EndVertical();

                GUILayout.BeginHorizontal();
                    Player.JumpMode = (JumpModes) EditorGUILayout.Popup((int) Player.JumpMode, JumpModes());
                GUILayout.EndHorizontal();
                #endregion
            EditorGUI.EndDisabledGroup();
            #endregion

            #region On Change
            if(GUI.changed)
            {
                EditorUtility.SetDirty(Player);

                if((Character2DColliders) type != Collider.Type)
                {
                    Collider.Type = (Character2DColliders) type;
                }

                SerialTarget.ApplyModifiedProperties();
            }
            #endregion

            #region Functions
            string[] JumpModes()
            {
                string[] modes = Enum.GetNames(typeof(JumpModes));

                for(int i = 0; i < modes.Length; i++)
                {
                    modes[i] = modes[i].Insert(modes[i].IndexOf('J'), " ");
                }

                return modes;
            }
            #endregion
        }
        #endregion

        #region Virtuals
        /// <summary>
        ///     Create additional Controls on the Editor.
        /// </summary>
        protected virtual void AdditionalControls() { }

        /// <summary>
        ///     Create additional Stats on the Editor.
        /// </summary>
        protected virtual void AdditionalStats() { }
        #endregion
    }
}
