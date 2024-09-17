using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillpotion : MonoBehaviour
{
    public GameObject skillpotionimage;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;

    public void restoreSkill()
    {
        if(!skill1.activeSelf)
        {
            skill1.SetActive(true);
        }

        else if(!skill2.activeSelf)
        {
            skill2.SetActive(true);
        }

        else if(!skill3.activeSelf)
        {
            skill3.SetActive(true);
        }
        
        skillpotionimage.SetActive(false);
    }
    
    public void restoreSkill2()
    {
        if(!skill1.activeSelf)
        {
            skill1.SetActive(true);
            skill2.SetActive(true);
        }

        else if(!skill2.activeSelf)
        {
            skill2.SetActive(true);
            skill3.SetActive(true);
        }

        else if(!skill2.activeSelf)
        {
            skill3.SetActive(true);
        }

        skillpotionimage.SetActive(false);
    }
}
