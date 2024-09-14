using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenestarter : MonoBehaviour
{
   private novelsceneloader novel;

   public GameObject setObject;
   public Animator anim;

    void Start()
    {
        if(anim == true)
            {
                anim.SetTrigger("open");
            }
    }

    public void objectFalse()
    {
        setObject.SetActive(false);
    }

    public void objectTrue()
    {
        setObject.SetActive(true);
        anim.SetTrigger("close");
    }
}
