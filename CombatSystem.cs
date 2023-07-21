using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    private const float TICK_RATE = 1.0f; // The time interval for each tick (in seconds)
    private float tickTimer = 0.0f; // Timer for tracking the current tick

    [Header("References")]
    public PlayerCharacter playerCharacter; // Reference to the PlayerCharacter script
    public UIManager uiManager; // Reference to the UIManager script

    private Enemy currentEnemy; // Reference to the current enemy in combat

    private bool isCombatActive = false; // Flag to check if combat is active

    private void Update()
    {
        if (isCombatActive)
        {
            // Increment the tick timer
            tickTimer += Time.deltaTime;

            // Check if it's time for a new tick
            if (tickTimer >= TICK_RATE)
            {
                // Perform combat actions for player and enemy
                PerformPlayerAction();
                PerformEnemyAction();

                // Update the UI to show health and combat stats
                UpdateUI();

                // Reset the tick timer
                tickTimer -= TICK_RATE;
            }
        }
    }

    public void StartCombat(Enemy enemy)
    {
        // Start combat with the given enemy
        currentEnemy = enemy;
        isCombatActive = true;
    }

    private void PerformPlayerAction()
    {
        // Calculate player's attack damage and apply it to the enemy
        int attackDamage = CalculateAttackDamage(playerCharacter.GetAttackBonus(), currentEnemy.GetDefenseBonus());
        currentEnemy.TakeDamage(attackDamage);

        // Check if the enemy is defeated
        if (currentEnemy.IsDefeated())
        {
            EndCombat(true);
        }
    }

    private void PerformEnemyAction()
    {
        // Calculate enemy's attack damage and apply it to the player
        int attackDamage = CalculateAttackDamage(currentEnemy.GetAttackBonus(), playerCharacter.GetDefenseBonus());
        playerCharacter.TakeDamage(attackDamage);

        // Check if the player is defeated
        if (playerCharacter.IsDefeated())
        {
            EndCombat(false);
        }
    }

    private int CalculateAttackDamage(int attackerBonus, int defenderBonus)
    {
        // Calculate attack damage using the combat formula (similar to RuneScape 2007)
        // You can modify this formula to fit your game's combat mechanics
        int maxDamage = 10; // Modify this value based on your game's balance
        int damage = Random.Range(0, maxDamage) + attackerBonus - defenderBonus;

        return Mathf.Max(0, damage); // Ensure damage is non-negative
    }

    private void EndCombat(bool isPlayerVictorious)
    {
        // Handle the end of combat based on whether the player is victorious or not
        if (isPlayerVictorious)
        {
            // Handle victory (e.g., gain experience, loot, etc.)
            Debug.Log("You defeated the enemy!");
        }
        else
        {
            // Handle defeat (e.g., respawn, drop items, etc.)
            Debug.Log("You were defeated!");
        }

        // Reset combat-related variables
        isCombatActive = false;
        currentEnemy = null;
        tickTimer = 0f;
    }

    private void UpdateUI()
    {
        // Update the UI to display player and enemy health, combat stats, etc.
        uiManager.UpdatePlayerHealth(playerCharacter.GetCurrentHealth(), playerCharacter.GetMaxHealth());
        uiManager.UpdatePlayerCombatStats(playerCharacter.GetAttackBonus(), playerCharacter.GetDefenseBonus());

        if (currentEnemy != null)
        {
            uiManager.UpdateEnemyHealth(currentEnemy.GetCurrentHealth(), currentEnemy.GetMaxHealth());
            uiManager.UpdateEnemyCombatStats(currentEnemy.GetAttackBonus(), currentEnemy.GetDefenseBonus());
        }
    }
}
