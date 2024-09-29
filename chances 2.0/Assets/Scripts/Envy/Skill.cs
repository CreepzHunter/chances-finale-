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
    public GameManagerGreedPride gameManagerGreedPride;
    public SkillManager skillManager;

    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject playerShield;
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject ckenemyLife;
    [SerializeField] private GameObject skillOpt;
    public GameObject[] PSkills;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    public void OnClickSkill()
    {
        if (healthSystem.health != 0 && skillManager.diamond != 0)
        {

            HideAttack();

            skillManager.diamond--;


            skillOpt.SetActive(true);

            //Invoke("SkillAttack", 2.0f);

        }
        else if (healthSystem.health <= 0)
        {
            //gameManagerSloth.SlothDone();
        }
    }


    public void AnimateSkill()
    {
        // cameraSwitch.PlayerView();

        // playerBack.SetActive(false);
        // playerSkill.SetActive(true);

        PSkills[0].SetActive(true);
        enemyLife.SetActive(false);

        ToHide[3].SetActive(false);

    }
    public void AnimateShield()
    {
        // cameraSwitch.PlayerView();

        // playerBack.SetActive(false);
        // playerShield.SetActive(true);

        PSkills[1].SetActive(true);

        enemyLife.SetActive(false);

        ToHide[3].SetActive(false);

    }
    public void SkillAttack()
    {
        // cameraSwitch.FightScene();
        playerBack.SetActive(true);
        // playerSkill.SetActive(false);
        PSkills[0].SetActive(false);

        enemyLife.SetActive(true);
        if (gameFlowManagerLust != null)
        {
            gameFlowManagerLust.PlayGame();
        }
        if (gameManagerEnvyNew != null)
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
                // Invoke("DelayAnimCK", 3f);
            }
            else
            {
                gameManagerSloth.SlothAttack();
            }
        }

        if (gameManagerGreedPride != null)
        {
            gameManagerGreedPride.ReturnAnimation();
        }

    }

    private void DelayAnimCK()
    {

    }

    public void SkillShield()
    {
        // cameraSwitch.FightScene();
        playerBack.SetActive(true);
        // playerShield.SetActive(false);

        PSkills[1].SetActive(false);

        enemyLife.SetActive(true);

        if (gameFlowManagerLust != null)
        {
            gameFlowManagerLust.PlayGame();
        }
        if (gameManagerEnvyNew != null)
        {
            gameManagerEnvyNew.EAnimatePlayer();

            gameManagerEnvyNew.EnvyAttack();
        }
        if (gameManagerSloth != null)
        {
            if (cockroachLife.health != 0)
            {
                gameManagerSloth.AnimateCKAttack();
            }
            else
            {
                gameManagerSloth.SlothAttack();
            }
        }
        if (gameManagerGreedPride != null)
        {
            gameManagerGreedPride.ReturnAnimation();
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

    public void HideAttack()
    {

        ToHide.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
}
