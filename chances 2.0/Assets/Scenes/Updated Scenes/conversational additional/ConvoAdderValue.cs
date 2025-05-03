using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ConvoAdderValue : MonoBehaviour
{
    public convoManager CM;
    public int Number;

    public void addValue()
    {
        
            CM.Adder(Number);
            Debug.Log("value has been added");
    }
}
