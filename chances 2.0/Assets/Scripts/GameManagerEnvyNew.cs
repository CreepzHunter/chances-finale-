using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerEnvyNew : MonoBehaviour
{
    public GameManager gameManager1;
    public HealthSystem envyLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public TimeCode timeCode;
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

    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;


    void Update()
    {
        if (envyLife.health <= 0 && !hasDied)
        {
            hasDied = true;
            EnvyDone();
        }

        if (healthSystemPlayer.health == 0)
        {
            //dead
        }
    }

    public void EnvyDone()
    {

        if (envyLife.health >= 0)
        {
            envyBoss.SetActive(true);
        }

        Debug.Log("s  up");

        hasDied = true;


        eenemyIdle.SetActive(false);
        eenemyLife.SetActive(false);

        eenemyDeath.SetActive(true);

        Invoke("EDeathAnim", 1.5f);

    }


    public void OnClickAttack()
    {
        Debug.Log("Life" + envyLife.health);
        if (envyLife.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();
            timeCode.loseIndicator = false;


            playerBack.SetActive(false);
            playerFront.SetActive(true);
            playerLife.SetActive(false);
            eenemyLife.SetActive(false);


            Invoke("EAnimatePlayer", 2.0f);
            gameManager1.StartBlinking();

            Invoke("EnvyAttack", 3f);
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
    #endregion

    #region Envy Actions

    private void EDeathAnim()
    {
        eenemyDeath.SetActive(false);
    }

    private void EnvyAttack()
    {
        eenemyIdle.SetActive(false);
        eenemyAttack.SetActive(true);

        Invoke("EnvyShow", 1f);



        HideAttack();
    }

    private void EAnimatePlayer()
    {
        cameraSwitch.FightScene();
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
