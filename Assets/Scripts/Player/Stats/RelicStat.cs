using UnityEngine;

/*
	! This script:
	Is a scriptable object that allows for the creation of RelicStats.
	Since Relics will be object that you can pick up I will leave it as a stat sheet.
*/

[CreateAssetMenu(fileName = "RelicStat", menuName = "Stats/RelicStat")]
public class RelicStat : ScriptableObject
{
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
	public float MultipleRange;
	public float AreaOfEffect;


	[Header("Hold")]
	public float AddHoldDamage;


	[Header("Base Attack")]
	public float Knockback;
	public float Recharge;
	public int CritChance;
	public int AddCritDamage;


	public RelicStat(PlayerStat stat)
	{
		this.MaxHealth = stat.MaxHealth;
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

	public RelicStat()
	{
		this.MaxHealth = 0;
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