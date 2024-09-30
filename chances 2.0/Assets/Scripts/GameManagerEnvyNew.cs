using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerEnvyNew : MonoBehaviour
{
    public GameManager gameManager1;
    public HealthSystem envyLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public TimeCode timeCode;
    public SkillOption skillOption;
    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;
    //EnvySection
    [SerializeField] private GameObject eenemyLife;
    [SerializeField] private GameObject eenemyAttack;
    [SerializeField] private GameObject eenemyIdle;
    [SerializeField] private GameObject eenemyDeath;
    [SerializeField] private GameObject envyBoss;
    [SerializeField] private GameObject envyGameplay;
    [SerializeField] private GameObject playerLife;
    //SlothSection


    private bool hasDied = false;
    public bool check = false;

    [SerializeField]
    private GameObject[] PVids
;
    [SerializeField] private GameObject[] Animations;
    [SerializeField] private GameObject[] Buttons;
    public GameObject gameover;


    void Update()
    {
        if (envyLife.health <= 0 && !hasDied)
        {
            hasDied = true;
            EnvyDone();

            Invoke("LoadOverWorld", 0.8f);

        }
        //player ded
        if (healthSystemPlayer.health == 0)
        {
            gameover.SetActive(true);
            Invoke("LoadOverWorld", 1.06f);
        }
    }

    private void LoadOverWorld()
    {
        SceneManager.LoadScene(1);
    }

    public void EnvyDone()
    {

        if (envyLife.health >= 0)
        {
            envyBoss.SetActive(true);
        }


        hasDied = true;


        // eenemyIdle.SetActive(false);
        eenemyLife.SetActive(false);
        eenemyIdle.SetActive(false);
        eenemyDeath.SetActive(true);

        Invoke("EDeathAnim", 1.5f);

    }


    public void OnClickAttack()
    {
        if (envyLife.health != 0)
        {
            // cameraSwitch.PlayerView();

            HideAttack();
            timeCode.loseIndicator = false;

            PVids[0].SetActive(true);
            // playerBack.SetActive(false);
            // playerFront.SetActive(true);
            // playerLife.SetActive(false);
            // eenemyLife.SetActive(false);


            Invoke("EAnimatePlayer", 3.8f);

            Invoke("EnvyAttack", 4.3f);
        }

    }

    #region Basics
    public void ReturnAll()
    {
        playerLife.SetActive(true);
        eenemyAttack.SetActive(false);

        if (envyLife.health >= 80)
        {
            timeCode.countdownTimer = 20f;
        }
        else if (envyLife.health <= 80 && envyLife.health >= 60)
        {
            timeCode.countdownTimer = 15f;
        }
        else if (envyLife.health <= 60)
        {
            timeCode.countdownTimer = 10f;
        }

        Buttons.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }
    private void HideAttack()
    {
        Buttons.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
    #endregion

    #region Envy Actions

    private void EDeathAnim()
    {
        eenemyDeath.SetActive(false);
    }

    public void EnvyAttack()
    {
        // eenemyIdle.SetActive(false);
        // eenemyAttack.SetActive(true);

        // damage enemy 1 or play game 2
        int number = Random.Range(0, 2);

        if (number == 0)
        {
            // damage enemy
            envyLife.TakeDamage(22f);
            Debug.Log("test");
            ReturnAll();
        }
        else if (number == 1)
        {
            Invoke("EnvyShow", 1f);
            HideAttack();
        }

    }

    public void EAnimatePlayer()
    {
        PVids[0].SetActive(false);

        if (skillOption.shield == false)
        {
            gameManager1.StartBlinking();
        }

        // cameraSwitch.FightScene();
        playerBack.SetActive(true);
        playerFront.SetActive(false);
        if (envyLife.health != 0)
        {
            eenemyLife.SetActive(true);
            playerLife.SetActive(true);

        }
        eenemyLife.SetActive(true);
    }

    private void EnvyShow()
    {
        envyGameplay.SetActive(true);
    }

    #endregion




}
