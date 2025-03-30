using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image timerFillImage;
    [SerializeField] private GameplayHealth gameplayHealth;
    [SerializeField] private HealthSystemPlayer healthSystemPlayer;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private AttackGluttony attackGluttony;
    [SerializeField] private StartBlinkingAnim blink;
    [SerializeField] private float health;

    public float spawnTimer = 10f;

    private bool hasEnded = false;
    private float currentTime;

    void OnEnable()
    {
        currentTime = spawnTimer;
    }

    void Update()
    {
        health = gameplayHealth.health;
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            if (!hasEnded)
            {
                hasEnded = true;

                if (health > 0)
                {
                    float rnd = Random.Range(20, 30);
                    attackGluttony.ReturnAll();
                    healthSystem.TakeDamage(rnd);
                    blink.StartBlinking(0);
                }
                else
                {
                    // dmg player
                    float rnd = Random.Range(10, 20);
                    healthSystemPlayer.TakeDamage(rnd);
                    attackGluttony.ReturnAll();
                    blink.StartBlinking(1);

                }
            }
        }
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.Ceil(currentTime).ToString();

        timerFillImage.fillAmount = currentTime / spawnTimer;
    }
}
