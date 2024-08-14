using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Skill : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public HealthSystem healthSystem;
    public HealthSystem cockroachLife;
    public StartBlinkingAnim startBlinking;
    public GameManagerSloth gameManagerSloth;
    public GameManagerEnvyNew gameManagerEnvyNew;
    public GameFlowManagerLust gameFlowManagerLust;
    public SkillManager skillManager;

    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject ckenemyLife;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    public void OnClickSkill()
    {
        if (healthSystem.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            skillManager.diamond--;

            playerBack.SetActive(false);
            playerSkill.SetActive(true);
            enemyLife.SetActive(false);

            Invoke("AnimatePlayer", 2.0f);
           
            //startBlinking.StartBlinking();

            //Invoke("ReturnAll", 2.2f);
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
        //enemyLife.SetActive(true);
        if(gameFlowManagerLust != null)
        {
            gameFlowManagerLust.PlayGame();
        }
        if(gameManagerEnvyNew != null)
        {
            gameManagerEnvyNew.EAnimatePlayer();
            //Invoke("gameManagerEnvyNew.EAnimatePlayer", 2.0f);

            gameManagerEnvyNew.EnvyAttack();
            //Invoke(" gameManagerEnvyNew.EnvyAttack", 3f);
        }

        if (gameManagerSloth != null)
        {
            if (cockroachLife.health != 0)
            {
                gameManagerSloth.AnimateCKAttack();
            }
            else
            {
                gameManagerSloth.AnimateAttack();
                gameManagerSloth.SlothAttack();
            }
        }
       
    }

    public void ReturnAll()
    {
        ckenemyLife.SetActive(true);

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
