using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class convotrigger : MonoBehaviour
{
    public NPCConvo Trigger;
    public int ConvoNumber;
    public bool interact = false;
    public Button signs;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact = true;
            signs.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interact = false;
            signs.gameObject.SetActive(false);
        }
    }

    public void Talk()
    {
        if (interact)
        {
            audioManager.PlaySFX(audioManager.Click);
            signs.gameObject.SetActive(false);
            Trigger.Adder(ConvoNumber);
        }
    }
}
