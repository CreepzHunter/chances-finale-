using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprefresetter : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs cleared from menu.");

        }
    }
}
