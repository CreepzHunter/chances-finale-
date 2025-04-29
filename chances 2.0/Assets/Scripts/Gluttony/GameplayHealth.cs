using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHealth : MonoBehaviour
{
    public Image healthBar;
    public int health = 100;
    private HealthSystemPlayer pHealth;
    public AttackGluttony attackGluttony;
    [SerializeField] private StartBlinkingAnim blink;
    [SerializeField] private GameObject game;
    void Start()
    {
        if (pHealth == null)
            pHealth = FindObjectOfType<HealthSystemPlayer>();
    }
    public void Update()
    {
        healthBar.fillAmount = health / 100f;
    }
    void OnEnable()
    {
        health = 100;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            PlayerStats.Instance.PHealth -= Random.Range(20, 35);
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
            //disable game
            game.SetActive(false);
            attackGluttony.ReturnAll();
            blink.StartBlinking(1);

        }

        health -= damage;
        health = Mathf.Clamp(health, 0, 100);

    }

    public void Heal(int heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, 100);

    }
}
