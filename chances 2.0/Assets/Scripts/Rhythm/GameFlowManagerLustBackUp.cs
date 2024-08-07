using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameFlowManagerLustBackUp : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] gameButton;
    public GameObject[] returnAll;


    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;

    [SerializeField] private GameObject lustIdle;
    [SerializeField] private GameObject lustAttack;
    [SerializeField] private GameObject lustDead;


    public HealthSystem lustLife;
    public CameraSwitch cameraSwitch;
    public Button startButton;
    public GameManagerRhythm gameManagerRhythm;
    public DisableRhythmHealth activeStateLife;
    private int currentLevel = 0;

    void Start()
    {
        activeStateLife.DisableRhythm();
        lustIdle.SetActive(true);
        lustDead.SetActive(false);

        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
    }

    public void StartGame()
    {
        cameraSwitch.PlayerView();

        HideAttack();

        levels[currentLevel].SetActive(true);
        currentLevel++;

        playerBack.SetActive(false);
        playerFront.SetActive(true);

        Invoke("AnimateAttack", 2.0f);
        Invoke("SlothCam", 3.5f);


    }

    public void WinLevel()
    {
        // Disable the current level
        Debug.Log("Current level = " + currentLevel);
        levels[currentLevel - 1].SetActive(false);

        // Enable the next level
        if (currentLevel < levels.Length)
        {
            levels[currentLevel].SetActive(true);
            // currentLevel++;
        }
        else
        {
            Debug.Log("All levels completed!");
        }

        Debug.Log("Win current level = " + currentLevel);
        gameManagerRhythm.hasWon = false;
    }


    public void LoseLevel()
    {
        // Disable the current level
        levels[currentLevel].SetActive(false);

        // Stay on the current level
        Debug.Log("Lose");
    }

    private void AnimateAttack()
    {
        cameraSwitch.FightScene();

        //enemy attack animation
        lustIdle.SetActive(false);
        lustAttack.SetActive(true);

        playerBack.SetActive(true);
        playerFront.SetActive(false);

    }

    private void SlothCam()
    {
        cameraSwitch.LustGameplay();

        activeStateLife.EnableRhythm();
    }


    #region Basics
    public void ReturnAll()
    {
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
