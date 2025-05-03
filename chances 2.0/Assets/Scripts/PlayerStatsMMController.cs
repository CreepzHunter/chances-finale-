using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsMMController : MonoBehaviour
{
    public TMP_Text health;
    public TMP_Text attackpower;
    public TMP_Text magicPower;
    public TMP_Text skill;
    public TMP_Text playerLife;

    void Update()
    {
        int currentHealth = PlayerPrefs.GetInt("PHealth", PlayerStats.Instance.PHealth);
        int maxHealth = PlayerPrefs.GetInt("MaxPHealth", PlayerStats.Instance.MaxPHealth);
        int attack = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);
        int magic = PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
        int skillStat = PlayerPrefs.GetInt("PSkill", PlayerStats.Instance.PSkill);
        int life = PlayerPrefs.GetInt("PlayerLife", PlayerStats.Instance.PlayerLife);

        health.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        attackpower.text = attack.ToString();
        magicPower.text = magic.ToString();
        skill.text = skillStat.ToString();
        playerLife.text = life.ToString();
    }

}