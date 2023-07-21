using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipeSO : ScriptableObject
{
    public List<Item> inputItems;
    public List<int> inputAmounts;
    public Item outputItem;
    public int outputAmount;
    public int requiredSkillLevel;
    public float craftingTime; // Time taken to craft the item in seconds
}
