using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlinkingAnim : MonoBehaviour
{
    [SerializeField] private GameObject[] boss;
    private SpriteRenderer[] spriteRenderers;
    private bool[] isRed;
    private Color origColor = new Color(1f, 1f, 1f, 1f);

    private void Awake()
    {
        spriteRenderers = new SpriteRenderer[boss.Length];
        isRed = new bool[boss.Length];

        for (int i = 0; i < boss.Length; i++)
        {
            spriteRenderers[i] = boss[i].GetComponent<SpriteRenderer>();
        }
    }

    void Blink(int index)
    {
        if (spriteRenderers[index] != null)
        {
            spriteRenderers[index].color = isRed[index] ? origColor : Color.red;
            isRed[index] = !isRed[index];
        }
    }

    public void StartBlinking(int index)
    {
        StartCoroutine(BlinkRoutine(index));
    }

    private IEnumerator BlinkRoutine(int index)
    {
        float blinkDuration = 1.2f;
        float blinkInterval = 0.1f;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            Blink(index);
            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        StopBlinking(index);
    }

    void StopBlinking(int index)
    {
        if (spriteRenderers[index] != null)
        {
            spriteRenderers[index].color = origColor;
            isRed[index] = false;
        }
    }
}
