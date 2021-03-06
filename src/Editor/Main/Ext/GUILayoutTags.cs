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

namespace MestreTramador.Editor
{
    /// <summary>
    ///     Create some <see cref="GUILayout" /> calls as Tags.
    /// </summary>
    public static class GUILayoutTags
    {
        /// <summary>
        ///     Referencing a <see langword="&lt;br /&gt;" /> tag,
        ///     it creates a space of <see langword="15px" />.
        /// </summary>
        public static void Break()
        {
            GUILayout.Space(15.0f);
        }
    }
}
