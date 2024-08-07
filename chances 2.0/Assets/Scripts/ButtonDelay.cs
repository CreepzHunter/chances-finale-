using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonDelay : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        yourButton.onClick.AddListener(() => StartCoroutine(DelayedAction()));
    }

    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Button Pressed after delay");
    }
}
