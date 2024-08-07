using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunController : MonoBehaviour
{
    public GameObject[] hide;
    public GameObject[] show;

    public void ToggleVisibility(bool show)
    {
        gameObject.SetActive(false);

        SetObjectsActivity(show);
        SetChildButtonsActivity(show);
    }

    private void SetChildButtonsActivity(bool active)
    {
        foreach (GameObject button in hide)
        {
            button.SetActive(active);
        }
    }

    private void SetObjectsActivity(bool active)
    {
        foreach (GameObject obj in show)
        {
            obj.SetActive(true);
        }
    }
}
