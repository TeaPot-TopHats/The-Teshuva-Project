using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "Player/PlayerStat")]
public class PlayerStat : ScriptableObject
{
	[Header("Player Stats")]
	public int MaxHealth; 
	public int Health;
	public float MoveSpeed;
	public float Attack;
	public float Defense;
	public float Regen;


	[Header("--Attack Modifiers--")]
	[Header("Melee")]
	public float MeleeRange;
	public float MeleeReach;


	[Header("Range")]
	public float MulipleProjectilesNumber;
	public float MultipleProjectilesRange;
	public float NumberOfBursts;
	public float AreaOfEffect;


	[Header("Hold")]
	public float AddHoldDamage;


	[Header("Base Attack")]
	public int CritChance; 
	public int AddCritDamage;
	public float Recharge;
}