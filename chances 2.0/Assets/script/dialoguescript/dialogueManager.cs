using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
    public Image ActorIcons;
    public TMP_Text ActorName;
    public TMP_Text ActorMessage;
    public RectTransform backgroundbox;
    public Animator anim;
    public GameObject menu;

    Message[] currentMessages;
    Actor[] currentActors;
    //Sprite[] currentIcons;
    int activeMessage = 0;
    public static bool IsActive = false;

    //public novelscene novel;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        //currentIcons = icons;
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
        if (activeMessage < currentMessages.Length)
        {
            Message messageToDisplay = currentMessages[activeMessage];

            if (messageToDisplay.ActorID >= 0 && messageToDisplay.ActorID < currentActors.Length)
            {
                Actor actorToDisplay = currentActors[messageToDisplay.ActorID];
                ActorName.text = actorToDisplay.name;
            }
            else
            {
                Debug.LogError("ActorID is out of bounds.");
                return; // Early exit if ActorID is invalid
            }

            ActorMessage.text = messageToDisplay.message;

            // Make sure iconID is within bounds
            if (messageToDisplay.iconID != null)
            {
                ActorIcons.sprite = messageToDisplay.iconID;  // Assign the sprite directly from the Message's iconID
            }
            else
            {
                Debug.LogError("iconID is null.");
                return; // Early exit if iconID is invalid
            }


            menu.SetActive(false);
        }
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
