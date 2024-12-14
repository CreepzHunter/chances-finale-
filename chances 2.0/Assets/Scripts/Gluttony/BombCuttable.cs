using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCuttable : MonoBehaviour
{
    private HealthSystemPlayer healthSystemPlayer;
    private Animator mAnimator;
    private SkillManager skillManager;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer
        healthSystemPlayer = FindObjectOfType<HealthSystemPlayer>();
        skillManager = FindObjectOfType<SkillManager>();
        mAnimator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cut")
        {
            // deduct life and skill
            if (healthSystemPlayer.health > 0)
            {
                healthSystemPlayer.health -= 10;
            }
            if (skillManager.diamond > 0)
            {
                skillManager.diamond--;
            }
            mAnimator.SetTrigger("Boom");

            //animation here?
            StartCoroutine(FadeAndDestroy());
        }
    }
    IEnumerator FadeAndDestroy()
    {
        float fadeDuration = 4f;  // Time to fade
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
