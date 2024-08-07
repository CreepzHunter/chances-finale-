using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;


    public bool check = false;
    public void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            check = true;
            doorOpen.SetActive(true);
            doorClose.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
