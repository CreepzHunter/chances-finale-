using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRhythmHealth : MonoBehaviour
{

    public void DisableRhythm()
    {
        gameObject.SetActive(false);
    }

    public void EnableRhythm()
    {
        gameObject.SetActive(true);
    }

}
