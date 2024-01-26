using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOrientationController : MonoBehaviour
{
    public enum SceneOrientation
    {
        Landscape,
        Portrait
    }

    public SceneOrientation desiredOrientation = SceneOrientation.Landscape;

    void Start()
    {
        SetSceneOrientation(desiredOrientation);
    }

    public void SetSceneOrientation(SceneOrientation orientation)
    {
        switch (orientation)
        {
            case SceneOrientation.Landscape:
                Screen.orientation = ScreenOrientation.LandscapeLeft;
                break;
            case SceneOrientation.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            default:
                Debug.LogWarning("Unknown orientation specified.");
                break;
        }
    }
}
