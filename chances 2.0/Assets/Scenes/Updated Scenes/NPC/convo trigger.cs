using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class convotrigger : MonoBehaviour
{
    public NPCConvo Trigger;
    public int ConvoNumber;
    public bool interact = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact = false;
        }
    }

    void OnMouseDown()
    {
        if (interact)
        {
            Trigger.Adder(ConvoNumber);
        }
    }
}
