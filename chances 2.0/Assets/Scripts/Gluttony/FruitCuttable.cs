using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCuttable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator mAnimator;
    [Header("Visuals")]
    [SerializeField] Sprite[] sprites;
    private GameplayHealth gameplayHealth;

    private int fruitType;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mAnimator = GetComponent<Animator>();
        mAnimator.enabled = false;
        gameplayHealth = FindObjectOfType<GameplayHealth>();

        spriteRenderer.sprite = sprites[fruitType];

    }

    public void SetFruitType(int type)
    {
        fruitType = type;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cut"))
        {
            if (mAnimator != null)
            {
                // Set sprite first
                mAnimator.enabled = true;

                // Trigger the animation
                if (fruitType == 0) mAnimator.SetTrigger("Mango");
                else if (fruitType == 1) mAnimator.SetTrigger("Kiwi");
                else if (fruitType == 2) mAnimator.SetTrigger("DragonFruit");
            }

            float randomHeal = Random.Range(5f, 10f);
            gameplayHealth.Heal(randomHeal);

            GetComponent<MoveFood>().MarkAsCut();

            StartCoroutine(FadeAndDestroy());
        }
    }

    IEnumerator FadeAndDestroy()
    {
        float fadeDuration = 0.5f;
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

        Destroy(gameObject);
    }
}
