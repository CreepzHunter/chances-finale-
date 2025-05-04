using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{

    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
        Debug.Log("Target FPS set to: " + fps);
        PlayerPrefs.SetInt("FPSSetting", fps);
        PlayerPrefs.Save();
    }
}
