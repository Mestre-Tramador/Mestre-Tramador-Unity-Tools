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
