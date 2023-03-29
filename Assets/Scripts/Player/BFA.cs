using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	! This script:
	BFA stands for Big Fucking Algorithm
	This script performs attacks
*/



public class BFA : MonoBehaviour
{
	private WeaponAttack calculatedAttack;
	private bool isStrong = false;
	private PlayerCombat combat;
	private float AimAngle;
	
	private Vector3 projectileSpawn;
    GameObject projectile;

	// rotation = Quaternion.AngleAxis(InputH.AimAngle, Vector3.forward);

	private void Start() {
		combat = GetComponent<PlayerCombat>();
	}
	
	public void PerformAttack(PlayerStat currentStats, WeaponAttack attack, bool isStrong)
	{
		CalculateStats(currentStats, attack);
		this.isStrong = isStrong;
		AimAngle = combat.InputH.AimAngle - 90;
		Attack();
	}
	
	// this is temporary
	private void CalculateStats(PlayerStat stats, WeaponAttack attack)
	{
		this.calculatedAttack = new WeaponAttack(attack);
		this.calculatedAttack.MeleeRange += stats.MeleeRange;
		this.calculatedAttack.MeleeReach += stats.MeleeReach;
		
		this.calculatedAttack.Projectile = attack.Projectile;
		this.calculatedAttack.HoldProjectile = attack.HoldProjectile;
		
		this.calculatedAttack.MultipleNumber += stats.MultipleNumber;
		this.calculatedAttack.MultipleRange += stats.MultipleRange;
		this.calculatedAttack.AreaOfEffect += stats.AreaOfEffect;
		
		this.calculatedAttack.AddHoldDamage += stats.AddHoldDamage;
		
		this.calculatedAttack.Knockback += stats.Knockback;
		this.calculatedAttack.CritChance += stats.CritChance;
		this.calculatedAttack.AddCritDamage += stats.AddCritDamage;
		this.calculatedAttack.Recharge += stats.Recharge;
	}
	
	private void Attack()
	{
		 if (calculatedAttack.Type == AttackType.MELEE)
		 {
		 	Melee();
		 }
		if (calculatedAttack.Type == AttackType.RANGE_SINGLE)
		{
			RangeSingle();
		}
		if (calculatedAttack.Type == AttackType.RANGE_MULTIPLE)
		{
			RangeMultiple();
		}
	}
	
	private void Melee()
	{
		Debug.Log("BFA: Melee");
	}
	
	private void RangeSingle()
	{
		Debug.Log("BFA: RangeSingle");
		projectileSpawn = combat.ProjectileSpawn.transform.position;
		projectile = isStrong ? calculatedAttack.HoldProjectile : calculatedAttack.Projectile;
		
		GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(AimAngle, Vector3.forward));
	}
	
	private void RangeMultiple()
	{
		Debug.Log("BFA: RangeMultiple");
		float AimRange = calculatedAttack.MultipleRange;
		int Projectiles = calculatedAttack.MultipleNumber;
		GameObject projectile = isStrong ? calculatedAttack.HoldProjectile : calculatedAttack.Projectile;
		projectileSpawn = combat.ProjectileSpawn.transform.position;
		
		
		if (Projectiles < 1)
		{
			Debug.LogError("BFA: You cannot have zero or negative projectiles");
		}
		
		else if(Projectiles == 1)
		{
			Debug.LogError("BFA: Only 1 projectile for RANGE_MULTIPLE Attack");
		}
		
		else if(Projectiles % 2 == 0) // Even
		{
			Debug.Log("Even");
			float AngleInterval = (AimRange / 2) / (Projectiles / 2);
			// Upper
			float CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle += AngleInterval, Vector3.forward));
			}
			// Lower
			CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle -= AngleInterval, Vector3.forward));
			}
		}
		
		else if(calculatedAttack.MultipleNumber % 2 != 0) // Odd
		{
			GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(AimAngle, Vector3.forward));
			Debug.Log("Even");
			float AngleInterval = (AimRange / 2) / (Projectiles / 2);
			// Upper
			float CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle += AngleInterval, Vector3.forward));
			}
			// Lower
			CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle -= AngleInterval, Vector3.forward));
			}
		}
	}
}