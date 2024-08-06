using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguetrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue() 
    {
        FindObjectOfType<dialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int ActorID;
    public string message;
}

[System.Serializable]
public class Actor{
    public string name;
}