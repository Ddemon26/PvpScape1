using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    public int maxInventorySlots = 28;
    public int maxStackableQuantity = 100;

    [Header("UI Settings")]
    public GameObject inventoryUI; // Reference to the inventory UI game object
    public Transform itemSlotParent; // Parent transform for item slots in the UI

    private List<Item> inventoryItems = new List<Item>();
    private ItemDatabase itemDatabase;
    private InventoryUIManager inventoryUIManager;

    private void Start()
    {
        itemDatabase = ItemDatabase.Instance;
        inventoryUIManager = inventoryUI.GetComponent<InventoryUIManager>();
        UpdateInventoryUI();
    }

    public void AddItemToInventory(int itemID, int quantity = 1)
    {
        Item itemToAdd = itemDatabase.GetItemByID(itemID);
        if (itemToAdd == null)
        {
            Debug.LogWarning("Item with ID " + itemID + " does not exist in the database.");
            return;
        }

        if (!itemToAdd.isStackable)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (inventoryItems.Count >= maxInventorySlots)
                {
                    Debug.LogWarning("Inventory is full. Cannot add more items.");
                    break;
                }

                inventoryItems.Add(itemToAdd);
            }
        }
        else
        {
            Item stackableItem = inventoryItems.Find(item => item.itemID == itemID && item.quantity < maxStackableQuantity);
            if (stackableItem != null)
            {
                int remainingSpace = maxStackableQuantity - stackableItem.quantity;
                int quantityToAdd = Mathf.Min(remainingSpace, quantity);
                stackableItem.quantity += quantityToAdd;
                quantity -= quantityToAdd;
            }

            for (int i = 0; i < quantity; i++)
            {
                if (inventoryItems.Count >= maxInventorySlots)
                {
                    Debug.LogWarning("Inventory is full. Cannot add more items.");
                    break;
                }

                Item newItem = new Item(itemToAdd);
                newItem.quantity = Mathf.Min(quantity, maxStackableQuantity);
                inventoryItems.Add(newItem);
                quantity -= newItem.quantity;
            }
        }

        // Update UI after adding items to inventory
        UpdateInventoryUI();
    }

    public void RemoveItemFromInventory(int itemID, int quantity = 1)
    {
        Item itemToRemove = inventoryItems.Find(item => item.itemID == itemID);
        if (itemToRemove == null)
        {
            Debug.LogWarning("Item with ID " + itemID + " not found in the inventory.");
            return;
        }

        if (itemToRemove.isStackable)
        {
            itemToRemove.quantity -= quantity;
            if (itemToRemove.quantity <= 0)
            {
                inventoryItems.Remove(itemToRemove);
            }
        }
        else
        {
            for (int i = 0; i < quantity; i++)
            {
                inventoryItems.Remove(itemToRemove);
            }
        }

        // Update UI after removing items from inventory
        UpdateInventoryUI();
    }

    public bool HasItemInInventory(int itemID)
    {
        return inventoryItems.Exists(item => item.itemID == itemID);
    }

    public List<Item> GetInventoryItems()
    {
        return inventoryItems;
    }

    public void ClearInventory()
    {
        inventoryItems.Clear();
        // Update UI after clearing the inventory
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        inventoryUIManager.UpdateInventoryUI(inventoryItems, itemSlotParent);
    }
}
