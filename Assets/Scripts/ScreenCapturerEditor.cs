using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScreenCapturer))]
public class ScreenCapturerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var obj = (ScreenCapturer) target;
        
        if (GUILayout.Button("Take screenshot"))
        {
            obj.TakeScreenshot();
        }
    }
}