using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite itemSprite;

    [TextArea]
    [SerializeField] private string itemDescription;

    public GameObject BItem;
    private itemmanager itemmanager;
    
    void Start()
    {
        itemmanager = GameObject.Find("Canvas").GetComponent<itemmanager>();
    }

    // Update is called once per frame
    public void take()
    {
        int leftOverItems = itemmanager.AddItem(itemName, quantity, itemSprite, itemDescription);

        if(leftOverItems <= 0)
        {
            Destroy(BItem);
            Destroy(gameObject);
        }
        
        else
            quantity = leftOverItems;
        
    }
}
