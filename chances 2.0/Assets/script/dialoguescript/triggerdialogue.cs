using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerdialogue : MonoBehaviour
{
    public dialoguetrigger trigger;

    void buttonTrigger()
    {
        trigger.StartDialogue();
    }
}
