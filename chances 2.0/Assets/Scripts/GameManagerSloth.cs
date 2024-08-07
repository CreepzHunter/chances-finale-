using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManagerSloth : MonoBehaviour
{
    public HealthSystem slothLife;
    public HealthSystem cockroachLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public TimeCode timeCode;
    [SerializeField] private GameObject timeCodeGO;
    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerFront;
    [SerializeField] private GameObject playerLife;

    [SerializeField] private GameObject ckenemy;
    [SerializeField] private GameObject[] ckIdleenmy;
    [SerializeField] private GameObject[] ckAttackenemy;
    [SerializeField] private GameObject ckenemyLife;
    [SerializeField] private GameObject senemyLife;
    [SerializeField] private GameObject slothBoss;
    [SerializeField] private GameObject slothIdle;
    [SerializeField] public GameObject slothAttack;
    [SerializeField] public GameObject slothDead;
    private bool hasDied = false;
    public bool check = false;
    public GameObject[] slothGameplay;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;
    private Vector3 initialLocation = new Vector3(-957.249023f, -534.539001f, 3.22000003f);

    void Awake()
    {
        slothBoss.SetActive(true);
        InitialLoc();
    }

    void Update()
    {

        if (slothLife.health <= 0 && !hasDied)
        {
            SlothDone();

            Invoke("DisableDeath", 0.9f);
        }
        if(cockroachLife.health == 0)
        {
            ckenemy.SetActive(false);
            ckIdleenmy.ToList().ForEach(i =>
            {
                i.SetActive(false);

            });

        }

    }

    private void DisableDeath()
    {
        slothDead.SetActive(false);
    }

    public void SlothDone()
    {

        if (slothLife.health >= 0)
        {
            slothBoss.SetActive(true);
        }

        hasDied = true;

        slothBoss.SetActive(false);
        slothDead.SetActive(true);
    }


    public void OnClickAttack()
    {

        if (cockroachLife.health != 0)
        {
            Debug.Log("attack ");

            cameraSwitch.PlayerView();
            HideAttack();

            cockroachLife.TakeDamage(20f);
            playerBack.SetActive(false);
            playerFront.SetActive(true);
            ckenemyLife.SetActive(false);
            playerLife.SetActive(false);
            senemyLife.SetActive(false);

            Invoke("AnimateCKAttack", 2.0f);

        }

        else
        {
            ckenemyLife.SetActive(false);
            ckenemy.SetActive(false);

            if (slothLife.health != 0)
            {
                cameraSwitch.PlayerView();
                HideAttack();

                // slothLife.TakeDamage(20);

                playerBack.SetActive(false);
                playerFront.SetActive(true);

                playerLife.SetActive(false);
                senemyLife.SetActive(false);

                Invoke("AnimateAttack", 2.0f);

                Invoke("SlothAttack", 3f);
            }
        }
    }

    #region Basics
    public void ReturnAll()
    {
        cameraSwitch.FightScene();
        slothAttack.SetActive(false);

        InitialLoc();
        timeCodeGO.SetActive(false);
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


    #region Cockroach

    private void AnimateCKAttack()
    {
        cameraSwitch.FightScene();

        playerBack.SetActive(true);
        playerFront.SetActive(false);

        AttackCk();
        Invoke("DisableAttackCk", 1.0f);

        ReturnAll();
        int random0to10 = Random.Range(0, 6);
        healthSystemPlayer.TakeDamage(random0to10);

        ckenemyLife.SetActive(true);
        senemyLife.SetActive(true);
    }

    private void AttackCk()
    {
        ckIdleenmy.ToList().ForEach(ck =>
        {
            ck.SetActive(false);
        });

        ckAttackenemy.ToList().ForEach(ck =>
        {
            ck.SetActive(true);
        });

    }
    private void DisableAttackCk()
    {
        ckIdleenmy.ToList().ForEach(ck =>
       {
           ck.SetActive(true);
       });

        ckAttackenemy.ToList().ForEach(ck =>
        {
            ck.SetActive(false);
        });
    }


    #endregion


    #region Sloth Actions

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
        if (slothLife.health >= 0)
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

        // Check life to know what level you should be at
        if (slothLife.health >= 66)
        {
            slothGameplay[0].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 20f;
        }
        else if (slothLife.health < 66 && slothLife.health >= 33)
        {
            slothGameplay[1].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 15f;

        }
        else if (slothLife.health < 33 && slothLife.health > 1)
        {
            slothGameplay[2].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 30f;
        }

    }

    private void SlothCam()
    {
        cameraSwitch.SlothGame();
    }

    public void AttackLocSloth()
    {
        SetTransform(slothIdle.transform, new Vector3(5.22998047f, 2.98999023f, -4.15999985f), Quaternion.Euler(0f, 0.99995363f, 0f), new Vector3(0.653822601f, 0.653822601f, 0.653822601f));
    }

    private void InitialLoc()
    {
        if (slothLife.health >= 0)
        {
            SetTransform(slothIdle.transform, new Vector3(2.75097656f, 5.46099854f, 3.22000003f),
                         new Quaternion(0.0f, 0.99995363f, 0.0f, 0.00963968f),
                         new Vector3(0.18f, 0.18f, 0.18f));
        }
    }
    private void SetTransform(Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.localScale = scale;
    }

    #endregion


}
