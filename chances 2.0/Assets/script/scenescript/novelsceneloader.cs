using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class novelsceneloader : MonoBehaviour
{
    public int SceneNumber;

    private scenestarter scene;

    void Start()
    {
        scene = FindObjectOfType<scenestarter>();
    }



    public void NextScene()
    {
        scene.objectTrue();
        Debug.Log("scene is next");
        StartCoroutine(scenechanger());
    }

    IEnumerator scenechanger()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneNumber);
    }
}
