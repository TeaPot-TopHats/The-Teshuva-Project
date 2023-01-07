using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Player/PlayerStat")]
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
		
		this.Recharge = stat.Recharge;
		this.CritChance = stat.CritChance;
		this.AddCritDamage = stat.AddCritDamage;
	}
}