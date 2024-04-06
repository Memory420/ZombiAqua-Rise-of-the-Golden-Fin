using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    public int maxCapacity = 4; // only 4
    public Item dev_item1;
    public Item dev_item2;
    private void Start()
    {
        UpdateIcons();  
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("AddItem");
            AddItem(dev_item1, 2);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("AddItem");
            AddItem(dev_item2);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Clear");
            ClearInventory();
        }
    }
    public void UpdateInventory()
    {
        UpdateIcons();
        UpdateText();
    }
    public void UpdateText()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            TextMeshProUGUI textMeshProUGUI = slot.GetComponentInChildren<TextMeshProUGUI>();
            if (slot.quantity > 1)
            {
                textMeshProUGUI.text = slot.quantity.ToString();
            }
            else
            {
                textMeshProUGUI.text = "";
            }
        }
    }
    public void UpdateIcons()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            Image slotImage = slot.GetComponentInChildren<Image>();
            if (slot.item != null)
            {
                
                Sprite sprite = Sprite.Create(slot.item.itemTexture2d, new Rect(0.0f, 0.0f, slot.item.itemTexture2d.width, slot.item.itemTexture2d.height), new Vector2(0.5f, 0.5f), 100.0f);
                slotImage.color = new Color(1f, 1f, 1f, 1f);
                slotImage.sprite = sprite;
            }
            else if (slot.item == null)
            {
                slotImage.color = Color.clear;
                slotImage.sprite = null;
            }
        }
    }
    public bool AddItem(Item _item, int _quantity = 1)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.slotType.ToString() == _item.itemType.ToString())
            {
                if (slot.item == null)
                {
                    slot.item = _item;
                    slot.quantity = _quantity;
                    UpdateInventory();
                    return true;
                }
                else if (slot.item == _item)
                {
                    slot.quantity += _quantity;
                    UpdateInventory();
                    return true;
                }
            }
        }
        return false;
    }
    public void ClearInventory()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.item = null;
            slot.quantity = 0;
            slot.text.text = "";
            UpdateInventory();
        }
    }
    public bool DeleteItem(Item _item, int _quantity = 1)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.item == _item && slot.quantity == _quantity)
            {
                slot.item = null;
                slot.quantity = 0;
                slot.text.text = "";
                UpdateInventory();
                return true;
            }
            else if (slot.item == _item && slot.quantity > _quantity)
            {
                slot.quantity -= _quantity;
                if(slot.quantity > 0)
                {
                    slot.text.text = slot.quantity.ToString();
                }
                UpdateInventory();
                return true;
            }
            else if (slot.item == _item && slot.quantity < _quantity)
            {
                return false;
            }
        }
        return false;
    }
}
