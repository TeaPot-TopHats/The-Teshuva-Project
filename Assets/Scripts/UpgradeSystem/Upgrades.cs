using UnityEngine;


/**
 * A baisc prototype for upgrade. A general upgrade that the player can choose from.
 */
[System.Serializable]
public class Upgrades 
{
    public string upgradeName;
    public int healthIncrease;
    public float damageIncrease;
    public float speedIncrease;
    public Sprite Icon;
}
