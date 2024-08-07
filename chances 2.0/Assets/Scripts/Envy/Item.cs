using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Item : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public HealthSystem EnvyLife;


    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerItem;
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject back;

    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    public void OnClickItem()
    {
        if (EnvyLife.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            //EnvyLife.TakeDamage(20);
            //gameManager.StartBlinking();


            playerBack.SetActive(false);
            playerItem.SetActive(true);
            enemyLife.SetActive(false);


            Invoke("AnimatePlayer", 1.2f);

            Invoke("ReturnAll", 1.5f);
        }
    }

    private void AnimatePlayer()
    {
        cameraSwitch.FightScene();
        playerBack.SetActive(true);
        playerItem.SetActive(false);
        enemyLife.SetActive(true);
        Invoke("Inventory", 0.4f);
    }

    private void Inventory()
    {
        item.SetActive(true);
        back.SetActive(true);
    }

    public void ReturnAll()
    {
        //enemyAttack.SetActive(false);

        BtnsToShow.ToList().ForEach(button =>
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
