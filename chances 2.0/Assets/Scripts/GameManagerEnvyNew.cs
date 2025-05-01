using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerEnvyNew : MonoBehaviour
{


    public GameManager gameManager1;
    public HealthSystem envyLife;
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
    public StartBlinkingAnim blink;
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

            // Invoke("LoadOverWorld", 0.8f);
            Invoke("DemoWorld", 1.06f);
            PlayerPrefs.Save();

        }

        //player ded
        if (PlayerStats.Instance.PHealth == 0)
        {
            gameover.SetActive(true);

            // Invoke("LoadOverWorld", 1.06f);
            Invoke("DemoWorld", 1.06f);
            PlayerPrefs.Save();


        }
    }

    private void LoadOverWorld()
    {
        SceneManager.LoadScene(1);
    }
    private void DemoWorld()
    {
        SceneManager.LoadScene(17);
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
        // int number = 1;
        if (number == 0)
        {
            // damage enemy
            // envyLife.TakeDamage(22f);


            int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

            if (skillOption != null && skillOption.attack == true)
            {
                totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
                skillOption.attack = false;
            }

            envyLife.TakeDamage(totalDamage);
            blink.StartBlinking(0);

            ReturnAll();
        }
        else
        if (number == 1)
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
