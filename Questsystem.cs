using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void StartQuest(Quest quest, PlayerData playerData)
    {
        if (!quest.IsCompleted && quest.CanStartQuest(playerData))
        {
            quest.StartQuest(playerData);
            Debug.Log("Quest started: " + quest.questName);
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (!quest.IsCompleted)
        {
            quest.CompleteQuest();
            // Add any rewards or other actions upon quest completion here
            Debug.Log("Quest completed: " + quest.questName);
        }
    }
}

[System.Serializable]
public class Quest
{
    public string questName;
    public string questDescription;
    public bool IsCompleted { get; private set; }
    public int requiredLevel;
    public int requiredSkillLevel;
    public List<Item> requiredItems;
    public List<Item> questRewards;

    // Add any other properties you need for the quest, such as objectives, dialogue, etc.

    public bool CanStartQuest(PlayerData playerData)
    {
        if (playerData.level >= requiredLevel && playerData.GetSkillLevel(SkillType.Runecrafting) >= requiredSkillLevel)
        {
            foreach (Item item in requiredItems)
            {
                if (!playerData.HasItem(item))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    public void StartQuest(PlayerData playerData)
    {
        foreach (Item item in requiredItems)
        {
            playerData.RemoveItem(item);
        }
        IsCompleted = false;
        // Add any other actions needed to start the quest here
    }

    public void CompleteQuest()
    {
        IsCompleted = true;
        // Add any other actions needed upon quest completion here
    }

    public void GiveRewards(PlayerData playerData)
    {
        foreach (Item item in questRewards)
        {
            playerData.AddItem(item);
        }
        // Add any other actions needed to give rewards to the player here
    }
}
