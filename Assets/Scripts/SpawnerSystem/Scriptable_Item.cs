using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A general Scriptalbe Object class that hold Items
 * 
 * More general variable can be added if needed.
 */
[CreateAssetMenu(menuName = "Item")]
public class Scriptable_Item : ScriptableObject
{
    public string itemName;
    public string itemType;
    public string itemDescription;
    public int itemID;
    public int itemQuantity;
    public float healthPlus;
    public float staminaPlus;
    public int defencePlus;
    public int attackPowerPlus;
    public int attackSpeedPlus;
    public int movementSpeedPlus;
    public int damageDealt;
    [Range(0f, 1f)]
    public float dropChance;
    public Sprite itemIcon;

}
