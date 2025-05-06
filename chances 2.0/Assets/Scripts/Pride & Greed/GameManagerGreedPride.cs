using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManagerGreedPride : MonoBehaviour
{
    public HealthSystem GreedLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public SkillOption skillOption;
    public TimeCode timeCode;
    public ObjectSpawner2D objectSpawner;

    public StartBlinkingAnim blink;

    [SerializeField] private GameObject playerLife;
    [SerializeField] private GameObject senemyLife;
    [SerializeField] private GameObject skillOptionContainer;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject greedBoss;
    private bool hasDied = false;
    public bool check = false;
    public GameObject[] playerVids;
    public GameObject[] playerAnimations;
    public GameObject[] enemyAnimations;
    public GameObject[] mainUIs;
    public GameObject gameover;

    public void Update()
    {
        if (GreedLife.health <= 0)
        {
            enemyAnimations[0].SetActive(false);
            enemyAnimations[3].SetActive(false);
            enemyAnimations[2].SetActive(true);
            enemyAnimations[5].SetActive(true);

            Invoke("PostBattle", 0.8f);

        }
        //player dead
        if (PlayerStats.Instance.PHealth <= 0)
        {
            gameover.SetActive(true);

            PlayerStats.Instance.PHealth = PlayerStats.Instance.MaxPHealth;
            PlayerStats.Instance.PlayerLife--;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
            PlayerPrefs.SetInt("PlayerLife", PlayerStats.Instance.PlayerLife);

            PlayerPrefs.Save();

            Invoke("LoadOverWorld", 1.06f);

        }

    }

    private void PostBattle()
    {
        PlayerStats.Instance.Money += 80;
        PlayerPrefs.SetInt("Money", PlayerStats.Instance.Money);
        PlayerStats.Instance.AllocationStats += 1;
        PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats);

        PlayerPrefs.Save();
        SceneManager.LoadScene(33);
    }
    private void LoadOverWorld()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickAttack()
    {

        if (GreedLife.health != 0)
        {

            // cameraSwitch.PlayerView();
            HideAttack();

            playerLife.SetActive(false);
            senemyLife.SetActive(false);
            skillOptionContainer.SetActive(false);

            // playerAnimations[0].SetActive(false);
            // playerAnimations[1].SetActive(true);
            // player animation
            playerVids[0].SetActive(true);

            //return animation
            Invoke("ReturnAnimation", 3f);
        }
    }

    public void ReturnAnimation()
    {
        // cameraSwitch.FightScene();
        // playerAnimations[0].SetActive(true);
        // playerAnimations[1].SetActive(false);
        playerVids[0].SetActive(false);

        EnemyAnimAttack();

        int number = Random.value < 0.6f ? 1 : 0;
        Debug.Log("number: " + number);

        if (number == 0)
        {
            // damage enemy

            int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

            if (skillOption != null && skillOption.attack == true)
            {
                totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
                skillOption.attack = false;
            }

            GreedLife.TakeDamage(totalDamage);

            Invoke("WaitBlink", 2f);


            Invoke("ReturnAll", 1f);
        }
        else if (number == 1)
        {
            Invoke("PlayGame", 1f);

        }
    }

    public void EnemyAnimAttack()
    {
        cameraSwitch.EnemyPosition();
        enemyAnimations[0].SetActive(false);
        enemyAnimations[3].SetActive(false);

        enemyAnimations[1].SetActive(true);
        enemyAnimations[4].SetActive(true);
    }

    public void ReturnEnemyAnim()
    {
        enemyAnimations[0].SetActive(true);
        enemyAnimations[3].SetActive(true);

        enemyAnimations[1].SetActive(false);
        enemyAnimations[4].SetActive(false);
    }

    public void EnemyTakeDamage()
    {

        int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

        if (skillOption != null && skillOption.attack == true)
        {
            totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
            skillOption.attack = false;
        }

        GreedLife.TakeDamage(totalDamage);

        Invoke("WaitBlink", 1f);
    }

    private void WaitBlink()
    {
        blink.StartBlinking(0);
        blink.StartBlinking(1);
    }
    public void PlayerTakeDamage()
    {
        int damage = Random.Range(10, 25);
        if (skillOption.shield == false)//immune damage if shielded
        {
            PlayerStats.Instance.PHealth -= damage;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
        }
        else if (skillOption.shield == true)
        {
            skillOption.shield = false;
        }

        blink.StartBlinking(2);

    }


    public void PlayGame()
    {
        cameraSwitch.PrideLustCameraMiniGame();
        game.SetActive(true);
        Camera.main.orthographic = true;
        objectSpawner.SpawnRoutineCour();
        ReturnEnemyAnim();
    }

    #region Basics
    public void ReturnAll()
    {
        skillOption.HideShield();
        cameraSwitch.FightScene();
        game.SetActive(false);

        Camera.main.orthographic = false;

        timeCode.countdownTimer = timeCode.initialCountdownDuration;

        mainUIs.ToList().ForEach(x =>
        {
            x.SetActive(true);
        });
    }
    private void HideAttack()
    {
        mainUIs.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
    #endregion
}
