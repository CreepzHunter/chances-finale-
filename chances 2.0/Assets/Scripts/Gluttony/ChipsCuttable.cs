using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsCuttable : MonoBehaviour
{
    private HealthSystemPlayer healthSystemPlayer;
    private SpriteRenderer spriteRenderer;
    private GameplayHealth gameplayHealth;

    void Start()
    {
        gameplayHealth = FindObjectOfType<GameplayHealth>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSystemPlayer = FindObjectOfType<HealthSystemPlayer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cut")
        {
            // Deduct health if the reference is set
            if (healthSystemPlayer.health >= 0)
            {
                healthSystemPlayer.health -= 10;
            }
            float rnd = Random.Range(15f, 30f);
            gameplayHealth.TakeDamage(rnd);
            StartCoroutine(FadeAndDestroy());
        }
    }
    IEnumerator FadeAndDestroy()
    {
        float fadeDuration = 0.5f;  // Time to fade
        float startAlpha = spriteRenderer.color.a;
        float endAlpha = 0f;

        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, timeElapsed / fadeDuration);
            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;
            yield return null;
        }

        Destroy(gameObject);  // Destroy the object after fading
    }
}
