using UnityEditor;
using UnityEngine;

public class ScreenCapturer : MonoBehaviour
{
    [SerializeField] string _path;

    public void TakeScreenshot()
    {
        var uniquePath = AssetDatabase.GenerateUniqueAssetPath(_path);
        ScreenCapture.CaptureScreenshot(uniquePath);
    }
}