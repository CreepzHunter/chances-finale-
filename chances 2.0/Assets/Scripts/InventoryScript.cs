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
        ItemStats.Instance.smallBottle = PlayerPrefs.GetInt("SmallBottle", 0);
        ItemStats.Instance.largeBottle = PlayerPrefs.GetInt("LargeBottle", 0);
        ItemStats.Instance.smallMedkit = PlayerPrefs.GetInt("SmallMedkit", 0);
        ItemStats.Instance.largeMedkit = PlayerPrefs.GetInt("LargeMedkit", 0);
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

}
