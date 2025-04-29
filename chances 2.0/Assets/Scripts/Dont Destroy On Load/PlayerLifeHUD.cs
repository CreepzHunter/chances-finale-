using UnityEngine.UI;
using UnityEngine;

public class PlayerLifeHUD : MonoBehaviour
{
    public Image healthBar;

    void Update()
    {
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        float current = PlayerStats.Instance.PHealth;
        float max = PlayerStats.Instance.MaxPHealth;

        healthBar.fillAmount = current / max;

        Debug.Log(PlayerPrefs.GetInt("PHealth"));
    }


}
;
