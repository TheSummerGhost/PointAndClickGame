using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Item/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public Sprite inventoryIcon;

    public string description;
}

