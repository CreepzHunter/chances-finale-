using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupitemsfx : MonoBehaviour
{
     audiomanager audiosfx;

    void Awake()
    {
        audiosfx = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }
    public void sfxplay()
    {
        audiosfx.sfxSound(audiosfx.pickup);
    }
}
