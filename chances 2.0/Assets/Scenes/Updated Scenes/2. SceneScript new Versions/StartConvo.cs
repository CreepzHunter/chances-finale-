using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class StartConvo : MonoBehaviour
{
    public NPCConversation AutoStart;
    void Start()
    {
        ConversationManager.Instance.StartConversation(AutoStart);
    }
}
