using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public GameObject[] ToHide;
    public GameObject[] ToShow;
    public GameObject PersuasionLvl; // Reference to the GameObject containing the life value
    public DamageDisplay damageDisplay;
    public BoxController boxController;


    public void Start()
    {
        damageDisplay.gameObject.SetActive(true);
        //boxController.ResetNumbers();
    }
    public void ToggleVisibility(bool show)
    {
        gameObject.SetActive(false);
        SetObjectsActivity(show);
        SetChildButtonsActivity(show);

    }

    private void SetChildButtonsActivity(bool active)
    {
        foreach (GameObject button in ToHide)
        {
            button.SetActive(active);
        }
        damageDisplay.CheckLifeValue(10f);

    }

    private void SetObjectsActivity(bool active)
    {
        foreach (GameObject obj in ToShow)
        {
            obj.SetActive(true);
        }
    }


}
