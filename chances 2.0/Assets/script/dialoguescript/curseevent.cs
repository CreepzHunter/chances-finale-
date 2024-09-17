using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curseevent : MonoBehaviour
{
    public GameObject eventBox;
    //public Animator anim;
    //public GameObject screen;
    public dialgouchecker checker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            checker.screen.SetActive(true);
            Debug.Log("enter message");
            checker.anim.SetTrigger("play");
            eventBox.SetActive(false);

        }
    }
}
