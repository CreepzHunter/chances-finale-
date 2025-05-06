using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject Map;


    void Update()
    {
         {
            if (Input.GetKeyDown(KeyCode.M) && Map != null)
            {
                Map.SetActive(!Map.activeSelf);
            }
        }
    }
}
