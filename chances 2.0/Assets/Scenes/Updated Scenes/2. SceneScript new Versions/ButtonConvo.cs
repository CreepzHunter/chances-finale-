using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class ButtonConvo : MonoBehaviour
{
    public NPCConversation StartConvers;

    public void ButtonConversation()
    {
        ConversationManager.Instance.StartConversation(StartConvers);
    }
}
