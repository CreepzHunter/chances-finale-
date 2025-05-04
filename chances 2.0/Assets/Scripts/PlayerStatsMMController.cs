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
    public TMP_Text allocatePoints;
    public TMP_Text money;
    public GameObject buttons;

    void Update()
    {
        CheckAllocationStats();

        int currentHealth = PlayerPrefs.GetInt("PHealth", PlayerStats.Instance.PHealth);
        int maxHealth = PlayerPrefs.GetInt("MaxPHealth", PlayerStats.Instance.MaxPHealth);

        int attack = PlayerPrefs.GetInt("AttackPower", PlayerStats.Instance.AttackPower);
        int magic = PlayerPrefs.GetInt("MagicPower", PlayerStats.Instance.MagicPower);
        int skillStat = PlayerPrefs.GetInt("PSkill", PlayerStats.Instance.PSkill);
        int life = PlayerPrefs.GetInt("PlayerLife", PlayerStats.Instance.PlayerLife);
        int allocatePts = PlayerPrefs.GetInt("AllocationStats", PlayerStats.Instance.AllocationStats);
        int moneY = PlayerPrefs.GetInt("Money", PlayerStats.Instance.Money);


        health.text = currentHealth.ToString() + "/" + maxHealth.ToString();
        attackpower.text = attack.ToString();
        magicPower.text = magic.ToString();
        skill.text = skillStat.ToString();
        playerLife.text = life.ToString();
        allocatePoints.text = allocatePts.ToString();
        money.text = moneY.ToString();
    }

    #region Allocation Functionality
    public void AllocateMaxHealth()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.MaxPHealth += 20;
            PlayerStats.Instance.PHealth = PlayerStats.Instance.MaxPHealth; // full heal!
            PlayerStats.Instance.AllocationStats -= 1;

            PlayerPrefs.SetInt("MaxPHealth", PlayerStats.Instance.MaxPHealth); // Save MaxPHealth
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth); // Save PHealth
            PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats); // Save AllocationStats

        }
    }

    public void AllocateAttackPower()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.AttackPower += 10;
            PlayerStats.Instance.AllocationStats -= 1;

            PlayerPrefs.SetInt("AttackPower", PlayerStats.Instance.AttackPower);
            PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats); // Save AllocationStats

        }
    }

    public void AllocateMagicPower()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.MagicPower += 20;
            PlayerStats.Instance.AllocationStats -= 1;

            PlayerPrefs.SetInt("MagicPower", PlayerStats.Instance.MagicPower);
            PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats); // Save AllocationStats
        }
    }

    void CheckAllocationStats()
    {
        if (PlayerStats.Instance.AllocationStats <= 0)
        {
            buttons.SetActive(false);
        }
    }
    #endregion

}