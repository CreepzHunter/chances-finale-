using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class novelsceneloader : MonoBehaviour
{
    public int sceneBuildIdIndex;
    public int sceneNumber;

    public bool isNextScene = true;

    [SerializeField]
    public sceneinfo sceneinfo;

    private void OnMouseDown()
    {
        Debug.Log("Enter next scene");
        sceneinfo.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneBuildIdIndex, LoadSceneMode.Single);
    }

    public void sceneLoader()
    {
        Debug.Log("Enter next scene");
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Single);
    }
}
