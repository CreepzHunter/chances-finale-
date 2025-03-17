using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystemPlayer : MonoBehaviour
{

    public Image healthBar;
    public DsplyAnmCntrllr dsplyAnmCntrllr;
    public float health = 50;
    [SerializeField] private Transform transformObj;

    public void Update()
    {
        healthBar.fillAmount = health / 50;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 50);
        if (dsplyAnmCntrllr)
            dsplyAnmCntrllr.DisplayFloatingText(-damage, transformObj);

    }

    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 50);
        if (dsplyAnmCntrllr)
            dsplyAnmCntrllr.DisplayFloatingText(heal, transformObj);

    }
}
