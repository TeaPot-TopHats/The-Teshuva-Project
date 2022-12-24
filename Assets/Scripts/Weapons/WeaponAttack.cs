using UnityEngine;

/*
	This script:
	Is a ScriptableObject to create all the weapon attacks that will be needed for the game.
	It holds all the data for a weapon attack.
*/


[CreateAssetMenu(fileName = "WeaponAttack", menuName = "Weapons/WeaponAttack")]
public class WeaponAttack : ScriptableObject
{
	[Header("Basic Info")]
	
	[Tooltip("The ID of the attack, make this a unique number")]
	public string AttackID; // The ID of the attack, make this a unique number
	public string Name; // The name of the Weapon Attack
	public string Description; // A short description of the Weapon Attack
	public AttackType Type; // The type of attack, Melee or Ranged
	public InteractionType Interaction; // Either press, action happens when you press. Or Hold action happens after holding for a certain period of time


	[Header("Melee Options")]
	
	public float MeleeRange; // How wide the swing is
	public float MeleeReach; // How far away can it hit
	
	
	[Header("Range Options")]
	
	public GameObject Projectile;  // Projectile prefab to use
	
	public float MultipleNumber; // The number of projectiles
	public float MultipleRange; // The range where those projectiles will go
	
	public float ProjectileSpeed; // Speed of the projectile
	public float ProjectileLifeTime; // How long before the projectile despawns
	public float ProjectileTravelTime; // How long does it stay moving for
	
	public float AreaOfEffect; // If the projectile eplodes, how wide is the area of its effect


	[Header("Hold Options")]
	
	public float HoldTime; // How long you have to hold to trigger the strong attack
	public float AddHoldDamage; // How much additional damage you do if you trigger the strong attack
	
	
	[Header("Stats")]
	
	public int AttackDamage; // Base Damage
	public float Recharge; // How long before you can use the attack again
	
	public int CritChance; // Change you'll crit. 0-100, represents %
	public int AddCritDamage; // How much additional damage does a crit hit have
	


	public WeaponAttack(){}
	
	
	public WeaponAttack(WeaponAttack attack)
	{
		this.AttackID = attack.AttackID;
		this.Name = attack.Name;
		this.Description = attack.Description;
		this.Type = attack.Type;
		this.Interaction = attack.Interaction;
		
		this.MeleeRange = attack.MeleeRange;
		this.MeleeReach = attack.MeleeReach;
		
		this.Projectile = attack.Projectile;
		this.MultipleNumber = attack.MultipleNumber;
		this.MultipleRange = attack.MultipleRange;
		this.ProjectileSpeed = attack.ProjectileSpeed;
		this.ProjectileLifeTime = attack.ProjectileLifeTime;
		this.ProjectileTravelTime = attack.ProjectileTravelTime;
		this.AreaOfEffect = attack.AreaOfEffect;
		
		this.HoldTime = attack.HoldTime;
		this.AddHoldDamage = attack.AddHoldDamage;
		
		this.AttackDamage = attack.AttackDamage;
		this.Recharge = attack.Recharge;
		this.CritChance = attack.CritChance;
		this.AddCritDamage = attack.AddCritDamage;
	}
	
}
