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
    public GameObject[] Box;
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
            hasDied = true;

            slothIdle.SetActive(false);
            slothDead.SetActive(true);
            // Invoke("LoadOverWorld", 0.8f);


            PlayerPrefs.Save();
            Invoke("PostBattle", 1.06f);

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

        if (cockroachLife.health <= 0)
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
        PlayerStats.Instance.Money += 40;
        PlayerPrefs.SetInt("Money", PlayerStats.Instance.Money);
        PlayerStats.Instance.AllocationStats += 2;
        PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats);
        ItemStats.Instance.smallMedkit++;
        PlayerPrefs.SetInt("SmallMedkit", ItemStats.Instance.smallMedkit);


        PlayerPrefs.Save();
        SceneManager.LoadScene(31);
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

            cameraSwitch.PlayerView();
            HideAttack();
            // ckenemyLife.SetActive(false);
            // playerLife.SetActive(false);
            // senemyLife.SetActive(false);


            playerBack.SetActive(false);
            playerFront.SetActive(true);

            //Cockroach Damage ***
            int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

            if (skillOption != null && skillOption.attack == true)
            {
                totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
                skillOption.attack = false;
            }

            cockroachLife.TakeDamage(Random.Range(totalDamage, totalDamage + 10));

            //***
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
                    //Sloth Damage ***
                    int totalDamage = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);

                    if (skillOption != null && skillOption.attack == true)
                    {
                        totalDamage += PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
                        skillOption.attack = false;
                    }

                    slothLife.TakeDamage(totalDamage);

                    //***
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

    public void PlayerBlinkAnim()
    {
        startBlinkingAnim.StartBlinking(3);
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
        Camera.main.orthographic = false;

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
        AttackCk();
        Invoke("DelayCameraCK", 1.2f);




        playerBack.SetActive(true);
        playerFront.SetActive(false);

        Invoke("DisableAttackCk", 1.0f);


        // Damage Player
        int damageToPlayer = Random.Range(5, 15);
        if (!skillOption.shield)
        {



            //  Damage Player *** 

            PlayerStats.Instance.PHealth -= damageToPlayer;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);

            // ***

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
        Camera.main.orthographic = true;

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
        float healthPercent = (float)slothLife.health / slothLife.maxHealth;

        if (healthPercent >= 0.66f)
        {
            Box[0].SetActive(true);


            slothGameplay[0].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 20f;
        }
        else if (healthPercent >= 0.33f)
        {
            Box[1].SetActive(true);

            slothGameplay[1].SetActive(true);
            timeCodeGO.SetActive(true);
            timeCode.initialCountdownDuration = 35f;
        }
        else if (healthPercent > 0f)
        {
            timeCode.initialCountdownDuration = 50f;
            slothGameplay[2].SetActive(true);
            timeCodeGO.SetActive(true);
            Box[2].SetActive(true);

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
            SetTransform(slothIdle.transform,
                new Vector3(2.75097656f, 5.46099854f, 3.22000003f),
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
