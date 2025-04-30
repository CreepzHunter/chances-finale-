using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenetochangescene : MonoBehaviour
{
    public int SceneNumber;
    public int SecondsToWait;
    public Animator SceneLoader;

    void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(SecondsToWait);
        SceneLoader.SetTrigger("sceneTrigger");
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
