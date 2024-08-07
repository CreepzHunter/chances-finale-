using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthSystemDuplicate : MonoBehaviour
{

    public HealthSystem healthSystem;
    public Image healthBar;

    public float heathCR;
    public void Update()
    {

        heathCR = healthSystem.health;
        healthBar.fillAmount = heathCR / 100f;

    }


}
