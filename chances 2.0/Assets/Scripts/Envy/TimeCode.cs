using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class TimeCode : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public SkillOption skillOption;
    public HealthSystemPlayer healthSystemPlayer;
    public GameManager gameManager;
    public GameManagerEnvyNew gameManagerEnvy;
    public GameManagerSloth gameManagerSloth;
    public GameManagerGreedPride gameManagerGreedPride;
    public HealthSystem miniGameLife;
    public Image bar;
    public float initialCountdownDuration = 30f; // Initial countdown duration
    public float countdownTimer;
    public float currentCountdownDuration;
    public GameObject lose;
    public GameObject hideGameplay;
    public bool loseIndicator;
    public GameObject[] gameplays;


    void Start()
    {
        countdownTimer = initialCountdownDuration;
        currentCountdownDuration = initialCountdownDuration;
    }

    void Update()
    {
        // Update countdown timer
        countdownTimer -= Time.deltaTime;
        countdownTimer = Mathf.Max(0, countdownTimer);

        // Update UI
        int secondsLeft = Mathf.CeilToInt(countdownTimer);
        countdownText.text = secondsLeft.ToString();
        bar.fillAmount = countdownTimer / currentCountdownDuration;

        //lose
        if (countdownTimer == 0)
        {

            //Player Life Damage
            int rndm = Random.Range(10, 25);

            skillOption.HideShield();
            //Shield

            //Envy
            if (gameManagerEnvy != null)
            {
                if (skillOption.shield == false)
                {
                    healthSystemPlayer.TakeDamage(rndm);
                }
                else if (skillOption.shield == true)
                {
                    skillOption.shield = false;
                }

                gameManagerEnvy.ReturnAll();
                gameManager.ClearPuzzles();
                gameManager.ResetGame();
                hideGameplay.SetActive(false);

            }


            //Sloth
            if (gameManagerSloth != null)
            {
                if (skillOption.shield == false)
                {
                    healthSystemPlayer.TakeDamage(rndm);
                }
                else if (skillOption.shield == true)
                {
                    skillOption.shield = false;
                }
                gameManagerSloth.ReturnAll();
                gameManagerSloth.check = false;
            }

            //Pride & Greed
            if (gameManagerGreedPride != null)
            {
                if (miniGameLife.health <= 0)
                {
                    //damages player 
                    gameManagerGreedPride.PlayerTakeDamage();
                }
                else
                {
                    //enemy takes damage
                    gameManagerGreedPride.EnemyTakeDamage();
                }
                gameManagerGreedPride.ReturnAll();

            }


            gameplays.ToList().ForEach(gameplay =>
            {
                gameplay.SetActive(false);
            });

            ResetTimer();
        }


    }

    public void ResetTimer()
    {
        countdownTimer = initialCountdownDuration;
        currentCountdownDuration = initialCountdownDuration;
    }
}
