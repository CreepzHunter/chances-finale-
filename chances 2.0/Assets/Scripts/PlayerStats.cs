
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    //Health
    public int PHealth = 100;
    public int MaxPHealth = 100;
    public int PlayerLife = 3;
    //Skill
    public int PSkill = 3;
    //Attack Power 
    public int AttackPower = 10;
    //Magic Power 
    public int MagicPower = 10;
    public int Heal = 10;
    public int AllocationStats = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { // to prevent dupl.
            Destroy(gameObject);
        }
        GetPlayerPrefs();
    }
    // void LoadPlayerData()
    // {
    //     // Check if each key exists in PlayerPrefs before loading
    //     if (PlayerPrefs.HasKey("PHealth"))
    //         PHealth = PlayerPrefs.GetInt("PHealth");
    //     if (PlayerPrefs.HasKey("MaxPHealth"))
    //         MaxPHealth = PlayerPrefs.GetInt("MaxPHealth");
    //     if (PlayerPrefs.HasKey("PlayerLife"))
    //         PlayerLife = PlayerPrefs.GetInt("PlayerLife");
    //     if (PlayerPrefs.HasKey("PSkill"))
    //         PSkill = PlayerPrefs.GetInt("PSkill");
    //     if (PlayerPrefs.HasKey("AttackPower"))
    //         AttackPower = PlayerPrefs.GetInt("AttackPower");
    //     if (PlayerPrefs.HasKey("MagicPower"))
    //         MagicPower = PlayerPrefs.GetInt("MagicPower");
    //     if (PlayerPrefs.HasKey("AllocationStats"))
    //         AllocationStats = PlayerPrefs.GetInt("AllocationStats");
    // }

    void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt("PHealth", PHealth);
        PlayerPrefs.SetInt("MaxPHealth", MaxPHealth);
        PlayerPrefs.SetInt("PlayerLife", PlayerLife);
        PlayerPrefs.SetInt("PSkill", PSkill);
        PlayerPrefs.SetInt("AttackPower", AttackPower);
        PlayerPrefs.SetInt("MagicPower", MagicPower);
        PlayerPrefs.SetInt("AllocationStats", AllocationStats);

        PlayerPrefs.Save();
    }

    void GetPlayerPrefs()
    {
        PHealth = PlayerPrefs.GetInt("PHealth", PHealth);
        MaxPHealth = PlayerPrefs.GetInt("MaxPHealth", MaxPHealth);
        PlayerLife = PlayerPrefs.GetInt("PlayerLife", PlayerLife);
        PSkill = PlayerPrefs.GetInt("PSkill", PSkill);
        AttackPower = PlayerPrefs.GetInt("AttackPower", AttackPower);
        MagicPower = PlayerPrefs.GetInt("MagicPower", MagicPower);
        AllocationStats = PlayerPrefs.GetInt("AllocationStats", AllocationStats);
    }

}
