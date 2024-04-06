using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Item item;
    public int quantity;
    public SlotType slotType;
}
public enum SlotType
{
    Weapon,
    Throwable,
    Edible,
    Wearable,
    None
}
