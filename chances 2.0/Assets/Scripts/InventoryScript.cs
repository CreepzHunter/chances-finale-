using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryScript : MonoBehaviour
{

    public TextMeshProUGUI skillS;
    public TextMeshProUGUI skillM;
    public TextMeshProUGUI healthS;
    public TextMeshProUGUI healthM;

    void OnEnable()
    {
        ItemStats.Instance.smallBottle = PlayerPrefs.GetInt("SmallBottle", ItemStats.Instance.smallBottle);
        ItemStats.Instance.largeBottle = PlayerPrefs.GetInt("LargeBottle", ItemStats.Instance.largeBottle);
        ItemStats.Instance.smallMedkit = PlayerPrefs.GetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
        ItemStats.Instance.largeMedkit = PlayerPrefs.GetInt("LargeMedkit", ItemStats.Instance.largeMedkit);
    }
    void Update()
    {
        UpdateItemValue();
    }

    void UpdateItemValue()
    {
        skillS.text = ItemStats.Instance.smallBottle.ToString();
        skillM.text = ItemStats.Instance.largeBottle.ToString();
        healthS.text = ItemStats.Instance.smallMedkit.ToString();
        healthM.text = ItemStats.Instance.largeMedkit.ToString();
    }

    public void UseSmallBottle()
    {
        if (ItemStats.Instance.smallBottle > 0)
        {
            ItemStats.Instance.smallBottle--;
            PlayerPrefs.SetInt("SmallBottle", ItemStats.Instance.smallBottle);
            PlayerStats.Instance.PSkill++;
            PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
        }
    }

    public void UseLargeBottle()
    {
        if (ItemStats.Instance.largeBottle > 0)
        {
            ItemStats.Instance.largeBottle--;
            PlayerPrefs.SetInt("LargeBottle", ItemStats.Instance.largeBottle);
            PlayerStats.Instance.PSkill += 2;
            PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
        }
    }

    public void UseSmallMedkit()
    {
        if (ItemStats.Instance.smallMedkit > 0)
        {
            ItemStats.Instance.smallMedkit--;
            PlayerPrefs.SetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
            PlayerStats.Instance.PHealth += 15;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
        }
    }

    public void UseLargeMedkit()
    {
        if (ItemStats.Instance.largeMedkit > 0)
        {
            ItemStats.Instance.largeMedkit--;
            PlayerPrefs.SetInt("LargeMedkit", ItemStats.Instance.largeMedkit);
            PlayerStats.Instance.PHealth += 40;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
        }
    }
}
