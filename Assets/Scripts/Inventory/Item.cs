using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A general Scriptalbe Object class that hold Items
 * 
 * More general variable can be added if needed.
 */

public enum ItemType {Potion, Weapon, Armor};

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public string itemDescription;
    public int itemID;
    public int maxStack;
    public int currentStack;
    public float healthPlus;
    public float staminaPlus;
    public int defencePlus;
    public int attackPowerPlus;
    public int attackSpeedPlus;
    public int movementSpeedPlus;
    public int damageDealt;
    public int itemCount;
    [Range(0f, 1f)]
    public float dropChance;
    

}
