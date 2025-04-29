using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusManager : MonoBehaviour
{

    public TMP_Text healthValue;
    public TMP_Text playerlife;
    public TMP_Text pskillText;
    public TMP_Text attackPower;
    public TMP_Text magicPowerText;
    public TMP_Text allocationStats;

    public GameObject buttons;


    void Update()
    {
        //Health
        // UpdateHealthUI();
        UpdateLifeUI();
        CheckHealthState();

        //Skill
        UpdateSkillUI();

        //Attack Power
        UpdateAttackPower();

        //Magic Power
        UpdateMagicPower();

        //Allocation Stats
        UpdateAllocationStats();
    }

    #region Health Part
    // void UpdateHealthUI()
    // {
    //     float current = PlayerStats.Instance.PHealth;
    //     float max = PlayerStats.Instance.MaxPHealth;

    //     PlayerStats.Instance.healthBar.fillAmount = current / max;

    //     if (healthValue != null)
    //         healthValue.text = current + " / " + max;
    // }

    void UpdateLifeUI()
    {
        int life = PlayerStats.Instance.PlayerLife;

        if (playerlife != null)
            playerlife.text = life.ToString();
    }

    void CheckHealthState()
    {
        if (PlayerStats.Instance.PHealth <= 0 && PlayerStats.Instance.PlayerLife > 0)
        {
            PlayerStats.Instance.PlayerLife--;
            PlayerStats.Instance.PHealth = PlayerStats.Instance.MaxPHealth;

            if (PlayerStats.Instance.PlayerLife <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void SkillAddTesting()
    {
        PlayerStats.Instance.PSkill++;
        PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
    }
    public void SkillMinusTesting()
    {
        PlayerStats.Instance.PSkill--;
        PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
    }

    public void ChangeValueTest()
    {
        PlayerStats.Instance.AttackPower = 10;
        PlayerPrefs.SetInt("AttackPower", PlayerStats.Instance.PSkill);
        PlayerStats.Instance.MagicPower = 10;
        PlayerPrefs.SetInt("MagicPower", PlayerStats.Instance.PSkill);
    }
    public void TakeDamage()
    {
        int damage = 10;
        PlayerStats.Instance.PHealth -= damage;
        PlayerStats.Instance.PHealth = Mathf.Clamp(PlayerStats.Instance.PHealth, 0, PlayerStats.Instance.MaxPHealth);

        PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
        Debug.Log("PHealth loaded from PlayerPrefs: " + PlayerPrefs.GetInt("PHealth"));
    }


    public void Heal()
    {
        int heal = PlayerStats.Instance.Heal;
        PlayerStats.Instance.PHealth += Mathf.RoundToInt(heal);
        PlayerStats.Instance.PHealth = Mathf.Clamp(PlayerStats.Instance.PHealth, 0, PlayerStats.Instance.MaxPHealth);

        PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
    }

    #endregion

    #region  Others Display
    //Skill
    void UpdateSkillUI()
    {
        if (pskillText != null)
            pskillText.text = PlayerStats.Instance.PSkill.ToString() + " / 3";
    }
    //Attack Power
    void UpdateAttackPower()
    {
        if (attackPower != null)
            attackPower.text = PlayerStats.Instance.AttackPower.ToString();
        // attackPower.text = PlayerPrefs.GetInt("AttackPower", 0).ToString();

    }
    //Magic Power
    void UpdateMagicPower()
    {
        if (magicPowerText != null)
            magicPowerText.text = PlayerStats.Instance.MagicPower.ToString();
        // magicPowerText.text = PlayerPrefs.GetInt("MagicPower", 0).ToString();

    }

    // Allocation Stats
    void UpdateAllocationStats()
    {
        if (allocationStats != null)
            allocationStats.text = PlayerStats.Instance.AllocationStats.ToString();

        buttons.SetActive(PlayerStats.Instance.AllocationStats > 0);
    }
    #endregion


    #region Allocation Functionality
    public void AllocateMaxHealth()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.MaxPHealth += 20;
            PlayerStats.Instance.PHealth = PlayerStats.Instance.MaxPHealth; // full heal!
            PlayerStats.Instance.AllocationStats -= 1;
            CheckAllocationStats();

            PlayerPrefs.SetInt("MaxPHealth", PlayerStats.Instance.MaxPHealth); // Save MaxPHealth
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth); // Save PHealth
            PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats); // Save AllocationStats

        }
    }

    public void AllocateAttackPower()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.AttackPower += 5;
            PlayerStats.Instance.AllocationStats -= 1;
            CheckAllocationStats();

            PlayerPrefs.SetInt("AttackPower", PlayerStats.Instance.AttackPower);
            PlayerPrefs.SetInt("AllocationStats", PlayerStats.Instance.AllocationStats); // Save AllocationStats

        }
    }

    public void AllocateMagicPower()
    {
        if (PlayerStats.Instance.AllocationStats > 0)
        {
            PlayerStats.Instance.MagicPower += 10;
            PlayerStats.Instance.AllocationStats -= 1;
            CheckAllocationStats();

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
