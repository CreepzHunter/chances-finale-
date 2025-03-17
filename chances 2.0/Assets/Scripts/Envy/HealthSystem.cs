using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public Image healthBar;
    public DsplyAnmCntrllr dsplyAnmCntrllr;
    public float health = 100f;
    [SerializeField] private Transform textSpawnPoint;
    public void Update()
    {
        healthBar.fillAmount = health / 100f;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 100);

        if (dsplyAnmCntrllr && textSpawnPoint)
            dsplyAnmCntrllr.DisplayFloatingText(-damage, textSpawnPoint);

    }

    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 100);

        if (dsplyAnmCntrllr && textSpawnPoint)
            dsplyAnmCntrllr.DisplayFloatingText(heal, textSpawnPoint);
    }
}
