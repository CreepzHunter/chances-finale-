using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public int sceneBuildIdIndex;
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneBuildIdIndex, LoadSceneMode.Single);
        }
    }
}
