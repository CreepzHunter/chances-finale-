using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerParent : MonoBehaviour
{
    public GameManager gameManager1;
    public HealthSystem EnvyLife;
    public Enemy enemySloth;
    public GameObject doorClose;
    public GameObject doorOpen;
    public GameObject slothLife;
    public GameObject key;

    public GameObject[] EToShow;
    public GameObject[] SToShow;
    public GameObject[] ToHide;

    public GameObject slothA;
    private bool isActive;


    public void OnClickAttack()
    {
        // if (!enemyBoss.activeSelf && enemySloth.isDead == true)
        // {
        //     Debug.Log("not active.");
        //     return;
        // }
        // else
        // {
        //     if (EnvyLife.health != 0)
        //     {
        //         isActive = !isActive;

        //         EnvyShow();
        //         HideAttack();
        //     }
        //     else if (EnvyLife.health == 0)
        //     {
        //         isActive = !isActive;
        //         SlothShow();
        //         HideAttack();

        //         doorClose.SetActive(true);
        //         doorOpen.SetActive(false);
        //         key.SetActive(true);
        //     }
        // }
        // for checking
        if (EnvyLife.health != 0)
        {
            isActive = !isActive;
            if (slothLife)
            {
                /*add condition of sloth A is defeated
            go to sloth B? */
            }
            else if (!slothLife)
            {
                SlothShow();
            }

            HideAttack();

            doorClose.SetActive(true);
            doorOpen.SetActive(false);
            key.SetActive(true);
        }
    }
    private void EnvyShow()
    {
        EToShow.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }
    private void SlothShow()
    {
        SToShow.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }
    private void HideAttack()
    {
        ToHide.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }

}
