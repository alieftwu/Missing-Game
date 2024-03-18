using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "InventoryManager";
                    instance = obj.AddComponent<InventoryManager>();
                }
            }
            return instance;
        }
    }

    // Inventory data
    private List<Inventory.Slot> inventorySlots = new List<Inventory.Slot>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this GameObject when loading a new scene
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Example methods to access and modify the inventory data
    public List<Inventory.Slot> GetInventorySlots()
    {
        return inventorySlots;
    }

    public void AddItemToInventory(Inventory.Slot newItem)
    {
        inventorySlots.Add(newItem);
    }
}

