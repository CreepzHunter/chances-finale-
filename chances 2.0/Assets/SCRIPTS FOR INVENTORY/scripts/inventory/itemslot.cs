using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemslot : MonoBehaviour, IPointerClickHandler
{
    //====ITEM DATA====//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField] private int maxNumber;

    //====ITEM SLOT====//
    [SerializeField]private TMP_Text quantityText;
    [SerializeField]private Image itemImage;

    //====ITEM DESCRIPTION SLOT====//
    public Image itemDescImage;
    public TMP_Text itemDescName;
    public TMP_Text itemDesc;

    //====GAMEOBJECT AND SCRIPT REFERENCES====//
    public GameObject selectedShader;
    public bool itemSelected;
    private itemmanager itemmanager;

    private void Start()
    {
        itemmanager = GameObject.Find("Canvas").GetComponent<itemmanager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //check if slot is full
        if(isFull)
        return quantity;

        //update Name
        this.itemName = itemName;
        
        //update sprite
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        
        //update description
        this.itemDescription = itemDescription;
        
        //update quantity
        this.quantity += quantity;
        if(this.quantity >= maxNumber)
        {
            quantityText.text = maxNumber.ToString();
            quantityText.enabled = true;
            isFull = true;
        
        
            //return leftover
            int extraItems = this.quantity - maxNumber;
            this.quantity = maxNumber;
            return extraItems;
        }

        //update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (itemSelected)
        {
            // Attempt to use the item through the item manager
            bool usable = itemmanager.UseItem(itemName);

            // If the item was used successfully, do not call DeductQuantity here
            if (!usable)
            {
                Debug.Log("Item could not be used.");
            }
        }
        else
        {
            // Deselect all other slots and select this one
            itemmanager.DeselectAllSlot();
            selectedShader.SetActive(true);
            itemSelected = true;

            // If this slot is empty, call EmptySlot
            if (string.IsNullOrEmpty(itemName))
            {
                EmptySlot(); // Clear the UI since it's an empty slot
            }
            else
            {
                // Update item description in the UI
                if (itemDescName != null)
                {
                    itemDescName.text = itemName;
                }
                else
                {
                    Debug.LogError("itemDescName is not assigned in the inspector.");
                }

                if (itemDesc != null)
                {
                    itemDesc.text = itemDescription;
                }
                else
                {
                    Debug.LogError("itemDesc is not assigned in the inspector.");
                }

                if (itemDescImage != null)
                {
                    itemDescImage.sprite = itemSprite;
                }
                else
                {
                    Debug.LogError("itemDescImage is not assigned in the inspector.");
                }
            }
        }
    }

    public void OnRightClick()
    {

    }

    public void DeductQuantity()
{
    if (quantity > 0) 
    {
        quantity -= 1; 
        quantityText.text = quantity.ToString();

        
        if (quantity <= 0)
        {
            EmptySlot(); // Clear the slot
        }
    }
}

    private void EmptySlot()
    {
        itemName = "";
        quantity = 0;  
        
        quantityText.enabled = false; 
        itemImage.sprite = emptySprite;

        itemDescName.text = ""; 
        itemDesc.text = "";
        itemDescImage.sprite = emptySprite;
        isFull = false; 
    }
}
