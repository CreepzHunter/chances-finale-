using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colItem : MonoBehaviour
{
    public GameObject itemButton;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            itemButton.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            itemButton.SetActive(false);
        }
    }
}
