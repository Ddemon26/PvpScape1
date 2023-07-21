using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI Text Elements")]
    public Text healthText;
    public Text combatLevelText;
    public Text attackText;
    public Text strengthText;
    public Text defenseText;
    public Text rangedText;
    public Text magicText;
    public Text runecraftingText;
    public Text lootTrackerText;
    public GameObject lootTrackerPanel;
    public GameObject questPanel;
    public Text questTitleText;
    public Text questDescriptionText;
    public Text questProgressText;

    private PlayerData playerData;
    private bool isLootTrackerVisible;
    private bool isQuestPanelVisible;

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        isLootTrackerVisible = false;
        isQuestPanelVisible = false;
        UpdateUI();
    }

    private void Update()
    {
        // Update the UI elements that need constant monitoring (e.g., health, combat level, skills)
        UpdateHealthText();
        UpdateCombatLevelText();
        UpdateSkillText();

        // Check for loot changes and update the loot tracker
        if (playerData.IsLootUpdated())
        {
            UpdateLootTracker();
            playerData.ResetLootUpdated();
        }

        // Check for active quests and update the quest panel if needed
        if (playerData.IsQuestUpdated())
        {
            UpdateQuestPanel();
            playerData.ResetQuestUpdated();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + playerData.GetCurrentHealth() + "/" + playerData.GetMaxHealth();
    }

    private void UpdateCombatLevelText()
    {
        combatLevelText.text = "Combat Level: " + playerData.GetCombatLevel();
    }

    private void UpdateSkillText()
    {
        attackText.text = "Attack: " + playerData.GetSkillLevel(SkillType.Attack);
        strengthText.text = "Strength: " + playerData.GetSkillLevel(SkillType.Strength);
        defenseText.text = "Defense: " + playerData.GetSkillLevel(SkillType.Defense);
        rangedText.text = "Ranged: " + playerData.GetSkillLevel(SkillType.Ranged);
        magicText.text = "Magic: " + playerData.GetSkillLevel(SkillType.Magic);
        runecraftingText.text = "Runecrafting: " + playerData.GetSkillLevel(SkillType.Runecrafting);
    }

    private void UpdateLootTracker()
    {
        if (isLootTrackerVisible)
        {
            string lootText = "Loot Tracker:\n";

            foreach (var loot in playerData.GetLootTracker())
            {
                lootText += loot.itemName + " x " + loot.quantity + "\n";
            }

            lootTrackerText.text = lootText;
        }
    }

    private void UpdateQuestPanel()
    {
        Quest activeQuest = playerData.GetActiveQuest();

        if (activeQuest != null)
        {
            if (!isQuestPanelVisible)
            {
                questPanel.SetActive(true);
                isQuestPanelVisible = true;
            }

            questTitleText.text = activeQuest.title;
            questDescriptionText.text = activeQuest.description;
            questProgressText.text = "Progress: " + activeQuest.progress + "/" + activeQuest.goal;
        }
        else if (isQuestPanelVisible)
        {
            questPanel.SetActive(false);
            isQuestPanelVisible = false;
        }
    }

    public void ToggleLootTrackerPanel()
    {
        isLootTrackerVisible = !isLootTrackerVisible;
        lootTrackerPanel.SetActive(isLootTrackerVisible);
        UpdateLootTracker();
    }

    public void ToggleQuestPanel()
    {
        isQuestPanelVisible = !isQuestPanelVisible;
        questPanel.SetActive(isQuestPanelVisible);
        UpdateQuestPanel();
    }
}
