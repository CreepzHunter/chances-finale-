using UnityEngine;

[CreateAssetMenu(menuName = "GameData/PlayerStat")]
public class PlayerStat : ScriptableObject
{
    public string key = "PlayerHealth";
    public float value = 100f;

    public void Load()
    {
        value = PlayerPrefs.GetFloat(key, value);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }
}
