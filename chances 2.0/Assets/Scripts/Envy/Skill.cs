using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Skill : MonoBehaviour
{
    public GameManagerEnvyNew gameManagerEnvyNew;
    public GameFlowManagerLust gameFlowManagerLust;
    public CameraSwitch cameraSwitch;
    public SkillManager skillManager;
    public HealthSystem healthSystem;

    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject enemyLife;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    public void OnClickSkill()
    {
        if (healthSystem.health != 0 && skillManager.diamond != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            skillManager.diamond--;
            playerBack.SetActive(false);
            playerSkill.SetActive(true);
            enemyLife.SetActive(false);

            Invoke("AnimatePlayer", 2.0f);
            if(gameManagerEnvyNew != null)
            {
            gameManagerEnvyNew.EnvyAttack();
            }
            if(gameFlowManagerLust != null)
            {
            gameFlowManagerLust.AttackGameplay();

            }


            // Invoke("ReturnAll", 2.3f);
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
