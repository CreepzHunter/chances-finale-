using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsCuttable : MonoBehaviour
{
    private HealthSystemPlayer healthSystemPlayer;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer
        // Dynamically find the HealthSystemPlayer in the scene
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
            //animation here?

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
