using System.Collections.Generic;
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
            AddItem(dev_item1);
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
    public void UpdateIcons()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.quantity == 0)
            {
                slot.item = null;
                slot.text.text = "";
            }
        }
        foreach (ItemSlot slot in itemSlots)
        {
            Image image = slot.GetComponentInChildren<Image>();

            if (slot.item != null && slot.item.itemTexture2d != null)
            {
                if (image != null)
                {
                    Sprite sprite = Sprite.Create(slot.item.itemTexture2d, new Rect(0, 0, slot.item.itemTexture2d.width, slot.item.itemTexture2d.height), new Vector2(0.5f, 0.5f));
                    image.color = new Color(1f, 1f, 1f, 1f);
                    image.sprite = sprite;
                    Debug.Log("Ставим картинку");
                }
                else
                {
                    Debug.LogWarning("Image component not found on ItemSlot child object.");
                }
            }
            else
            {
                if (image != null)
                {
                    image.color = new Color(0f, 0f, 0f, 0f);
                    Debug.Log("Картинки нет или слот пустой");
                }
                else
                {
                    Debug.LogWarning("Image component not found on ItemSlot child object.");
                }
            }
        }
        foreach (ItemSlot slot in itemSlots)
        {
            if (slot.item == null)
            {
                slot.text.text = "";
                slot.quantity = 0;
            }
        }
    }
    public bool AddItem(Item _item, int _quantity = 1)
    {
        foreach (ItemSlot slot in itemSlots) // Если предмет есть в слоте
        {
            if (slot.item == _item)
            {
                slot.quantity += _quantity;
                if(slot.quantity > 0)
                {
                    slot.text.text = slot.quantity.ToString();
                }
                UpdateIcons();
                return true;
            }
        }
        foreach (ItemSlot slot in itemSlots) // Если предмета нет в слоте
        {
            if (slot.item == null) 
            {
                slot.item = _item;
                slot.quantity = _quantity;
                slot.text.text = slot.quantity.ToString();
                UpdateIcons();
                return true;
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
            UpdateIcons();
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
                UpdateIcons();
                return true;
            }
            else if (slot.item == _item && slot.quantity > _quantity)
            {
                slot.quantity -= _quantity;
                if(slot.quantity > 0)
                {
                    slot.text.text = slot.quantity.ToString();
                }
                UpdateIcons();
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
