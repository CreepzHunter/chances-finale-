using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameFlowManagerLust : MonoBehaviour
{
    public GameObject[] videos;
    public GameObject[] levels;
    public GameObject[] gameButton;
    public GameObject[] returnAll;


    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;

    [SerializeField] private GameObject lustIdle;
    [SerializeField] private GameObject lustAttack;
    [SerializeField] private GameObject lustDead;

    public SkillOption skillOption;
    public HealthSystemPlayer healthSystemPlayer;
    public HealthSystem lustLife;
    public HealthSystem gameplayLife;
    public CameraSwitch cameraSwitch;
    public Button startButton;
    public GameManagerRhythm gameManagerRhythm;
    public DisableRhythmHealth gameLife;
    public BeatScroller beatScroller;
    private MusicAnalyzer musicAnalyzer;
    private int currentLevel = 0;
    public GameObject gameover;
    public StartBlinkingAnim blink;
    void Start()
    {
        gameLife.DisableRhythm();
        lustIdle.SetActive(true);
        lustDead.SetActive(false);

        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
    }

    void Update()
    {
        if (lustLife.health == 0)
        {
            //dead here
            lustIdle.SetActive(false);
            lustDead.SetActive(true);

            // Invoke("LoadOverWorld", 0.8f);
            Invoke("PostBattle", 1.06f);
            PlayerPrefs.Save();

        }
        //player dead
        if (PlayerStats.Instance.PHealth == 0)
        {
            gameover.SetActive(true);

            // Invoke("LoadOverWorld", 1.06f);
            Invoke("PostBattle", 1.06f);
            PlayerPrefs.Save();

        }

    }
    private void DemoWorld()
    {
        SceneManager.LoadScene(17);
    }
    private void LoadOverWorld()
    {
        SceneManager.LoadScene(1);
    }
    private void PostBattle()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(34);
    }
    public void StartGame()
    {
        // cameraSwitch.PlayerView();

        HideAttack();

        //animate player
        videos[0].SetActive(true);

        Invoke("DisableAttackAnim", 3.8f);

        int number = Random.Range(0, 2);

        if (number == 0)
        {
            // damage enemy
            int attackpower = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

            lustLife.TakeDamage(attackpower);
            blink.StartBlinking(0);

            Invoke("ReturnAll", 4f);
        }
        else if (number == 1)
        {
            Invoke("PlayGame", 4f);

        }
    }


    public void PlayGame()
    {
        if (lustLife.health >= 66)
        {
            levels[0].SetActive(true);
            musicAnalyzer = levels[0].GetComponent<MusicAnalyzer>();
        }
        else if (lustLife.health < 66 && lustLife.health >= 33)
        {
            levels[1].SetActive(true);
            musicAnalyzer = levels[1].GetComponent<MusicAnalyzer>();

        }
        else if (lustLife.health < 33 && lustLife.health >= 1)
        {
            levels[2].SetActive(true);
            musicAnalyzer = levels[2].GetComponent<MusicAnalyzer>();

        }
        cameraSwitch.LustGameplay();

        SlothCam();

    }

    private void SlothCam()
    {
        //enemy attack
        videos[1].SetActive(true);
        Invoke("DelayLustAnim", 3f);
        gameLife.EnableRhythm();
        HideAttack();

        musicAnalyzer.Play();
    }
    private void DelayLustAnim()
    {
        videos[1].SetActive(false);
    }


    public void WinLevel()
    {
        musicAnalyzer.StopMusicAnalyzer();
        musicAnalyzer.Reset();
        musicAnalyzer.shouldStop = true;

        gameManagerRhythm.currentScore = 0;
        gameManagerRhythm.currMultiplier = 1;


        int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

        if (skillOption != null && skillOption.attack == true)
        {
            totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
            skillOption.attack = false;
        }

        lustLife.TakeDamage(totalDamage);
        blink.StartBlinking(0);


        if (beatScroller.musicAnalyzer1GO.activeSelf)
        {
            levels[0].SetActive(false);
        }
        else if (beatScroller.musicAnalyzer2GO.activeSelf)
        {
            levels[1].SetActive(false);

        }
        else if (beatScroller.musicAnalyzer3GO.activeSelf)
        {
            levels[2].SetActive(false);
        }

        Invoke("ReturnAll", 1f);
    }

    public void LoseLevel()
    {
        musicAnalyzer.StopMusicAnalyzer();
        musicAnalyzer.Reset();
        musicAnalyzer.shouldStop = true;

        gameManagerRhythm.currentScore = 0;
        gameManagerRhythm.currMultiplier = 1;


        int random0to10 = Random.Range(10, 20);

        PlayerStats.Instance.PHealth -= random0to10;
        PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);

        if (skillOption.shield == false)//immune damage if shielded
        {
            //  Damage Player *** 

            PlayerStats.Instance.PHealth -= random0to10;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);

            // ***

        }
        else if (skillOption.shield == true)
        {
            skillOption.shield = false;
        }


        Invoke("ReturnAll", 1f);
    }




    #region Basics
    public void ReturnAll()
    {

        skillOption.HideShield();
        gameplayLife.health = 100;
        gameManagerRhythm.stopGame = false;
        gameManagerRhythm.hasWon = false;
        if (musicAnalyzer != null)
            musicAnalyzer.shouldStop = false;


        cameraSwitch.FightScene();
        gameLife.DisableRhythm();
        lustAttack.SetActive(false);

        returnAll.ToList().ForEach(button =>
        {
            Debug.Log("worked");

            button.SetActive(true);
        });

    }

    private void DisableAttackAnim()
    {
        videos[0].SetActive(false);
    }
    private void HideAttack()
    {
        gameButton.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
    #endregion

}
