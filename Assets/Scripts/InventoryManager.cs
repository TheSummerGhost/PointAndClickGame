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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
