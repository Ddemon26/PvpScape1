using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // Save player data to PlayerPrefs
    public void Save(PlayerData playerData)
    {
        // Save player data using PlayerPrefs keys
        PlayerPrefs.SetString("PlayerName", playerData.playerName);
        PlayerPrefs.SetInt("PlayerLevel", playerData.playerLevel);

        // Save other player data here...

        // Save player inventory
        SaveInventory(playerData.inventory);

        // Save player gear
        SaveGear(playerData.gear);

        // Save player quest data
        SaveQuestData(playerData.quests);

        // Save other data as needed...
    }

    // Load player data from PlayerPrefs
    public void Load(PlayerData playerData)
    {
        // Load player data using PlayerPrefs keys
        playerData.playerName = PlayerPrefs.GetString("PlayerName");
        playerData.playerLevel = PlayerPrefs.GetInt("PlayerLevel");

        // Load other player data here...

        // Load player inventory
        LoadInventory(playerData.inventory);

        // Load player gear
        LoadGear(playerData.gear);

        // Load player quest data
        LoadQuestData(playerData.quests);

        // Load other data as needed...
    }

    // Save loot tracker data to PlayerPrefs
    private void SaveLootTracker(LootTracker lootTracker)
    {
        // Save loot tracker data here...
    }

    // Load loot tracker data from PlayerPrefs
    private void LoadLootTracker(LootTracker lootTracker)
    {
        // Load loot tracker data here...
    }
    // Save player inventory data to PlayerPrefs
    private void SaveInventory(PlayerInventory inventory)
    {
        // Save inventory items here...
    }

    // Load player inventory data from PlayerPrefs
    private void LoadInventory(PlayerInventory inventory)
    {
        // Load inventory items here...
    }

    // Save player gear data to PlayerPrefs
    private void SaveGear(GearSystem gear)
    {
        // Save gear items here...
    }

    // Load player gear data from PlayerPrefs
    private void LoadGear(GearSystem gear)
    {
        // Load gear items here...
    }

    // Save player quest data to PlayerPrefs
    private void SaveQuestData(QuestSystem questSystem)
    {
        // Save quest data here...
    }

    // Load player quest data from PlayerPrefs
    private void LoadQuestData(QuestSystem questSystem)
    {
        // Load quest data here...
    }

    // Clear saved player data
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
