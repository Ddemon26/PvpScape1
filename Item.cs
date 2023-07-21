using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Resource,
    // Add more item types as needed.
}

public enum GearSlot
{
    None,
    Helmet,
    Platebody,
    Platelegs,
    Gloves,
    Boots,
    Shield,
    Cape,
    Amulet,
    // Add more gear slots as needed.
}

public enum ItemMaterial
{
    Wood,
    Metal,
    Cloth,
    // Add more item materials as needed.
}

[System.Serializable]
public class Item
{
    public int itemID; // Unique identifier for the item
    public string itemName;
    public string itemDescription;
    public ItemType itemType;
    public GearSlot gearSlot;
    public int stabBonus;
    public int slashBonus;
    public int crushBonus;
    public int magicBonus;
    public int stabDefense;
    public int slashDefense;
    public int crushDefense;
    public int magicDefense;
    public float weight;
    public int value;
    public int requiredAttackLevel; // Optional for gear items.
    public int requiredStrengthLevel; // Optional for gear items.
    public int requiredDefenseLevel; // Optional for gear items.
    public int requiredRangedLevel; // Optional for gear items.
    public int requiredMagicLevel; // Optional for gear items.
    public int requiredPrayerLevel; // Optional for gear items.
    public int healthIncrease; // Optional for consumables (e.g., food).
    public Sprite itemIcon; // The sprite for the item.

    // Constructor to initialize item properties.
    public Item(int id, string name, string description, ItemType type, GearSlot slot, int stabBonus, int slashBonus,
                int crushBonus, int magicBonus, int stabDefense, int slashDefense, int crushDefense,
                int magicDefense, float weight, int value, int reqAttackLevel, int reqStrengthLevel,
                int reqDefenseLevel, int reqRangedLevel, int reqMagicLevel, int reqPrayerLevel,
                int healthIncrease, Sprite icon)
    {
        itemID = id;
        itemName = name;
        itemDescription = description;
        itemType = type;
        gearSlot = slot;
        this.stabBonus = stabBonus;
        this.slashBonus = slashBonus;
        this.crushBonus = crushBonus;
        this.magicBonus = magicBonus;
        this.stabDefense = stabDefense;
        this.slashDefense = slashDefense;
        this.crushDefense = crushDefense;
        this.magicDefense = magicDefense;
        this.weight = weight;
        this.value = value;
        requiredAttackLevel = reqAttackLevel;
        requiredStrengthLevel = reqStrengthLevel;
        requiredDefenseLevel = reqDefenseLevel;
        requiredRangedLevel = reqRangedLevel;
        requiredMagicLevel = reqMagicLevel;
        requiredPrayerLevel = reqPrayerLevel;
        this.healthIncrease = healthIncrease;
        itemIcon = icon;
    }

    // Method to check if the item is stackable (can be stacked in inventory).
    public bool IsStackable()
    {
        return itemType == ItemType.Consumable; // Add other types if stackable, as needed.
    }

    // Method to get a formatted item description with stats.
    public string GetFormattedDescription()
    {
        string description = itemDescription;

        // Add gear stats to the description.
        if (itemType == ItemType.Weapon || itemType == ItemType.Armor)
        {
            description += "\n\nStats:\n";
            description += "Attack: +" + stabBonus + " Stab, +" + slashBonus + " Slash, +" + crushBonus + " Crush, +" + magicBonus + " Magic\n";
            description += "Defense: +" + stabDefense + " Stab, +" + slashDefense + " Slash, +" + crushDefense + " Crush, +" + magicDefense + " Magic\n";
        }

        // Add other specific item stats to the description, if needed.

        return description;
    }
}
