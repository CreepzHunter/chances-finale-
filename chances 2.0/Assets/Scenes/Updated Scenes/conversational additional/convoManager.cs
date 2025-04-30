using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class convoManager : MonoBehaviour
{
    public int ConvoTrigger;

    public NPCConversation Self;
    public NPCConversation School;
    public NPCConversation Market;
    public NPCConversation City;
    public NPCConversation Rage;
    public NPCConversation Fight;
    public NPCConversation Encounter;

    private const string convoKey = "ConvoTriggerNumber";

    void Awake()
    {
        ConvoTrigger = PlayerPrefs.GetInt(convoKey, 0);
        
    }
    
    void Start()
    {
        NumberCheck();
    }
    
    void NumberCheck()
    {
        if(ConvoTrigger == 1)
        {
            ConversationManager.Instance.StartConversation(Self);
        }

        else if(ConvoTrigger == 2)
        {
            ConversationManager.Instance.StartConversation(School);
        }

        else if(ConvoTrigger == 3)
        {
            ConversationManager.Instance.StartConversation(Market);
        }

        else if(ConvoTrigger == 4)
        {
            ConversationManager.Instance.StartConversation(City);
        }

        else if(ConvoTrigger == 5)
        {
            ConversationManager.Instance.StartConversation(Rage);
        }

        else if(ConvoTrigger == 6)
        {
            ConversationManager.Instance.StartConversation(Fight);
        }

        else if(ConvoTrigger == 7)
        {
            ConversationManager.Instance.StartConversation(Encounter);
        }
        
        ConvoTrigger -= ConvoTrigger;

        PlayerPrefs.SetInt(convoKey, ConvoTrigger);
        PlayerPrefs.Save();
    }

    public void Adder(int amount)
    {
        ConvoTrigger += amount;
        
        PlayerPrefs.SetInt(convoKey, ConvoTrigger);
        PlayerPrefs.Save();
    }
}
