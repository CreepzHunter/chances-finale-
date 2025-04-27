using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystemPlayer : MonoBehaviour
{

    public Image healthBar;
    public float health = 50;

    public void Update()
    {
        healthBar.fillAmount = health / 50;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, 50);
    }

    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 50);

    }
}
