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
    public GameManagerEnvyNew gameManagerEnvy;
    public GameManagerSloth gameManagerSloth;
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
            gameManagerEnvy.ReturnAll();

            loseIndicator = true;
            hideGameplay.SetActive(false);

            gameManagerSloth.ReturnAll();
            gameManagerSloth.check = false;

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
