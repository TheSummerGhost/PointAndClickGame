using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int number;
    public InventoryItem[] inventory = new InventoryItem[6];
    public InventorySlot[] inventorySlots = new InventorySlot[6];

    public bool addToInventory(InventoryItem item) {

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null) {
                inventory[i] = item;

                inventorySlots[i].icon.sprite = item.inventoryIcon;

                return true;
            }
        }
        return false;
    }

    public bool HasItem(InventoryItem item) {
        if (System.Array.Exists(inventory, element => element == item))
        {
            return true;  
        } else 
        {
            return false;
        }
    }

    public static InventoryManager Instance { get; private set; }
    private void Awake() 
    { 

        if (Instance != null && Instance != this) 
        { 
            Destroy(this.gameObject); 
        } else 
        { 
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            foreach (InventorySlot i in inventorySlots) {
            i.icon.sprite = null;
            }
        } 
    }
}
