using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCconvoScript : MonoBehaviour
{
    public GameObject button;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
