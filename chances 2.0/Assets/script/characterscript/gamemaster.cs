using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemaster : MonoBehaviour
{
    private static gamemaster instance;

    public Vector3 defaultStartPosition = new Vector3(2f, 0f, 2f); // <- Set your custom default here
    public Vector3 lastcheckpointpos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCheckpoint();
            MovePlayerToCheckpoint();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveCheckpoint(Vector3 newPos)
    {
        lastcheckpointpos = newPos;

        PlayerPrefs.SetFloat("CheckpointX", newPos.x);
        PlayerPrefs.SetFloat("CheckpointY", newPos.y);
        PlayerPrefs.SetFloat("CheckpointZ", newPos.z);
        PlayerPrefs.Save();
    }

    private void LoadCheckpoint()
    {
        if (PlayerPrefs.HasKey("CheckpointX") && PlayerPrefs.HasKey("CheckpointY") && PlayerPrefs.HasKey("CheckpointZ"))
        {
            float x = PlayerPrefs.GetFloat("CheckpointX");
            float y = PlayerPrefs.GetFloat("CheckpointY");
            float z = PlayerPrefs.GetFloat("CheckpointZ");
            lastcheckpointpos = new Vector3(x, y, z);
        }
        else
        {
            lastcheckpointpos = defaultStartPosition;
        }
    }

    private void MovePlayerToCheckpoint()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = lastcheckpointpos;
        }
    }

}
