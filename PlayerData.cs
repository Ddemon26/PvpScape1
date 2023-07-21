using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Attack,
    Defense,
    Prayer,
    Hitpoints,
    Range,
    Magic,
    Runecrafting
    // Add more skills as needed
}

[System.Serializable]
public class PlayerData
{
    // Player stats
    public int playerId;
    public string playerName;
    public int playerLevel;
    public int playerExperience;
    public int playerGold;

    // Player equipment
    public int equippedWeaponId;
    public int equippedArmorId;

    // Player skills with their corresponding levels
    public Dictionary<SkillType, int> playerSkills = new Dictionary<SkillType, int>();

    // Constructor
    public PlayerData()
    {
        // Initialize default values
        playerId = 0;
        playerName = "Player";
        playerLevel = 1;
        playerExperience = 0;
        playerGold = 0;

        // Initialize player skills
        foreach (SkillType skillType in System.Enum.GetValues(typeof(SkillType)))
        {
            playerSkills.Add(skillType, 1);
        }
    }

    // Helper method to increase player level
    public void IncreasePlayerLevel()
    {
        playerLevel++;
    }

    // Helper method to increase player experience
    public void IncreasePlayerExperience(int amount)
    {
        playerExperience += amount;

        // Check if player has leveled up
        while (playerExperience >= ExperienceToNextLevel())
        {
            playerExperience -= ExperienceToNextLevel();
            IncreasePlayerLevel();
        }
    }

    // Helper method to calculate experience required for the next level
    public int ExperienceToNextLevel()
    {
        return playerLevel * 100; // Adjust as needed for your leveling system
    }

    // Helper method to increase a specific skill level
    public void IncreaseSkillLevel(SkillType skillType, int amount)
    {
        playerSkills[skillType] += amount;
    }

    // Helper method to get the level of a specific skill
    public int GetSkillLevel(SkillType skillType)
    {
        if (playerSkills.ContainsKey(skillType))
        {
            return playerSkills[skillType];
        }

        return 1;
    }

    // Helper method to set the player's name
    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    // Helper method to add gold to the player's inventory
    public void AddGold(int amount)
    {
        playerGold += amount;
    }

    // Helper method to remove gold from the player's inventory
    public void RemoveGold(int amount)
    {
        playerGold -= amount;
        if (playerGold < 0)
        {
            playerGold = 0;
        }
    }

    // ... (Add more helper methods as needed)

}
