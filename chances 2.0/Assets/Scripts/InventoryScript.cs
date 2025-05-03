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

}
