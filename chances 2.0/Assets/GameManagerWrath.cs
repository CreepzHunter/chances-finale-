using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManagerWrath : MonoBehaviour
{
    public HealthSystem wrathLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public Camera camera;
    public SkillOption skillOption;
    public TimeCode timeCode;


    [SerializeField] private GameObject playerLife;
    [SerializeField] private GameObject senemyLife;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject wrathBoss;
    private bool hasDied = false;
    public bool check = false;
    public GameObject[] playerVids;
    public GameObject[] playerAnimations;
    public GameObject[] enemyAnimations;
    public GameObject[] mainUIs;
    public GameObject[] gameplays;
    public GameObject gameover;

    public void Update()
    {
        if (wrathLife.health == 0)
        {
            enemyAnimations[0].SetActive(false);
            enemyAnimations[2].SetActive(true);

            Invoke("LoadOverWorld", 0.8f);
        }
        //player dead
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
    public void OnClickAttack()
    {

        if (wrathLife.health != 0)
        {

            HideAttack();

            senemyLife.SetActive(false);

            // player animation
            playerVids[0].SetActive(true);

            //return animation
            Invoke("ReturnAnimation", 3f);
        }
    }

    public void ReturnAnimation()
    {
        playerVids[0].SetActive(false);

        EnemyAnimAttack();


        Invoke(nameof(ReturnEnemyAnim), 4.5f);
    }
    private void RandomBattleOutcome()
    {
        int number = Random.Range(0, 2);
        Debug.Log("number: " + number);

        if (number == 0)
        {
            // damage enemy
            int damage = Random.Range(10, 18);
            wrathLife.TakeDamage(damage);

            Invoke("ReturnAll", 1f);
        }
        else if (number == 1)
        {
            Invoke("PlayGame", 1f);
        }
        senemyLife.SetActive(false);
    }

    public void EnemyAnimAttack()
    {
        enemyAnimations[1].SetActive(true);
    }

    public void ReturnEnemyAnim()
    {
        enemyAnimations[0].SetActive(true);
        enemyAnimations[1].SetActive(false);

        RandomBattleOutcome();
    }

    public void EnemyTakeDamage()
    {
        int damage = Random.Range(25, 35);
        wrathLife.TakeDamage(12);

        if (skillOption.attack == true)//activate more damage when skill
        {
            wrathLife.TakeDamage(damage);
            skillOption.attack = false;
        }
        Debug.Log(damage);


    }
    public void PlayerTakeDamage()
    {

        int damage = Random.Range(10, 20);
        if (skillOption.shield == false)//immune damage if shielded
        {
            PlayerStats.Instance.PHealth -= damage;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);

        }
        else if (skillOption.shield == true)
        {
            skillOption.shield = false;
        }
    }


    public void PlayGame()
    {
        cameraSwitch.PrideLustCameraMiniGame();
        camera.orthographic = true;
        // game.SetActive(true);
        int rnd = Random.Range(0, gameplays.Length); // Dynamically handle array size
        gameplays[rnd].SetActive(true);

    }

    #region Basics
    public void ReturnAll()
    {
        skillOption.HideShield();
        cameraSwitch.FightScene();
        // game.SetActive(false);
        gameplays.ToList().ForEach(x =>
        {
            x.SetActive(false);
        });
        senemyLife.SetActive(true);


        timeCode.countdownTimer = timeCode.initialCountdownDuration;

        mainUIs.ToList().ForEach(x =>
        {
            x.SetActive(true);
        });
        camera.orthographic = false;
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
