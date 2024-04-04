using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Item item;
    public int quantity;
    public ItemType itemType;
}
public enum ItemType
{
    Weapon,
    Throwable,
    Edible,
    None
}
