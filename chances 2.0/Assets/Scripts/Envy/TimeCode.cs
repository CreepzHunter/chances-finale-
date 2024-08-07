using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class TimeCode : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public HealthSystemPlayer healthSystemPlayer;
    public HealthSystem enemyHealthSystem;
    public GameManagerEnvyNew gameManagerEnvy;
    public GameManagerSloth gameManagerSloth;
    public Enemy enemy;
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
        if (countdownTimer == 0 && !loseIndicator)
        {
            int random0to10 = Random.Range(0, 11);
            healthSystemPlayer.TakeDamage(random0to10);

            if (gameManagerEnvy != null) { 
            
            gameManagerEnvy.ReturnAll();

            }
            loseIndicator = true;
            hideGameplay.SetActive(false);
            if(gameManagerSloth != null)
            {
                gameManagerSloth.ReturnAll();

                if (enemyHealthSystem.health >= 66)
                {
                    countdownTimer = 20.0f;
                }
                else if (enemyHealthSystem.health < 66 && enemyHealthSystem.health >= 33)
                {
                    countdownTimer = 15f;

                }
                else if (enemyHealthSystem.health < 33 && enemyHealthSystem.health > 1)
                {
                    countdownTimer = 30f;
                }
                loseIndicator = false;
                gameManagerSloth.check = false;
                enemy.OriginalColor();

            }

            gameplays.ToList().ForEach(gameplay =>
            {
                gameplay.SetActive(false);
            });
        }


    }

    public void ResetTimer()
    {
        countdownTimer = initialCountdownDuration;
        currentCountdownDuration = initialCountdownDuration;
    }
}
