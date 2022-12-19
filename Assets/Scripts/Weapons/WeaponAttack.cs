using UnityEngine;

/*
	This script:
	Is a ScriptableObject to create all the weapon attacks that will be needed for the game.
	It holds all the data for a weapon attack.
	It has a copy contructor to make an intermediary holder for the BFA (Big Fucking Algorithm)
*/


[CreateAssetMenu(fileName = "WeaponAttack", menuName = "Weapons/WeaponAttack")]
public class WeaponAttack : ScriptableObject
{
	[Header("Basic Info")]
	
	[Tooltip("The ID of the attack, make this a unique number")]
	public string AttackID; // The ID of the attack, make this a unique number
	public string Name; // The name of the Weapon Attack
	public string Description; // A short description of the Weapon Attack
	public AttackTypes Type; // The type of attack, Melee or Ranged
	public AttackActions Action; // Either press, action happens when you press. Or Hold action happens after holding for a certain period of time


	[Header("Melee Options")]
	
	public float MeleeRange; // How wide the swing is
	public float MeleeReach; // How far away can it hit
	
	
	[Header("Range Options")]
	
	public GameObject Projectile;  // Projectile prefab to use
	public float MulipleProjectilesNumber; // The number of projectiles
	public float MultipleProjectilesRange; // The range where those projectiles will go
	public float NumberOfBursts; // How many "waves" of attacks
	public float BurstSpeed; // How fast the other attacks will spawn
	public float ProjectileSpeed; // Speed of the projectile
	public float ProjectileLifeTime; // How long before the projectile despawns
	public float ProjectileTravelTime; // How long does it stay moving for
	public float AreaOfEffect; // If the projectile eplodes, how wide is the area of its effect


	[Header("Hold Options")]
	
	public float HoldTime; // How long you have to hold to trigger the strong attack
	public float AddHoldDamage; // How much additional damage you do if you trigger the strong attack
	
	
	[Header("Stats")]
	
	public int AttackDamage; // Base Damage
	public int CritChance; // Change you'll crit. 0-100, represents %
	public int AddCritDamage; // How much additional damage does a crit hit have
	public float Recharge; // How long before you can use the attack again

	public WeaponAttack(){}
	
	public WeaponAttack(WeaponAttack oldAttack)
	{
		this.AttackID = oldAttack.AttackID;
		this.Name = oldAttack.Name;
		this.Description = oldAttack.Description;
		this.Type = oldAttack.Type;
		this.Action = oldAttack.Action;
		
		this.MeleeRange = oldAttack.MeleeRange;
		this.MeleeReach = oldAttack.MeleeReach;
		
		this.Projectile = oldAttack.Projectile;
		this.MulipleProjectilesNumber = oldAttack.MulipleProjectilesNumber;
		this.MultipleProjectilesRange = oldAttack.MultipleProjectilesRange;
		this.NumberOfBursts = oldAttack.NumberOfBursts;
		this.BurstSpeed = oldAttack.BurstSpeed;
		this.ProjectileSpeed = oldAttack.ProjectileSpeed;
		this.ProjectileLifeTime = oldAttack.ProjectileLifeTime;
		this.ProjectileTravelTime = oldAttack.ProjectileTravelTime;
		this.AreaOfEffect = oldAttack.AreaOfEffect;
		
		this.HoldTime = oldAttack.HoldTime;
		this.AddHoldDamage = oldAttack.AddHoldDamage;
		
		this.AttackDamage = oldAttack.AttackDamage;
		this.CritChance = oldAttack.CritChance;
		this.AddCritDamage = oldAttack.AddCritDamage;
		this.Recharge = oldAttack.Recharge;
	}
	
}
