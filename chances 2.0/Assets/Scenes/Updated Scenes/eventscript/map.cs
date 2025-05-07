using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject Map;
    public GameObject Bag;


    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.M) && Map != null)
            {
                Map.SetActive(!Map.activeSelf);
            }
            if ((Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.Tab)) && Bag != null)
            {
                Bag.SetActive(!Bag.activeSelf);
            }
        }
    }
}
