using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{

    public int diamond = 3;
    public Image[] dm;

    public Sprite full;
    public Sprite empty;

    void Update()
    {
        diamond = Mathf.Clamp(diamond, 0, 3);

        if(diamond <= 3)
        {
            foreach (var item in dm)
            {
                item.sprite = empty;
            }
            for (int i = 0; i < diamond; i++)
            {
                dm[i].sprite = full;
            }
        }
      
    }

}
