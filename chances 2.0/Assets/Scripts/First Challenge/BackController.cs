using TMPro;
using UnityEngine;

public class BackController : MonoBehaviour
{
    public GameObject[] ToHide;
    public GameObject[] ToShow;
    public BoxController boxController;

    public void ToggleVisibility(bool show)
    {
        gameObject.SetActive(false);

        SetObjectsActivity(show);
        SetChildButtonsActivity(show);
        boxController.ResetNumbers();
    }

    private void SetChildButtonsActivity(bool active)
    {
        foreach (GameObject button in ToHide)
        {
            button.SetActive(active);
        }
    }

    private void SetObjectsActivity(bool active)
    {
        foreach (GameObject obj in ToShow)
        {
            obj.SetActive(true);
        }
    }


}
