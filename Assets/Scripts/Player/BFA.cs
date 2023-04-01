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
	private Vector3 projectileSpawnVector; // This needs to be updated with every attack
	private GameObject projectileObject;
	private bool isStrong = false;
	private float aimAngle;
	private Vector2 aimVector;
	Vector2 enemyToPlayerVector;
	float dotProduct;
	float absoluteMagnitude;
	float angleBetween;
	float aimRange;
	int numOfProjectiles;
	float angleInterval;
	float currentAngle;
	Collider2D[] enemyColliders;
	
	
	// Variables that hold the important data passed down from combat system
	private WeaponAttack wAttack;
	
	
	// External scripts required
	private PlayerCombat Combat;
	private PlayerInputHandler InputH;
	[SerializeField] private LayerMask EnemyLayer;
	
	
	// Debug stuff
	bool drawMeleeGizmos = false;
	bool drawRangedGizmos = false;
	

	private void Start() {
		Combat = GetComponent<PlayerCombat>();
		InputH = GetComponent<PlayerInputHandler>();
	}
	
	public void PerformAttack(PlayerStat currentStats, WeaponAttack attack, bool isStrong)
	{
		CalculateStats(currentStats, attack); // We combine these and put the result in calculated attack
		
		this.isStrong = isStrong; // Was the attack held?
		aimAngle = InputH.AimAngle - 90; // it needs to be -90 because of some math stuff idk 🤣
		
		Attack();
	}
	
	// ! This is temporary until we make a proper stat calculator in another script
	private void CalculateStats(PlayerStat stats, WeaponAttack attack)
	{
		this.wAttack = new WeaponAttack(attack);
		Debug.LogWarning("BFA: Ignore the warning above.");
		this.wAttack.MeleeRange += stats.MeleeRange;
		this.wAttack.MeleeReach += stats.MeleeReach;
		
		this.wAttack.MultipleNumber += stats.MultipleNumber;
		this.wAttack.MultipleRange += stats.MultipleRange;
		this.wAttack.AreaOfEffect += stats.AreaOfEffect;
		
		this.wAttack.AddHoldDamage += stats.AddHoldDamage;
		
		this.wAttack.Knockback += stats.Knockback;
		this.wAttack.CritChance += stats.CritChance;
		this.wAttack.AddCritDamage += stats.AddCritDamage;
		this.wAttack.Recharge += stats.Recharge;
	}
	
	private void Attack()
	{
		 if (wAttack.Type == AttackType.MELEE)
		 {
		 	Melee();
		 }
		if (wAttack.Type == AttackType.RANGE_SINGLE)
		{
			RangeSingle();
		}
		if (wAttack.Type == AttackType.RANGE_MULTIPLE)
		{
			RangeMultiple();
		}
	
	}
	
	private void Melee()
	{
		// Debug
		Debug.Log("BFA: Melee");		
		drawMeleeGizmos = true;
		drawRangedGizmos = false;
		
		projectileSpawnVector = Combat.ProjectileSpawn.transform.position;

		// We get all the enemyies we have hit
		enemyColliders = Physics2D.OverlapCircleAll(projectileSpawnVector, wAttack.MeleeReach, EnemyLayer);
		
		foreach(Collider2D enemy in enemyColliders)
		{
			Debug.Log("BFA: Enemy " + enemy.name);
			
			aimVector = Combat.InputH.AimVector; // The direction we are aiming

			enemyToPlayerVector = enemy.transform.position - projectileSpawnVector; // Enemy - Player
			
			dotProduct = Vector2.Dot(aimVector, enemyToPlayerVector);
			absoluteMagnitude = (Mathf.Sqrt(Mathf.Pow(aimVector.x, 2) + Mathf.Pow(aimVector.y, 2)) * Mathf.Sqrt(Mathf.Pow(enemyToPlayerVector.x, 2) + Mathf.Pow(enemyToPlayerVector.y, 2)));
			angleBetween = Mathf.Acos(dotProduct / absoluteMagnitude) * Mathf.Rad2Deg;
			
			// The reason I'm diving by 2 is because I'm thinking of MeleeRange as an FOV so if FOV is 30 they enemy can only be 15 degrees from the aim center.
			if(angleBetween < wAttack.MeleeRange / 2)
			{
				// Do damage
				enemy.GetComponent<MJ>().Die(); // This is for testing
			}
			Debug.Log("BFA: Angle between enemy and player aim is " + angleBetween);
		}
	}
	
	private void RangeSingle()
	{
		// Debug
		Debug.Log("BFA: Ranged Single");
		drawMeleeGizmos = false;
		drawRangedGizmos = true;
		
		projectileSpawnVector = Combat.ProjectileSpawn.transform.position;
		projectileObject = isStrong ? wAttack.HoldProjectile : wAttack.Projectile;
		
		// Spawn Projectile
		GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(aimAngle, Vector3.forward));
		// Pass down all the information to projectilea and initiate it
		//! insert code here
	}
	
	private void RangeMultiple()
	{
		// Debug
		Debug.Log("BFA: Ranged Multiple");
		drawMeleeGizmos = false;
		drawRangedGizmos = true;
		
		aimRange = wAttack.MultipleRange;
		numOfProjectiles = wAttack.MultipleNumber;
		projectileSpawnVector = Combat.ProjectileSpawn.transform.position;
		projectileObject = isStrong ? wAttack.HoldProjectile : wAttack.Projectile;
		
		
		if (numOfProjectiles < 1)
		{
			Debug.LogError("BFA: You cannot have zero or negative projectiles");
		}
		
		else if(numOfProjectiles == 1)
		{
			Debug.LogWarning("BFA: Only 1 projectile for RANGE_MULTIPLE Attack!");
		}
		
		else if(numOfProjectiles % 2 == 0) // Even
		{
			Debug.Log("BFA: Even Projectiles");
			
			// The angle between each projectile
			angleInterval = (aimRange / 2) / (numOfProjectiles / 2);
			
			// Upper
			currentAngle = aimAngle;
			for (int i = 0; i < numOfProjectiles / 2; i++, currentAngle += angleInterval)
			{
				// Spawn Projectile
				GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(currentAngle, Vector3.forward));
				// Pass down all the information to projectilea and initiate it
				//! insert code here
			}
			
			// Lower
			currentAngle = aimAngle;
			for (int i = 0; i < numOfProjectiles / 2; i++, currentAngle -= angleInterval)
			{
				// Spawn Projectile
				GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(currentAngle, Vector3.forward));
				// Pass down all the information to projectilea and initiate it
				//! insert code here
			}
		}
		
		else if(wAttack.MultipleNumber % 2 != 0) // Odd
		{
			Debug.Log("BFA: Odd Projectiles");
			
			angleInterval = (aimRange / 2) / (numOfProjectiles / 2); // The angle between each projectile

			// Upper
			currentAngle = aimAngle;
			for (int i = 0; i < numOfProjectiles / 2; i++, currentAngle += angleInterval)
			{
				// Spawn Projectile
				GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(currentAngle, Vector3.forward));
				// Pass down all the information to projectilea and initiate it
				//! insert code here
			}
			
			GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(aimAngle, Vector3.forward)); // This is the projectile in the middle
			
			// Lower
			currentAngle = aimAngle;
			for (int i = 0; i < numOfProjectiles / 2; i++, currentAngle -= angleInterval)
			{
                // Spawn Projectile
                GameObject.Instantiate(projectileObject, projectileSpawnVector, Quaternion.AngleAxis(currentAngle, Vector3.forward));
                // Pass down all the information to projectilea and initiate it
                //! insert code here
			}
		}

	}

	private void OnDrawGizmos() {
		
		if(drawMeleeGizmos)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(Combat.ProjectileSpawn.transform.position, Combat.InputH.AimVector); // Draws line from weapon to mouse cursor
			Gizmos.DrawWireSphere(Combat.ProjectileSpawn.transform.position, wAttack.MeleeReach); // Draws the reach of the melee weapon
		}
		else if(drawRangedGizmos)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawRay(Combat.ProjectileSpawn.transform.position, Combat.InputH.AimVector); // Draws line from weapon to mouse cursor
		}
	}

}