using UnityEngine;

/*
	! This Script:
	Is a scriptable object that holds all the data a player can have.
	From this the BasePlayerStats should be made as well as holders for calculated stats.
*/


[CreateAssetMenu(fileName = "PlayerStat", menuName = "Stats/PlayerStat")]
public class PlayerStat : ScriptableObject
{
	[Header("Player Stats")]
	public int MaxHealth; 
	public int Health;
	public float MoveSpeed;
	public float Strength;
	public float Defense;
	public float Regen;


	[Header("--Attack Modifiers--")]
	[Header("Melee")]
	public float MeleeRange;
	public float MeleeReach;


	[Header("Range")]
	public float MultipleNumber;
	public float MultipleRange;
	public float AreaOfEffect;


	[Header("Hold")]
	public float AddHoldDamage;


	[Header("Base Attack")]
	public float Knockback;
	public float Recharge;
	public int CritChance; 
	public int AddCritDamage;
	
	
	public PlayerStat(PlayerStat stat)
	{
		this.MaxHealth = stat.MaxHealth;
		this.Health = stat.Health;
		this.MoveSpeed = stat.MoveSpeed;
		this.Strength = stat.Strength;
		this.Defense = stat.Defense;
		this.Regen = stat.Regen;
		
		this.MeleeRange = stat.MeleeRange;
		this.MeleeReach = stat.MeleeReach;
		
		this.MultipleNumber = stat.MultipleNumber;
		this.MultipleRange = stat.MultipleRange;
		this.AreaOfEffect = stat.AreaOfEffect;
		
		this.AddHoldDamage = stat.AddHoldDamage;
		
		this.Knockback = stat.Knockback;
		this.Recharge = stat.Recharge;
		this.CritChance = stat.CritChance;
		this.AddCritDamage = stat.AddCritDamage;
	}

	public PlayerStat()
	{
		this.MaxHealth = 0;
		this.Health = 0;
		this.MoveSpeed = 0f;
		this.Strength = 0f;
		this.Defense = 0f;
		this.Regen = 0f;

		this.MeleeRange = 0f;
		this.MeleeReach = 0f;

		this.MultipleNumber = 0f;
		this.MultipleRange = 0f;
		this.AreaOfEffect = 0f;

		this.AddHoldDamage = 0f;

		this.Knockback = 0f;
		this.Recharge = 0f;
		this.CritChance = 0;
		this.AddCritDamage = 0;
	}
}