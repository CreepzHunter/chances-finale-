using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCuttable : MonoBehaviour
{
    private HealthSystemPlayer healthSystemPlayer;
    private Animator mAnimator;
    private SkillManager skillManager;
    private SpriteRenderer spriteRenderer;
    private GameplayHealth gameplayHealth;

    void Start()
    {
        gameplayHealth = FindObjectOfType<GameplayHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (PlayerStats.Instance.PSkill > 0)
            {
                PlayerStats.Instance.PSkill--;
                PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
            }
            mAnimator.SetTrigger("Boom");

            float rnd = Random.Range(30f, 40f);
            gameplayHealth.TakeDamage(rnd);
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
