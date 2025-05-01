using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public static ItemStats Instance;

    public int smallBottle = 0;
    public int largeBottle = 0;
    public int smallMedkit = 0;
    public int largeMedkit = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { // to prevent dupl.
            Destroy(gameObject);
        }
        // SetItemPrefs();
    }

    void SetItemPrefs()
    {
        PlayerPrefs.SetInt("SmallBottle", smallBottle);
        PlayerPrefs.SetInt("LargeBottle", largeBottle);
        PlayerPrefs.SetInt("SmallMedkit", smallMedkit);
        PlayerPrefs.SetInt("LargeMedkit", largeMedkit);

        PlayerPrefs.Save();
    }
}
