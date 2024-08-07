using System.Linq;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] ToShow;
    public GameObject[] ToHide;
    private bool isActive;


    public void OnClickToggleButtonActivity()
    {
        isActive = !isActive;

        SetButtonActivity();
        SetAdditionalObjectsActivity();
        gameObject.SetActive(false);
    }

    private void SetButtonActivity()
    {
        ToShow.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }

    private void SetAdditionalObjectsActivity()
    {
        ToHide.ToList().ForEach(objToHide =>
         {
             objToHide.SetActive(false);
         });
    }
}

