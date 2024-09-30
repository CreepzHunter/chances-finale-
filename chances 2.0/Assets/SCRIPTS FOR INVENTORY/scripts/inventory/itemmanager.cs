using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmanager : MonoBehaviour
{
    public itemslot[] itemslot;

    public ItemSO[] itemSOs; 

    public PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UseItem(string itemName)
    {
        Debug.Log("UseItem called with itemName: " + itemName);
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                Debug.Log($"Using item: {itemName}");

                bool usable = itemSOs[i].UseItem(playerHealth);
                Debug.Log($"Item usability for {itemName}: {usable}");

                if (usable)
                {
                    foreach (var slot in itemslot)
                    {
                        if (slot.itemName == itemName)
                        {
                            Debug.Log("Deducting quantity from slot");
                            slot.DeductQuantity();
                            return true;
                        }
                    }
                    Debug.LogWarning("Item slot not found for: " + itemName);
                }
                else
                {
                    Debug.Log("Item could not be used.");
                    return false; // Item was not usable
                }
            }
        }
        Debug.LogWarning("Item not found: " + itemName);
        return false; // If the item was not found
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            //Check if slot is either empty or can stack this item
            if (!itemslot[i].isFull && (itemslot[i].itemName == itemName || itemslot[i].quantity == 0))
            {
                // Add item to this slot and return leftover items (if any)
                int leftOverItems = itemslot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                //If no leftover items, we can stop the recursion
                if (leftOverItems <= 0)
                {
                    return 0;
                }
                else
                {
                    //If there are leftover items, attempt to add them to another slot
                    quantity = leftOverItems;
                }
            }
        }

        // If no slot could fit all the items, return the remaining quantity
        return quantity;
    }

    public void DeselectAllSlot()
    {
        for (int i = 0; i < itemslot.Length; i++)
        {
            itemslot[i].selectedShader.SetActive(false);
            itemslot[i].itemSelected = false;
        }
    }
}
