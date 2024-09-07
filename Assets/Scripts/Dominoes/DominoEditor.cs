using UnityEditor;
using UnityEngine;

namespace Dominoes
{
    [CustomEditor(typeof(Domino))]
    public class DominoEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var obj = (Domino) target;
            
            if (GUILayout.Button("Switch"))
            {
                obj.Switch();
            }
        }
    }
}