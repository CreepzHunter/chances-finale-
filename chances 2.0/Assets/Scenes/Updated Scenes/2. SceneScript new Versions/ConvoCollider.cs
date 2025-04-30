using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConvoCollider : MonoBehaviour
{
    public NPCConversation wall;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(wall);
        }

    }
}
