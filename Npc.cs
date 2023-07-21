using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC Data")]
    public NPCData npcData;

    // Combat behavior
    public void AttackPlayer(Player player)
    {
        // Calculate damage based on the NPC's attack bonuses and the player's defense bonuses
        int damage = CalculateDamage(player.npcStabDefenseBonus, player.npcSlashDefenseBonus, player.npcCrushDefenseBonus);
        player.TakeDamage(damage);
    }

    private int CalculateDamage(int playerStabDefenseBonus, int playerSlashDefenseBonus, int playerCrushDefenseBonus)
    {
        // Calculate damage based on the NPC's attack bonuses and the player's defense bonuses
        int npcAttackBonus = Mathf.Max(npcData.npcStabAttackBonus, npcData.npcSlashAttackBonus, npcData.npcCrushAttackBonus); // Use the highest attack bonus
        int playerDefenseBonus = Mathf.Max(playerStabDefenseBonus, playerSlashDefenseBonus, playerCrushDefenseBonus); // Use the highest defense bonus

        int damage = Mathf.Max(1, npcAttackBonus - playerDefenseBonus); // Ensure damage is at least 1
        return damage;
    }

    // Loot drop
    public Item GetLootDrop()
    {
        // Randomly select an item from the loot table to drop
        if (npcData.lootTable != null && npcData.lootTable.Count > 0)
        {
            int randomIndex = Random.Range(0, npcData.lootTable.Count);
            return npcData.lootTable[randomIndex];
        }
        else
        {
            Debug.LogWarning("No loot table assigned to NPC: " + npcData.npcName);
            return null;
        }
    }

    // Unity integration (optional based on UI requirements)
    // Add any Unity-specific functions and interactions here, such as displaying the NPC's name, health bar, etc.

    // Example Unity-specific functions (replace with actual implementation)
    private void OnMouseDown()
    {
        // Display NPC information when the player clicks on the NPC
        Debug.Log("Clicked on NPC: " + npcData.npcName);
    }

    // Define the Player class within the same script (NPC.cs)
    public class Player
    {
        // Add properties and methods for the Player class
        // For example, you can include player stats and methods for taking damage, etc.
        public int npcStabDefenseBonus;
        public int npcSlashDefenseBonus;
        public int npcCrushDefenseBonus;

        public void TakeDamage(int damage)
        {
            // Implement the logic for the player taking damage
            // You can access the Player's health and apply damage accordingly
        }

        // Add any other player-related methods or properties as needed
    }
}
