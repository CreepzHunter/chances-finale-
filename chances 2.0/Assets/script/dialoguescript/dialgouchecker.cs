using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialgouchecker : MonoBehaviour
{
    public dialoguetrigger trigger;
    public Animator anim;
    public GameObject screen;


    /*public void convoTrigger()
    {
        trigger.StartDialogue();
        StartCoroutine(Stopper());
    }*/

    IEnumerator Stopper()
    {
        yield return new WaitForSeconds(2f);

        anim.SetTrigger("default");
        trigger.StartDialogue();
        screen.SetActive(false);

    }
}
