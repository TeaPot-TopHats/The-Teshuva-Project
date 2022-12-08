using UnityEngine;

[System.Serializable]
public class WeaponAttack
{
	[Header("Basic Info")]
	public string Name;
	public string Description;
	public AttackTypes Type;
	public AttackActions Action;


	[Header("Projectile (If RANGE)")]
	public GameObject Projectile;
	public float SPEED;
	public float LifeTime;


	[Header("Hold Options (If HOLD)")]
	public float HoldTime;
	
	
	[Header("Stats")]
	public int DMG;
	public int CRIT_CHANCE;
	public int CRIT_DMG;
	public float RANGE;
	public float RECHARGE;


	[Header("Melee Options (If MELEE)")]
	public float REACH;
}
