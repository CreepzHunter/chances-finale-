using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public TMP_Text ActorName;
    public TMP_Text ActorMessage;
    public RectTransform backgroundbox;
    public Animator anim;
    public GameObject menu;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool IsActive = false;

    public novelscene novel;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        IsActive = true;
        Debug.Log("started a conversation loaded messages" + messages.Length);
        DisplayMessage();
        anim.SetBool("IsOpen", true);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        ActorMessage.text = messageToDisplay.message;
        Actor actorToDipslay = currentActors[messageToDisplay.ActorID];
        ActorName.text = actorToDipslay.name;

        menu.SetActive(false);
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("conversation Ended");
            IsActive = false;
            anim.SetBool("IsOpen", false);

            menu.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.R) && IsActive == true)
        {
            NextMessage();
        }*/

        if(Input.GetMouseButtonDown(1) && IsActive == true)
        {
            NextMessage();
        }
    }
}
