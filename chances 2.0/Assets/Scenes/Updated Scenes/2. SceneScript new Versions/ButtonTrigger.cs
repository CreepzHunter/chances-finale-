using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonTrigger : MonoBehaviour
{
    public GameObject Button;
    public int scene;

    public void nextscene()
    {
        SceneManager.LoadScene(scene);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Button.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Button.SetActive(false);
        }
    }
}
