using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [Header("Item Slot")]
    public GameObject itemSlotPrefab; // Prefab of the item slot UI element
    public Transform contentParent; // Parent transform for item slots in the inventory UI

    private List<GameObject> itemSlots = new List<GameObject>();
    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        InitializeInventoryUI();
    }

    private void InitializeInventoryUI()
    {
        // Clear existing item slots
        foreach (var slot in itemSlots)
        {
            Destroy(slot);
        }
        itemSlots.Clear();

        // Instantiate item slots based on the number of inventory slots
        for (int i = 0; i < playerInventory.maxInventorySlots; i++)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, contentParent);
            itemSlots.Add(itemSlot);
        }

        // Update inventory UI
        UpdateInventoryUI(playerInventory.GetInventoryItems());
    }

    public void UpdateInventoryUI(List<Item> inventoryItems)
    {
        // Update each item slot with the corresponding item in the inventory
        for (int i = 0; i < itemSlots.Count; i++)
        {
            Item item = (i < inventoryItems.Count) ? inventoryItems[i] : null;
            UpdateItemSlotUI(item, itemSlots[i]);
        }
    }

    private void UpdateItemSlotUI(Item item, GameObject itemSlot)
    {
        // Get references to UI elements in the item slot
        Image iconImage = itemSlot.transform.Find("Icon").GetComponent<Image>();
        Text nameText = itemSlot.transform.Find("Name").GetComponent<Text>();
        Text quantityText = itemSlot.transform.Find("Quantity").GetComponent<Text>();

        // Set the icon, name, and quantity for the item slot
        if (item != null)
        {
            iconImage.sprite = item.icon;
            nameText.text = item.itemName;
            quantityText.text = (item.isStackable) ? item.quantity.ToString() : "";
        }
        else
        {
            // If the item is null (empty slot), clear the UI elements
            iconImage.sprite = null;
            nameText.text = "";
            quantityText.text = "";
        }
    }

    // Method to highlight an item slot when the player hovers over it
    public void HighlightItemSlot(GameObject itemSlot)
    {
        // Implement highlighting behavior here (e.g., changing background color)
    }

    // Method to clear the item slot highlights
    public void ClearItemSlotHighlights()
    {
        // Implement clearing of highlights here (e.g., reset background color)
    }
}
