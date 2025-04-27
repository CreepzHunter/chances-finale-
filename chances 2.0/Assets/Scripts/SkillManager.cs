using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Image[] dm;

    public Sprite full;
    public Sprite empty;

    void Start()
    {
        PlayerStats.Instance.PSkill = PlayerPrefs.GetInt("PSkill", PlayerStats.Instance.PSkill);
    }

    void Update()
    {
        // Always use PlayerStats PSkill, not own
        int currentSkill = Mathf.Clamp(PlayerStats.Instance.PSkill, 0, 3);

        if (currentSkill <= 3)
        {
            foreach (var item in dm)
            {
                item.sprite = empty;
            }
            for (int i = 0; i < currentSkill; i++)
            {
                dm[i].sprite = full;
            }
        }
    }
}
