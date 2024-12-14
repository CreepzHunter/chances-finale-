using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGluttony : MonoBehaviour
{
    [SerializeField] private CameraSwitch cameraSwitch;
    [SerializeField] private HealthSystemPlayer pHealth;
    [SerializeField] private HealthSystem eHealth;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] pAnimations;
    [SerializeField] private GameObject[] eAnimations;
    [SerializeField] private GameObject enemyParent;
    [SerializeField] private GameObject gameplay;

    //

    public void OnClickAttack()
    {
        if (eHealth.health != 0)
        {
            HideButtons();

            //attack anim
            PlayerAnimAttack();
            Invoke("EnemyAnimAttack", 3f);

            //camera switch
            cameraSwitch.SlothGame();
            Camera.main.orthographic = true;
            Invoke("PlayGame", 6.5f);
        }
        else
        {
        }
    }
    public void PlayGame()
    {
        gameplay.SetActive(true);
    }
    public void HandleSpawningStatus(bool isSpawning)
    {
        if (!isSpawning)
        {
            cameraSwitch.FightScene();
            Camera.main.orthographic = false;
            ReturnButtons();
            gameplay.SetActive(false);
        }
    }

    #region Animations
    private void EnemyAnimAttack()
    {
        eAnimations[0].SetActive(true);
        Invoke("ReturnAnimation", 3f);
    }
    private void PlayerAnimAttack()
    {
        pAnimations[0].SetActive(true);
        Invoke("ReturnAnimation", 3f);
    }
    #endregion


    #region Basics
    private void HideButtons()
    {
        foreach (var objToHide in buttons)
        {
            objToHide.SetActive(false);
        }
    }
    private void ReturnButtons()
    {
        foreach (var objToHide in buttons)
        {
            objToHide.SetActive(true);
        }
        Camera.main.orthographic = false;

    }

    private void ReturnAnimation()
    {
        pAnimations[0].SetActive(false);
        eAnimations[0].SetActive(false);

    }
    #endregion

}
