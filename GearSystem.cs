using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public int stabBonus;
    public int crushBonus;
    public int slashBonus;
}

public class GearSystem : MonoBehaviour
{
    // Define gear slots
    public Item helmetSlot;
    public Item platebodySlot;
    public Item platelegsSlot;
    public Item glovesSlot;
    public Item bootsSlot;
    public Item capeSlot;
    public Item amuletSlot;
    public Item weaponSlot;

    // Equipping gear
    public void EquipItem(Item item)
    {
        // Determine the item type and equip it to the appropriate slot
        switch (item.itemType)
        {
            case ItemType.Helmet:
                helmetSlot = item;
                break;
            case ItemType.Platebody:
                platebodySlot = item;
                break;
            case ItemType.Platelegs:
                platelegsSlot = item;
                break;
            case ItemType.Gloves:
                glovesSlot = item;
                break;
            case ItemType.Boots:
                bootsSlot = item;
                break;
            case ItemType.Cape:
                capeSlot = item;
                break;
            case ItemType.Amulet:
                amuletSlot = item;
                break;
            case ItemType.Weapon:
                weaponSlot = item;
                break;
            // Add more cases for other gear types, if applicable
            default:
                Debug.LogWarning("Unsupported gear type!");
                break;
        }

        // ... (Any additional functionality related to equipping gear)
    }

    // Unequipping gear
    public void UnequipItem(Item item)
    {
        // Determine the item type and unequip it from the appropriate slot
        switch (item.itemType)
        {
            case ItemType.Helmet:
                helmetSlot = null;
                break;
            case ItemType.Platebody:
                platebodySlot = null;
                break;
            case ItemType.Platelegs:
                platelegsSlot = null;
                break;
            case ItemType.Gloves:
                glovesSlot = null;
                break;
            case ItemType.Boots:
                bootsSlot = null;
                break;
            case ItemType.Cape:
                capeSlot = null;
                break;
            case ItemType.Amulet:
                amuletSlot = null;
                break;
            case ItemType.Weapon:
                weaponSlot = null;
                break;
            // Add more cases for other gear types, if applicable
            default:
                Debug.LogWarning("Unsupported gear type!");
                break;
        }

        // ... (Any additional functionality related to unequipping gear)
    }

    // Calculate total combat stats based on equipped gear
    public CombatStats CalculateTotalStats()
    {
        CombatStats totalStats = new CombatStats();

        // Add stats from helmet
        if (helmetSlot != null)
        {
            totalStats.stabBonus += helmetSlot.stabBonus;
            totalStats.crushBonus += helmetSlot.crushBonus;
            totalStats.slashBonus += helmetSlot.slashBonus;
        }

        // Add stats from platebody
        if (platebodySlot != null)
        {
            totalStats.stabBonus += platebodySlot.stabBonus;
            totalStats.crushBonus += platebodySlot.crushBonus;
            totalStats.slashBonus += platebodySlot.slashBonus;
        }

        // Add stats from platelegs
        if (platelegsSlot != null)
        {
            totalStats.stabBonus += platelegsSlot.stabBonus;
            totalStats.crushBonus += platelegsSlot.crushBonus;
            totalStats.slashBonus += platelegsSlot.slashBonus;
        }

        // Add stats from gloves
        if (glovesSlot != null)
        {
            totalStats.stabBonus += glovesSlot.stabBonus;
            totalStats.crushBonus += glovesSlot.crushBonus;
            totalStats.slashBonus += glovesSlot.slashBonus;
        }

        // Add stats from boots
        if (bootsSlot != null)
        {
            totalStats.stabBonus += bootsSlot.stabBonus;
            totalStats.crushBonus += bootsSlot.crushBonus;
            totalStats.slashBonus += bootsSlot.slashBonus;
        }

        // Add stats from weapon
        if (weaponSlot != null)
        {
            totalStats.stabBonus += weaponSlot.stabBonus;
            totalStats.crushBonus += weaponSlot.crushBonus;
            totalStats.slashBonus += weaponSlot.slashBonus;
        }

        // ... (repeat for cape, amulet, etc., if applicable)

        return totalStats;
    }
}
