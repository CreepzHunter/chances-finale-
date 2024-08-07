using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerEnvy : MonoBehaviour
{
    public GameManager gameManager1;
    public HealthSystem EnvyLife;
    public HealthSystem SlothLife;
    public CameraSwitch cameraSwitch;
    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;
    //EnvySection
    [SerializeField] private GameObject eenemyLife;
    [SerializeField] private GameObject eenemyAttack;
    [SerializeField] private GameObject eenemyIdle;
    [SerializeField] private GameObject eenemyDeath;
    [SerializeField] private GameObject envyBoss;
    [SerializeField] private GameObject envyGameplay;
    //SlothSection
    [SerializeField] private GameObject senemyLife;
    [SerializeField] private GameObject slothBoss;
    [SerializeField] private GameObject slothIdle;
    [SerializeField] private GameObject slothGameplay;
    [SerializeField] public GameObject slothAttack;
    private bool hasDied = false;
    public bool check = false;

    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;

    void Awake()
    {
        InitialLocSloth();

    }
    void Update()
    {
        if (EnvyLife.health <= 0 && !hasDied)
        {
            hasDied = true;
            EnvyDone();
        }
    }

    public void EnvyDone()
    {

        if (EnvyLife.health >= 0)
        {
            envyBoss.SetActive(true);
        }

        Debug.Log("s  up");

        hasDied = true;


        eenemyIdle.SetActive(false);
        eenemyLife.SetActive(false);

        eenemyDeath.SetActive(true);

        Invoke("EDeathAnim", 1.5f);
        Invoke("SlothIdle", 1.7f);

    }

    private void SlothIdle()
    {
        slothBoss.SetActive(true);
    }

    public void OnClickAttack()
    {
        Debug.Log("Life" + EnvyLife.health);
        if (EnvyLife.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();


            playerBack.SetActive(false);
            playerFront.SetActive(true);
            eenemyLife.SetActive(false);


            Invoke("EAnimatePlayer", 2.0f);
            gameManager1.StartBlinking();

            Invoke("EnvyAttack", 3f);
        }
        else if (SlothLife.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            SlothLife.TakeDamage(20);

            playerBack.SetActive(false);
            playerFront.SetActive(true);
            senemyLife.SetActive(false);

            Invoke("AnimateAttack", 2.0f);

            Invoke("SlothAttack", 3f);
        }
    }

    #region Basics
    public void ReturnAll()
    {
        eenemyAttack.SetActive(false);

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
        if (EnvyLife.health != 0)
        {
            eenemyLife.SetActive(true);
        }

        eenemyLife.SetActive(true);
    }

    private void EnvyShow()
    {
        envyGameplay.SetActive(true);
    }

    #endregion

    #region Sloth Actions

    public void InitialLocSloth()
    {
        SetTransform(slothIdle.transform, new Vector3(2.75097656f, 5.46099854f, 3.22000003f), new Quaternion(0f, 0.99995363f, 0f, 0.00963968f), new Vector3(0.18f, 0.18f, 0.18f));
    }

    private void AnimateAttack()
    {
        cameraSwitch.FightScene();

        playerBack.SetActive(true);
        playerFront.SetActive(false);

        cameraSwitch.EnemyPosition();


        slothIdle.SetActive(false);
        slothAttack.SetActive(true);

        senemyLife.SetActive(true);

    }

    private void SlothAttack()
    {
        SlothActivate();

        Invoke("SlothShow", 0.5f);

        HideAttack();
    }
    public void SlothEnable()
    {
        slothBoss.SetActive(true);
    }

    private void SlothActivate()
    {
        if (SlothLife.health >= 0)
        {
            SetTransform(slothIdle.transform, new Vector3(2.75097656f, 5.46099854f, 3.22000003f), new Quaternion(0.0f, 0.99995363f, 0.0f, 0.00963968f), new Vector3(0.18f, 0.18f, 0.18f));
        }
    }
    private void SlothShow()
    {
        Invoke("SlothCam", 0.3f);
        check = true;

        slothIdle.SetActive(true);


        AttackLocSloth();

        slothGameplay.SetActive(true);
    }

    private void SlothCam()
    {
        cameraSwitch.SlothGame();
    }

    public void AttackLocSloth()
    {
        SetTransform(slothIdle.transform, new Vector3(5.22998047f, 2.98999023f, -4.15999985f), Quaternion.Euler(0f, 0.99995363f, 0f), new Vector3(0.653822601f, 0.653822601f, 0.653822601f));
    }
    private void SetTransform(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }

    #endregion



}
