using UnityEngine;


/*
	! This script:
	Stores all player information
*/


public class PlayerData : MonoBehaviour
{
	[SerializeField] public PlayerStat Stats;  // ! Temporary until I make the thing to calculate all player stats
	[SerializeField] public Weapon EquippedWeapon;
}


/*	
	* Git Commit
	Added Kockback to stats
	Added MeleeTest script to test how to do the range code for melee attacks (trying meshes right now with custom colliders)
	
	TODO
	Finish BFA
	
	
	? Suggestions
	"what I'm getting is: have all the same individual scripts right? remove the monobehavior so you can instantiate them
	then in a "master script" you can instantiate them and just pass what you need in the master script's awake method"
*/


/*
	! Get Assets by name
	Need to make Resources folder with the resources to load
	GameObject newObject = (GameObject)Instantiate(Resources.Load("Square"));
*/


/*
	! Spawn Projectile
	public void Fire(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if(canShoot)
		{
			if (button.canceled)
			{
				GameObject.Instantiate(combat.Arrow, combat.ProjectileSpawn.transform.position, combat.ProjectileSpawn.transform.rotation);
				combat.StartCoroutine(CanShoot());
			}	
		}
	}
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(0.3f);
		canShoot = true;
	}
*/
