using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameManagerGreedPride : MonoBehaviour
{
    public HealthSystem GreedLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public SkillOption skillOption;
    public TimeCode timeCode;


    [SerializeField] private GameObject playerLife;
    [SerializeField] private GameObject senemyLife;
    [SerializeField] private GameObject skillOptionContainer;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject greedBoss;
    private bool hasDied = false;
    public bool check = false;
    public GameObject[] playerAnimations;
    public GameObject[] enemyAnimations;
    public GameObject[] mainButtons;




    public void OnClickAttack()
    {

        if (GreedLife.health != 0)
        {
            Debug.Log("attack ");

            cameraSwitch.PlayerView();
            HideAttack();

            playerLife.SetActive(false);
            senemyLife.SetActive(false);
            skillOptionContainer.SetActive(false);

            playerAnimations[0].SetActive(false);
            playerAnimations[1].SetActive(true);

            //return animation
            Invoke("ReturnAnimation", 1f);
        }
    }

    public void ReturnAnimation()
    {
        cameraSwitch.FightScene();
        playerAnimations[0].SetActive(true);
        playerAnimations[1].SetActive(false);

        EnemyAnimAttack();

        //play game
        Invoke("PlayGame", 1.3f);
    }

    public void EnemyAnimAttack()
    {
        cameraSwitch.EnemyPosition();
        enemyAnimations[0].SetActive(false);
        enemyAnimations[3].SetActive(false);

        enemyAnimations[1].SetActive(true);
        enemyAnimations[4].SetActive(true);
    }


    public void PlayGame()
    {
        cameraSwitch.PrideLustCameraMiniGame();
        game.SetActive(true);
    }

    #region Basics
    public void ReturnAll()
    {
        cameraSwitch.FightScene();
        timeCode.countdownTimer = timeCode.initialCountdownDuration;

        mainButtons.ToList().ForEach(x =>
        {
            x.SetActive(true);
        });
    }
    private void HideAttack()
    {
        mainButtons.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
    #endregion
}
