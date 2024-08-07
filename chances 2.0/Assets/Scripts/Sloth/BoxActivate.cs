using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActivate : MonoBehaviour
{
    [SerializeField] private GameObject staticShield;
    private bool isTouched = false;
    private Collider2D currentCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxHolder"))
        {
            isTouched = true;
            currentCollision = collision;
            staticShield.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxHolder"))
        {
            isTouched = false;
            currentCollision = null;
            staticShield.SetActive(true);
        }
    }


}
