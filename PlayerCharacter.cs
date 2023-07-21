using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Player attributes
    public string playerName;
    public int playerLevel = 1;
    public int currentExperience;
    public int requiredExperience;

    // Combat stats
    public CombatStats combatStats = new CombatStats();

    // Inventory
    public PlayerInventory playerInventory;

    // Skills
    public SkillSystem skillSystem;

    // Health
    public int maxHealth = 100;
    public int currentHealth;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Initialize the player's health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player has enough experience to level up
        if (currentExperience >= requiredExperience)
        {
            LevelUp();
        }
    }

    // Method to handle the player leveling up
    private void LevelUp()
    {
        playerLevel++;
        currentExperience -= requiredExperience;
        // Increase requiredExperience for the next level, e.g., requiredExperience *= 2;
        // Apply stat bonuses or unlock new abilities based on the player's level
    }

    // Method to handle the player taking damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle the player's death
    private void Die()
    {
        // Perform actions when the player dies, e.g., respawn at a checkpoint
    }

    // Method to handle the player gaining experience
    public void GainExperience(int experience)
    {
        currentExperience += experience;
    }

    // Method to update the player's combat stats based on equipped gear
    public void UpdateCombatStats()
    {
        // Calculate total combat stats based on equipped gear and skills
        CombatStats totalStats = new CombatStats();

        // Add gear bonuses
        GearSystem gearSystem = GetComponent<GearSystem>();
        if (gearSystem != null)
        {
            totalStats = gearSystem.CalculateTotalStats();
        }

        // Add skill bonuses
        if (skillSystem != null)
        {
            totalStats.stabBonus += skillSystem.GetSkillLevel(SkillType.Strength) / 2;
            totalStats.slashBonus += skillSystem.GetSkillLevel(SkillType.Strength) / 2;
            totalStats.crushBonus += skillSystem.GetSkillLevel(SkillType.Strength) / 2;
            // Add more skill bonuses for different combat stats, as needed
        }

        // Assign the total combat stats to the player's combatStats
        combatStats = totalStats;
    }

    // Method to handle the player attacking an NPC
    public void AttackNPC(NPC npc)
    {
        // Calculate damage based on the player's attack bonuses and the NPC's defense bonuses
        int damage = CalculateDamage(combatStats.stabBonus, combatStats.slashBonus, combatStats.crushBonus, npc.combatStats.stabDefense, npc.combatStats.slashDefense, npc.combatStats.crushDefense);
        npc.TakeDamage(damage);
    }

    // Method to calculate damage between two entities
    private int CalculateDamage(int playerStabBonus, int playerSlashBonus, int playerCrushBonus, int npcStabDefense, int npcSlashDefense, int npcCrushDefense)
    {
        // Calculate damage based on the player's attack bonuses and the NPC's defense bonuses
        int npcDefense = Mathf.Max(npcStabDefense, npcSlashDefense, npcCrushDefense);
        int playerAttack = Mathf.Max(playerStabBonus, playerSlashBonus, playerCrushBonus);

        int damage = Mathf.Max(1, playerAttack - npcDefense); // Ensure damage is at least 1
        return damage;
    }
}
