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
	// Temporary, internal variables
	private Vector3 projectileSpawn; // This needs to be updated with every attack
	private GameObject projectile;
	
	// Variables that hold the important data passed down from combat system
	private WeaponAttack calculatedAttack;
	private bool isStrong = false;
	private float AimAngle;
	private Vector2 AimVector;
	
	// External scripts required
	private PlayerCombat combat;
	[SerializeField] private LayerMask enemyLayer;
	
	// Debug stuff
	

	private void Start() {
		combat = GetComponent<PlayerCombat>();
	}
	
	public void PerformAttack(PlayerStat currentStats, WeaponAttack attack, bool isStrong)
	{
		CalculateStats(currentStats, attack); // We combine these and put the result in calculated attack
		
		this.isStrong = isStrong; // Was the attack held?
		
		AimAngle = combat.InputH.AimAngle - 90; // it needs to be -90 because of some math stuff idk 🤣
		
		Attack();
	}
	
	// ! This is temporary until we make a proper stat calculator in another script
	private void CalculateStats(PlayerStat stats, WeaponAttack attack)
	{
		this.calculatedAttack = new WeaponAttack(attack);
		Debug.LogWarning("BFA: Ignore the warning above.");
		this.calculatedAttack.MeleeRange += stats.MeleeRange;
		this.calculatedAttack.MeleeReach += stats.MeleeReach;
		
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
		
		// Debug stuff
		CircleCollider2D circleDebug = combat.ProjectileSpawn.GetComponent<CircleCollider2D>();
		circleDebug.radius = calculatedAttack.MeleeReach;		

		/*
			! For this to work properly
			I am using that is trigger collider as a debug tool. BUT
			You need to make sure the transform scales are properly set because they won't match otherwise.
			What I mean is, because the ProjectileSpawn is a child of Player it is also 5 times bigger. So anything in it like a collider(in this case OverlapCircle)
			we need to resize it by a 1/5th of the size to make the CircleCollider from the player (1x relative to the player) match the size of the
			OverLapCircle (5x relative to the player)
		*/

		Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(combat.ProjectileSpawn.transform.position, calculatedAttack.MeleeReach, enemyLayer);
		
		foreach(Collider2D enemy in enemyColliders)
		{
			Debug.Log("BFA: Enemy " + enemy.name);
			
			AimVector = combat.InputH.AimVector;
			
			Vector2 enemyToPlayerVector = enemy.transform.position - combat.ProjectileSpawn.transform.position; // Enemy - Player
			
			float dot = Vector2.Dot(AimVector, enemyToPlayerVector);
			float absolute = (Mathf.Sqrt(Mathf.Pow(AimVector.x, 2) + Mathf.Pow(AimVector.y, 2)) * Mathf.Sqrt(Mathf.Pow(enemyToPlayerVector.x, 2) + Mathf.Pow(enemyToPlayerVector.y, 2)));
			float angleBetween = Mathf.Acos(dot / absolute) * Mathf.Rad2Deg;
			
			// The reason I'm diving by 2 is because I'm thinking of MeleeRange as an FOV so if FOV is 30 they enemy can only be 15 degrees from the aim center.
			if(angleBetween < calculatedAttack.MeleeRange / 2)
			{
				enemy.GetComponent<MJ>().Die();
			}
			Debug.Log("BFA: Angle between enemy and player aim is " + angleBetween);
		}
	}
	
	private void RangeSingle()
	{
		Debug.Log("BFA: Ranged Single");
		
		projectileSpawn = combat.ProjectileSpawn.transform.position;
		projectile = isStrong ? calculatedAttack.HoldProjectile : calculatedAttack.Projectile;
		
		GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(AimAngle, Vector3.forward));
	}
	
	private void RangeMultiple()
	{
		Debug.Log("BFA: Ranged Multiple");
		
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
			Debug.Log("BFA: Even Projectiles");
			
			float AngleInterval = (AimRange / 2) / (Projectiles / 2); // The angle between each projectile
			
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
			Debug.Log("BFA: Odd Projectiles");
			
			float AngleInterval = (AimRange / 2) / (Projectiles / 2); // The angle between each projectile

			// Upper
			float CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle += AngleInterval, Vector3.forward));
			}
			
			GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(AimAngle, Vector3.forward)); // This is the projectile in the middle
			
			// Lower
			CurrentAngle = AimAngle;
			for (int i = 0; i < Projectiles / 2; i++)
			{
				GameObject.Instantiate(projectile, projectileSpawn, Quaternion.AngleAxis(CurrentAngle -= AngleInterval, Vector3.forward));
			}
		}

	}

}