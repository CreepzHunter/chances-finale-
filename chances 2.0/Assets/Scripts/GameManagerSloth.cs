using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerSloth : MonoBehaviour
{
    public HealthSystem slothLife;
    public HealthSystem cockroachLife;
    public HealthSystemPlayer healthSystemPlayer;
    public CameraSwitch cameraSwitch;
    public SkillOption skillOption;
    public TimeCode timeCode;
    public Finish finish;
    public Enemy enemy;
    public StartBlinkingAnim startBlinkingAnim;
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
    public GameObject[] videos;
    public GameObject[] slothGameplay;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;
    private Vector3 initialLocation = new Vector3(-957.249023f, -534.539001f, 3.22000003f);
    public GameObject gameover;

    void Awake()
    {
        slothBoss.SetActive(true);
        InitialLoc();
    }

    void Update()
    {

        if (slothLife.health <= 0 && !hasDied)
        {
            slothIdle.SetActive(false);
            slothDead.SetActive(true);

            Invoke("LoadOverWorld", 0.8f);

        }
        if (cockroachLife.health == 0)
        {
            ckIdleenmy.ToList().ForEach(ck =>
            {
                ck.SetActive(false);
            });

            ckAttackenemy.ToList().ForEach(ck =>
            {
                ck.SetActive(false);
            });
            BtnsToShow[4].SetActive(false);
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


    private void DisableDeath()
    {
        slothDead.SetActive(false);
    }

    public void SlothDone()
    {

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
            // ckenemyLife.SetActive(false);
            // playerLife.SetActive(false);
            // senemyLife.SetActive(false);


            playerBack.SetActive(false);
            playerFront.SetActive(true);

            Invoke("AnimateCKAttack", 2.5f);
        }

        else
        {

            ckenemyLife.SetActive(false);
            ckenemy.SetActive(false);

            if (slothLife.health != 0)
            {
                HideAttack();

                videos[0].SetActive(true);

                int number = Random.Range(0, 2);

                if (number == 0)
                {
                    // damage enemy
                    slothLife.TakeDamage(22f);
                    Invoke("DisableVidAttackAnim", 3f);

                }
                else if (number == 1)
                {
                    Invoke("SlothAttack", 4f);

                }
            }
        }
    }

    private void DisableVidAttackAnim()
    {
        videos[0].SetActive(false);
        startBlinkingAnim.StartBlinking(0);

        Invoke("ReturnAll", 1f);


    }

    #region Basics
    public void ReturnAll()
    {
        cameraSwitch.FightScene();
        timeCode.countdownTimer = timeCode.initialCountdownDuration;
        InitialLoc();
        timeCodeGO.SetActive(false);
        enemy.ResetLocation();
        enemy.SetEnemyStateAsleep();

        BtnsToShow.ToList().ForEach(x =>
        {
            x.SetActive(true);
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
    private void DelayCameraCK()
    {
        cameraSwitch.FightScene();

    }
    public void AnimateCKAttack()
    {
        // Perform Cockroach Attack Animation
        AttackCk();
        Invoke("DelayCameraCK", 1.2f);
        // Deal normal damage to the cockroach
        int normalDamage = Random.Range(10, 20);
        cockroachLife.TakeDamage(normalDamage);

        // Deal extra damage if skill attack is active
        if (skillOption.attack)
        {
            cockroachLife.TakeDamage(25f);
            skillOption.attack = false;
        }

        // Update player visuals
        playerBack.SetActive(true);
        playerFront.SetActive(false);

        // Disable Cockroach Attack Animation after 1 second
        Invoke("DisableAttackCk", 1.0f);

        int damageToPlayer = Random.Range(0, 6);
        if (!skillOption.shield)
        {
            healthSystemPlayer.TakeDamage(damageToPlayer);
        }
        else
        {
            skillOption.shield = false;
        }

        // Activate enemy life UI elements
        // ckenemyLife.SetActive(true);
        // senemyLife.SetActive(true);


        Invoke("ReturnAll", 1f);
        Invoke("DelayHide", 1f);
    }


    private void DelayHide()
    {
        skillOption.HideShield();


    }

    private void AttackCk()
    {
        cameraSwitch.EnemyPosition();
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
        startBlinkingAnim.StartBlinking(1);
        startBlinkingAnim.StartBlinking(2);
    }


    #endregion


    #region Sloth Actions


    public void SlothAttack()
    {
        SlothActivate();
        videos[0].SetActive(false);
        videos[1].SetActive(true);
        videos[1].SetActive(true);

        Invoke("SlothShow", 3f);

        HideAttack();
    }
    public void SlothEnable()
    {
        slothBoss.SetActive(true);
    }


    private void SlothShow()
    {
        videos[1].SetActive(false);

        Invoke("SlothCam", 0.3f);
        check = true;

        HideAttack();

        AttackLocSloth();

        LevelChecker();
    }

    private void SlothCam()
    {
        cameraSwitch.SlothGame();

        slothAttack.SetActive(false);
    }

    private void LevelChecker()
    {
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
            timeCode.initialCountdownDuration = 35f;

        }
        else if (slothLife.health < 33 && slothLife.health > 1)
        {
            slothGameplay[2].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 50f;
        }

    }
    private void SlothActivate()
    {
        if (slothLife.health >= 0)
        {
            SetTransform(slothIdle.transform, new Vector3(2.75097656f, 5.46099854f, 3.22000003f), new Quaternion(0.0f, 0.99995363f, 0.0f, 0.00963968f), new Vector3(0.18f, 0.18f, 0.18f));
        }
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
