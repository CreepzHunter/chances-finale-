using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlinkingAnim : MonoBehaviour
{

    private bool isRed = false;
    [SerializeField]
    private GameObject boss;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color origColor = new Color(1f, 1f, 1f, 1f);

    public void Awake()
    {

        SpriteRenderer spriteRenderer = boss.GetComponent<SpriteRenderer>();
    }
    void Blink()
    {
        spriteRenderer.color = isRed ? origColor : Color.red;
        isRed = !isRed;
    }

    public void StartBlinking()
    {
        InvokeRepeating("Blink", 0f, 0.1f);
        Invoke("StopBlinking", 2.7f);
    }

    public void StopBlinking()
    {
        CancelInvoke("Blink");
        spriteRenderer.color = origColor;
    }
}
