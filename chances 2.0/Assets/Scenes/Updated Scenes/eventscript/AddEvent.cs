using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEvent : MonoBehaviour
{
    public EventBlocker Event;
    public int TheEvent;

    public void ForDaEvent()
    {
        Event.EventAdder(TheEvent);
        Debug.Log("value has been added");

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Event.EventAdder(TheEvent);
            Debug.Log("value has been added");
        }
    }


}
