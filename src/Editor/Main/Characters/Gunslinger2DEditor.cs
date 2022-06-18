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

using UnityEditor;
using UnityEngine;

namespace MestreTramador.Editor
{
    /// <summary>
    ///     A Editor referencing the <see cref="Gunslinger2D" />,
    ///     enabling customization of some controls and view of
    ///     current stats.
    /// </summary>
    [CustomEditor(typeof(Gunslinger2D))]
    public sealed class Gunslinger2DEditor : Player2DEditor
    {
        #region Properties
        #pragma warning disable CS8618
        /// <summary>
        ///     The current 2D Gunslinger Player on scene.
        /// </summary>
        /// <value>
        ///     The object is the <see cref="UnityEditor.Editor.target" />
        ///     unserialized, for reference.
        /// </value>
        private Gunslinger2D Gunslinger { get; set; }
        #pragma warning restore CS8618
        #endregion

        #region Enabled
        /// <inheritdoc />
        protected override void Enabling()
        {
            base.Enabling();

            Gunslinger = (Gunslinger2D) target;
        }
        #endregion

        #region Additionals
        /// <summary>
        ///     <para>
        ///         The additional controls are:
        ///     </para>
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="Character2D.CanShoot" /></term>
        ///                <description>Enable/Disable the Shooting.</description>
        ///             </item>
        ///         </list>
        /// </summary>
        protected override void AdditionalControls()
        {
            Gunslinger.CanShoot = EditorGUILayout.ToggleLeft("Shoot", Gunslinger.CanShoot, GUILayout.Width(55.0f));
        }

        /// <summary>
        ///     <para>
        ///         The additional stats are:
        ///     </para>
        ///         <list type="bullet">
        ///             <item>
        ///                <term><see cref="ShooterCharacter2D.MaxAmmo" /></term>
        ///                <description>The maximum ammunition of the Gunslinger Player.</description>
        ///             </item>
        ///
        ///             <item>
        ///                <term><see cref="ShooterCharacter2D.Ammo" /></term>
        ///                <description>The current ammunition of the Gunslinger Player.</description>
        ///             </item>
        ///         </list>
        /// </summary>
        protected override void AdditionalStats()
        {
            int gunslingerMaxAmmo = Gunslinger.MaxAmmo ?? Gunslinger2D.MAX_AMMO;
            int gunslingerAmmo = Gunslinger.Ammo ?? 0;

            GUILayout.BeginHorizontal();
                GUILayout.Label("Max. Ammo:");
                Gunslinger.MaxAmmo = EditorGUILayout.IntField(gunslingerMaxAmmo);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
                GUILayout.Label("Ammo:");
                int ammo = EditorGUILayout.IntField(gunslingerAmmo);

                if(ammo >= gunslingerMaxAmmo)
                {
                    ammo = gunslingerMaxAmmo;
                }
                Gunslinger.Ammo = ammo;
            GUILayout.EndHorizontal();
        }
        #endregion
    }
}
