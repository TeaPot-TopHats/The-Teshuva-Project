using UnityEngine;

/*
	! This script:
	Is a scriptable object that allows for the creation of boons.
	It doesn't only hold stats but also the name and other boon information. 
*/

[CreateAssetMenu(fileName = "Boon", menuName = "Stats/Boon")]
public class Boon : ScriptableObject
{
	[Header("Boon Info")]
	public string BoonID;
	public string Name;
	public string Description;
	public Sprite Icon;
	
	
	[Header("Player Stats")]
	public int MaxHealth;
	public float MoveSpeed;
	public float Strength;
	public float Defense;
	public float Regen;


	[Header("Base Attack")]
	public float Knockback;
	public int CritChance;
	public int AddCritDamage;


	public Boon(PlayerStat stat)
	{
		this.MaxHealth = stat.MaxHealth;
		this.MoveSpeed = stat.MoveSpeed;
		this.Strength = stat.Strength;
		this.Defense = stat.Defense;
		this.Regen = stat.Regen;

		this.CritChance = stat.CritChance;
		this.AddCritDamage = stat.AddCritDamage;
	}

	public Boon()
	{
		this.MaxHealth = 0;
		this.MoveSpeed = 0f;
		this.Strength = 0f;
		this.Defense = 0f;
		this.Regen = 0f;

		this.CritChance = 0;
		this.AddCritDamage = 0;
	}
}