using UnityEngine;
using System.Collections.Generic;


public class SkillSystem : MonoBehaviour
{
    // Define the maximum skill level (99 for Runescape 2007)
    private const int maxSkillLevel = 99;

    // Enum to represent different skills
    public enum SkillType
    {
        Attack,
        Strength,
        Defense,
        Mining,
        Fishing,
        Cooking,
        Runecrafting,
        // Add more skills as needed
    }

    // Dictionary to store the current level and XP of each skill
    private Dictionary<SkillType, int> skillLevels;
    private Dictionary<SkillType, int> skillXP;

    // Method to initialize the skill system (called at the start of the game)
    public void InitializeSkills()
    {
        skillLevels = new Dictionary<SkillType, int>();
        skillXP = new Dictionary<SkillType, int>();

        // Initialize all skills to level 1 and XP 0
        foreach (SkillType skill in Enum.GetValues(typeof(SkillType)))
        {
            skillLevels[skill] = 1;
            skillXP[skill] = 0;
        }
    }

    // Method to gain XP in a skill
    public void GainXP(SkillType skill, int xpAmount)
    {
        // Check if the skill is already at the maximum level
        if (skillLevels[skill] >= maxSkillLevel)
            return;

        // Add the XP amount to the skill's XP
        skillXP[skill] += xpAmount;

        // Check if the skill's XP is enough to level up
        while (skillXP[skill] >= GetRequiredXPForLevel(skillLevels[skill] + 1))
        {
            LevelUpSkill(skill);
        }
    }

    // Method to calculate the required XP to reach a certain level
    private int GetRequiredXPForLevel(int level)
    {
        // Use the Runescape 2007 formula to calculate required XP
        return Mathf.FloorToInt((4 * Mathf.Pow(level, 3)) / 5);
    }

    // Method to level up a skill
    private void LevelUpSkill(SkillType skill)
    {
        // Increase the skill level by 1 and reset the XP
        skillLevels[skill]++;
        skillXP[skill] = 0;

        // TODO: Apply any stat changes or unlock new content related to leveling up the skill
    }

    // TODO: Add other methods for skill training, checking skill requirements, etc.

    // Method to save skill data to the save file
    public void SaveSkillData()
    {
        // TODO: Save skillLevels and skillXP dictionaries to the save file
    }

    // Method to load skill data from the save file
    public void LoadSkillData()
    {
        // TODO: Load skillLevels and skillXP dictionaries from the save file
    }
}
