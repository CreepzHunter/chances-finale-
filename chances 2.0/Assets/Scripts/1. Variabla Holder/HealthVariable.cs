using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthVariable : MonoBehaviour
{
    public Image healthBar;
    public PlayerStat health;

    void OnEnable()
    {
        health.Load();
    }

    void Update()
    {
        healthBar.fillAmount = health.value / 100f;
    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
        health.value = Mathf.Clamp(health.value, 0, 100);

        health.Save();
    }

    public void Heal(float heal)
    {
        health.value += heal;
        health.value = Mathf.Clamp(health.value, 0, 100);
        health.Save();

    }
}
