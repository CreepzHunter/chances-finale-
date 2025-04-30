using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCConvo : MonoBehaviour
{
    public int NPCTrigger;

    public NPCConversation NPC1;
    public NPCConversation NPC2;
    public NPCConversation NPC3;
    public NPCConversation NPC4;
    public NPCConversation NPC5;
    public NPCConversation NPC6;


    // Update is called once per frame
    void Update()
    {
        NumberCheck();
    }

     void NumberCheck()
    {
        if(NPCTrigger == 1)
        {
            ConversationManager.Instance.StartConversation(NPC1);
        }

        else if(NPCTrigger == 2)
        {
            ConversationManager.Instance.StartConversation(NPC2);
        }

        else if(NPCTrigger == 3)
        {
            ConversationManager.Instance.StartConversation(NPC3);
        }

        else if(NPCTrigger == 4)
        {
            ConversationManager.Instance.StartConversation(NPC4);
        }

        else if(NPCTrigger == 5)
        {
            ConversationManager.Instance.StartConversation(NPC5);
        }

        else if(NPCTrigger == 6)
        {
            ConversationManager.Instance.StartConversation(NPC6);
        }
        
        NPCTrigger -= NPCTrigger;
    }

    public void Adder(int amount)
    {
        NPCTrigger += amount;
        
    }
}
