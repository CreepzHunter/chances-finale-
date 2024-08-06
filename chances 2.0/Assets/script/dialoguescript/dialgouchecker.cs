using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialgouchecker : MonoBehaviour
{
    public dialoguetrigger trigger;

    private void OnMouseDown()
    {
        Debug.Log("enter message");
        trigger.StartDialogue();
    }

    public void novelbutton()
    {
        Debug.Log("enter novel message");
        trigger.StartDialogue();
    }
}
