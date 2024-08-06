using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCconvoScript : MonoBehaviour
{
    public GameObject message;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                message.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            message.SetActive(false);
        }
    }
}
