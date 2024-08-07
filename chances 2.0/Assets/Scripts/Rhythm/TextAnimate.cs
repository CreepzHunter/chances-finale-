using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimate : MonoBehaviour
{
    public float lifetime = 0.3f;

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
