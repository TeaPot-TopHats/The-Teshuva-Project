using UnityEngine;

/*
	! This script:
	Is a scriptable object that allows for the creation of classes.
	I did not add an ID because there will only be a few classes.
*/

[CreateAssetMenu(fileName = "Class", menuName = "Stats/Class")]
public class PlayerClass : ScriptableObject
{
	[Header("Class Info")]
	public string Name;
	public string Description;
	public Sprite Icon;
	
	
	[Header("Player Stats")]
	public int MaxHealth;
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
	public float AreaOfEffect;


	[Header("Hold")]
	public float AddHoldDamage;


	[Header("Base Attack")]
	public float Knockback;
	public int CritChance;
	public int AddCritDamage;


	public PlayerClass(PlayerStat stat)
	{
		this.MaxHealth = stat.MaxHealth;
		this.MoveSpeed = stat.MoveSpeed;
		this.Strength = stat.Strength;
		this.Defense = stat.Defense;
		this.Regen = stat.Regen;

		this.MeleeRange = stat.MeleeRange;
		this.MeleeReach = stat.MeleeReach;

		this.MultipleNumber = stat.MultipleNumber;
		this.AreaOfEffect = stat.AreaOfEffect;

		this.AddHoldDamage = stat.AddHoldDamage;

		this.Knockback = stat.Knockback;
		this.CritChance = stat.CritChance;
		this.AddCritDamage = stat.AddCritDamage;
	}

	public PlayerClass()
	{
		this.MaxHealth = 0;
		this.MoveSpeed = 0f;
		this.Strength = 0f;
		this.Defense = 0f;
		this.Regen = 0f;

		this.MeleeRange = 0f;
		this.MeleeReach = 0f;

		this.MultipleNumber = 0f;
		this.AreaOfEffect = 0f;

		this.AddHoldDamage = 0f;

		this.Knockback = 0f;
		this.CritChance = 0;
		this.AddCritDamage = 0;
	}
}