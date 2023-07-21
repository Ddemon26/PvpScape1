using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public int questID;
    public string questName;
    public string questDescription;
    public bool isCompleted;
    public Dictionary<int, int> questObjectives;

    public QuestData(int id, string name, string description)
    {
        questID = id;
        questName = name;
        questDescription = description;
        isCompleted = false;
        questObjectives = new Dictionary<int, int>();
    }
}

[System.Serializable]
public class QuestPlayerData
{
    // Player Attributes
    public string playerName;
    public int playerLevel;
    public int playerXP;
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int playerAttack;
    public int playerDefense;
    public int playerPrayer;

    // Player Inventory
    public List<Item> inventoryItems;

    // Player Gear
    public Item helmetSlot;
    public Item platebodySlot;
    public Item platelegsSlot;
    public Item glovesSlot;
    public Item bootsSlot;
    public Item capeSlot;
    public Item amuletSlot;
    public Item weaponSlot;

    // Completed Quests
    public List<QuestData> completedQuests;

    // Constructor
    public QuestPlayerData()
    {
        playerName = "";
        playerLevel = 1;
        playerXP = 0;
        playerMaxHealth = 10;
        playerCurrentHealth = playerMaxHealth;
        playerAttack = 1;
        playerDefense = 1;
        playerPrayer = 1;

        inventoryItems = new List<Item>();

        helmetSlot = null;
        platebodySlot = null;
        platelegsSlot = null;
        glovesSlot = null;
        bootsSlot = null;
        capeSlot = null;
        amuletSlot = null;
        weaponSlot = null;

        completedQuests = new List<QuestData>();
    }

    // Add methods or properties related to player data if needed
}
