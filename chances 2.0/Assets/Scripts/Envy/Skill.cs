using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Skill : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public HealthSystem healthSystem;
    public StartBlinkingAnim startBlinking;

    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject enemyLife;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    public void OnClickSkill()
    {
        if (healthSystem.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            healthSystem.TakeDamage(20);

            playerBack.SetActive(false);
            playerSkill.SetActive(true);
            enemyLife.SetActive(false);

            Invoke("AnimatePlayer", 2.0f);
            startBlinking.StartBlinking();

            Invoke("ReturnAll", 2.3f);
        }
        else if (healthSystem.health <= 0)
        {
            //gameManagerSloth.SlothDone();
        }
    }

    private void AnimatePlayer()
    {
        cameraSwitch.FightScene();
        playerBack.SetActive(true);
        playerSkill.SetActive(false);
        enemyLife.SetActive(true);
    }

    public void ReturnAll()
    {

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
