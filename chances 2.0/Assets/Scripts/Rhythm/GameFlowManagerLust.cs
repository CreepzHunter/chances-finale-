using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameFlowManagerLust : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] gameButton;
    public GameObject[] returnAll;


    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;

    [SerializeField] private GameObject lustIdle;
    [SerializeField] private GameObject lustAttack;
    [SerializeField] private GameObject lustDead;


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
        }
    }

    public void StartGame()
    {
        cameraSwitch.PlayerView();

        HideAttack();

        AttackGameplay();

        playerBack.SetActive(false);
        playerFront.SetActive(true);

        Invoke("AnimateAttack", 1.5f);
        Invoke("SlothCam", 2.5f);
        musicAnalyzer.Play();

    }
    public void AttackGameplay()
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

        Invoke("AnimateAttack", 1.5f);
        Invoke("SlothCam", 2.5f);
        musicAnalyzer.Play();


    }

    public void WinLevel()
    {
        musicAnalyzer.StopMusicAnalyzer();
        gameManagerRhythm.currentScore = 0;
        gameManagerRhythm.currMultiplier = 1;

        lustLife.TakeDamage(35f);

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
        gameManagerRhythm.currentScore = 0;
        gameManagerRhythm.currMultiplier = 1;

        int random0to10 = Random.Range(0, 13);
        healthSystemPlayer.TakeDamage(random0to10);

        Invoke("ReturnAll", 1f);
    }

    private void AnimateAttack()
    {
        cameraSwitch.EnemyPosition();

        //enemy attack animation
        lustIdle.SetActive(false);
        lustAttack.SetActive(true);

        playerBack.SetActive(true);
        playerFront.SetActive(false);

    }

    private void SlothCam()
    {
        cameraSwitch.LustGameplay();
        gameLife.EnableRhythm();

    }


    #region Basics
    public void ReturnAll()
    {
        gameplayLife.health = 100;
        gameManagerRhythm.stopGame = false;
        gameManagerRhythm.hasWon = false;
        musicAnalyzer.shouldStop = false;


        cameraSwitch.FightScene();
        gameLife.DisableRhythm();
        lustAttack.SetActive(false);

        returnAll.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });

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
