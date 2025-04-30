using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gamemaster gm = FindObjectOfType<gamemaster>();

            gm.SaveCheckpoint(transform.position);
            
            Debug.Log("Checkpoint save");
        }
    }
}
