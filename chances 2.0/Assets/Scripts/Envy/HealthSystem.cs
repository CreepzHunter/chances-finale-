using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public Image healthBar;
    public int health = 100;
    public int maxHealth = 200;
    void Start()
    {
        health = maxHealth;
    }
    public void Update()
    {
        healthBar.fillAmount = (float)health / maxHealth;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);



    }

    public void Heal(int heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);


    }
}
