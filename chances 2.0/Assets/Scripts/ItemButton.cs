using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject back;
    public void OnClickItem()
    {

        item.SetActive(true);
        back.SetActive(true);

    }
}
