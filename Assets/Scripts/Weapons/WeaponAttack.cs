using UnityEngine;

[System.Serializable]
public class WeaponAttack
{
	[Header("Basic Info")]
	public string Name; // The name of the Weapon Attack
	public string Description; // A short description of the Weapon Attack
	public AttackTypes Type; // The type of attack, Melee or Ranged
	public AttackActions Action; // Either press, action happens when you press. Or Hold action happens after holding for a certain period of time


	[Header("Melee Options")]
	public float RANGE; // How wide the swing is
	public float REACH; // How far away can it hit
	
	
	[Header("Range Options")]
	public GameObject Projectile;  // Projectile prefab to use
	public float ProjectileSpeed; // Speed of the projectile
	public float ProjectileLifeTime; // How long before the projectile despawns
	public float ProjectileTravelTime; // How long does it stay moving


	[Header("Hold Options")]
	public float HoldTime; // How long you have to hold to trigger the strong attack
	public float AddHoldDamage; // How much additional damage you do if you trigger the strong attack
	
	
	[Header("Stats")]
	public int DMG; // Base Damage
	public int CRIT_CHANCE; // Change you'll crit. 0-100, represents %
	public int CRIT_DMG; // How much damage does a crit have
	public float RECHARGE; // How long before you can use the attack again
}
