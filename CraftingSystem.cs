using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [System.Serializable]
    public class CraftingRecipe
    {
        public List<Item> inputItems;
        public int[] inputAmounts;
        public Item outputItem;
        public int outputAmount;
        public int requiredSkillLevel;
    }

    // List to store crafting recipes.
    public List<CraftingRecipe> craftingRecipes;

    // Reference to the InventorySystem script to manage the player's inventory.
    private InventorySystem inventorySystem;

    // Reference to the UIManager script to display crafting-related UI elements.
    private UIManager uiManager;

    // Reference to the PlayerData script to access player skill levels.
    private PlayerData playerData;

    // Initialize the crafting system.
    private void Start()
    {
        // Get the references to the InventorySystem, UIManager, and PlayerData scripts.
        inventorySystem = GetComponent<InventorySystem>();
        uiManager = GetComponent<UIManager>();
        playerData = GetComponent<PlayerData>();
    }

    // Craft an item based on the given output item ID.
    public void CraftItem(int outputItemID)
    {
        // Find the crafting recipe for the given output item ID.
        CraftingRecipe recipe = craftingRecipes.Find(x => x.outputItem.itemID == outputItemID);

        if (recipe != null)
        {
            // Check if the player meets the required skill level.
            if (playerData.GetSkillLevel("Runecrafting") >= recipe.requiredSkillLevel)
            {
                // Check if the player has the required input items and amounts.
                if (HasRequiredInputItems(recipe))
                {
                    // Deduct the required input items from the player's inventory.
                    DeductInputItems(recipe);

                    // Add the crafted item to the player's inventory.
                    inventorySystem.AddItemToInventory(recipe.outputItem.itemID, recipe.outputAmount);

                    // Show a success message in the UI.
                    uiManager.ShowMessage("Crafting successful!");
                }
                else
                {
                    // Show an error message in the UI indicating that the player doesn't have the required input items.
                    uiManager.ShowMessage("You don't have enough materials to craft this item.");
                }
            }
            else
            {
                // Show an error message in the UI indicating that the player doesn't meet the required skill level.
                uiManager.ShowMessage("You need a higher Runecrafting level to craft this item.");
            }
        }
        else
        {
            // Show an error message in the UI indicating that the crafting recipe doesn't exist.
            uiManager.ShowMessage("Crafting recipe not found.");
        }
    }

    // Check if the player has the required input items and amounts for a crafting recipe.
    private bool HasRequiredInputItems(CraftingRecipe recipe)
    {
        // Check if the player has the required input items and amounts.
        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            if (!inventorySystem.HasItem(recipe.inputItems[i].itemID, recipe.inputAmounts[i]))
            {
                return false;
            }
        }
        return true;
    }

    // Deduct the required input items from the player's inventory.
    private void DeductInputItems(CraftingRecipe recipe)
    {
        // Deduct the required input items from the player's inventory.
        for (int i = 0; i < recipe.inputItems.Count; i++)
        {
            inventorySystem.RemoveItemFromInventory(recipe.inputItems[i].itemID, recipe.inputAmounts[i]);
        }
    }
}
