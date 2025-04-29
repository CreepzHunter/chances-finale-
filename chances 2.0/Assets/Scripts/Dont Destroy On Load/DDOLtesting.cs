using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLtesting : MonoBehaviour
{
    public static DDOLtesting Instance;

    private void Awake()
    {
        // Correct comparison to check if the instance is the same GameObject
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
