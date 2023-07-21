using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDatabase : MonoBehaviour
{
    // List to hold all items in the game
    public List<Item> allItems = new List<Item>();

    // Singleton instance of the ItemDatabase
    private static ItemDatabase instance;
    public static ItemDatabase Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemDatabase>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("_ItemDatabase");
                    instance = obj.AddComponent<ItemDatabase>();
                }
            }
            return instance;
        }
    }

    // Method to add an item to the database
    public void AddItem(Item item)
    {
        if (item != null && !allItems.Contains(item))
        {
            allItems.Add(item);
        }
    }

    // Method to get an item by its ID
    public Item GetItemByID(int itemID)
    {
        return allItems.Find(item => item.itemID == itemID);
    }

    // Method to check if an item with the given ID exists in the database
    public bool ItemExists(int itemID)
    {
        return allItems.Exists(item => item.itemID == itemID);
    }

    // Method to get a list of all items of a specific type
    public List<Item> GetItemsByType(ItemType itemType)
    {
        return allItems.FindAll(item => item.itemType == itemType);
    }

    // Method to get a list of all items with a specific material
    public List<Item> GetItemsByMaterial(ItemMaterial itemMaterial)
    {
        return allItems.FindAll(item => item.itemMaterial == itemMaterial);
    }

    // Method to get a list of all stackable items
    public List<Item> GetStackableItems()
    {
        return allItems.FindAll(item => item.IsStackable());
    }

    // Method to get a list of all non-stackable items
    public List<Item> GetNonStackableItems()
    {
        return allItems.FindAll(item => !item.IsStackable());
    }
}
