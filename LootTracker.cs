using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    [System.Serializable]
    public class LootEntry
    {
        public int itemID;
        public int quantity;
    }

    private List<LootEntry> lootEntries = new List<LootEntry>();

    // Add loot to the tracker
    public void AddLoot(int itemID, int quantity)
    {
        LootEntry existingEntry = lootEntries.Find(entry => entry.itemID == itemID);
        if (existingEntry != null)
        {
            existingEntry.quantity += quantity;
        }
        else
        {
            LootEntry newEntry = new LootEntry { itemID = itemID, quantity = quantity };
            lootEntries.Add(newEntry);
        }
    }

    // Get the loot entries as a list
    public List<LootEntry> GetLootEntries()
    {
        return lootEntries;
    }

    // Clear the loot entries
    public void ClearLoot()
    {
        lootEntries.Clear();
    }

    // Display the loot information (for debugging purposes)
    public void DisplayLoot()
    {
        foreach (LootEntry entry in lootEntries)
        {
            Debug.Log("Item ID: " + entry.itemID + ", Quantity: " + entry.quantity);
        }
    }
}
