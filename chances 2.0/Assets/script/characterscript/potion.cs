using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public health potionheal;
    public GameObject potionimage;

    public void playerheal()
    {
        potionheal.healPlayer(1);
        potionimage.SetActive(false);
    }

    public void playerhealmega()
    {
        potionheal.healPlayer(3);
        potionimage.SetActive(false);
    }
}
