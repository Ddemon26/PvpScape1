using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour
{
    public Text dungeonInfoText;
    public Button exploreButton;

    [Header("Dungeon Settings")]
    public string dungeonName = "Dark Cave";
    public int maxDungeonLevel = 10;

    [Header("Enemy Encounters")]
    public List<Enemy> enemies;
    public List<Item> dungeonLoot;

    private int currentDungeonLevel;
    private bool isExploring;

    private void Start()
    {
        currentDungeonLevel = 1;
        isExploring = false;

        UpdateDungeonInfo();
    }

    private void UpdateDungeonInfo()
    {
        dungeonInfoText.text = "Dungeon: " + dungeonName + "\nLevel: " + currentDungeonLevel;

        if (isExploring)
        {
            exploreButton.interactable = false;
            dungeonInfoText.text += "\nExploring...";
        }
        else
        {
            exploreButton.interactable = true;
            dungeonInfoText.text += "\nReady to Explore!";
        }
    }

    public void ExploreDungeon()
    {
        if (!isExploring)
        {
            StartCoroutine(ExploreDungeonCoroutine());
        }
    }

    private IEnumerator ExploreDungeonCoroutine()
    {
        isExploring = true;
        UpdateDungeonInfo();

        yield return new WaitForSeconds(2f); // Simulating dungeon exploration time (replace with your actual mechanic)

        // Randomly select an enemy encounter
        int randomEnemyIndex = Random.Range(0, enemies.Count);
        Enemy enemy = enemies[randomEnemyIndex];

        // Simulating combat with the enemy
        bool playerWins = CombatWithEnemy(enemy);

        if (playerWins)
        {
            // Player wins, give loot
            int randomLootIndex = Random.Range(0, dungeonLoot.Count);
            Item loot = dungeonLoot[randomLootIndex];
            PlayerInventory.Instance.AddItem(loot);

            dungeonInfoText.text += "\nYou defeated " + enemy.Name + " and found: " + loot.ItemName;
        }
        else
        {
            // Player loses, handle game over
            dungeonInfoText.text += "\nYou were defeated by " + enemy.Name + ". Game Over.";
            GameManager.Instance.GameOver();
        }

        currentDungeonLevel++;
        isExploring = false;
        UpdateDungeonInfo();
    }

    private bool CombatWithEnemy(Enemy enemy)
    {
        // Implement your combat mechanics here using the enemy's stats and player's stats
        // Return true if player wins, false if player loses
        // You can use the combat system you implemented earlier
        // For simplicity, let's assume the player always wins for now
        return true;
    }
}

[System.Serializable]
public class Enemy
{
    public string Name;
    public int MaxHealth;
    public int Attack;
    public int Defense;

    public Enemy(string name, int maxHealth, int attack, int defense)
    {
        Name = name;
        MaxHealth = maxHealth;
        Attack = attack;
        Defense = defense;
    }
}
