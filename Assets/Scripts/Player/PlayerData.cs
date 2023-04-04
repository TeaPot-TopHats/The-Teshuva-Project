using UnityEngine;
using System.Collections.Generic;


/*
	! This script:
	Stores and handles all the player's information.
*/


public class PlayerData : MonoBehaviour
{
	[SerializeField] public PlayerStat Stats;  // ! Temporary until I make the thing to calculate all player stats
	
	[SerializeField] public Weapon EquippedWeapon;

	/*
	! For future use
	[SerializeField] public Weapon SecondWeapon;
	[SerializeField] public PlayerStat BasePlayerStats;
	[SerializeField] public PlayerClass PlayerClassStats;
	[SerializeField] public List<Boon> Boons;
	[SerializeField] public List<Effect> Effects;
	[SerializeField] public RelicStat Relic;
	*/
	
	public PlayerStat GetPlayerStat()
	{
		return Stats;
	}
}


/*	
	* Git Commit
	- Updated CombatState and classes derived from it to refernce the weapon on PlayerCombat instead of storing the attack once the
		state machine enters the state. This would result in the weapon not updating unless the player changed states.
	- Made the DashState, player can now dash. Bug-free so far.
	- Added quality of life feature, when you are shooting and then you dash, you will continue shooting after dash is done. Fixed issue where
		if you release fire button while dashing the player would continue shooting. This took me like 2 hours to add and fix.
	- Changed up dash values so the others can test how it should feel.
	
	TODO
	- Finish making Projectiles
		- Change Projectile in WeaponAttack and PlayerStat to a Projectile class instead of GameObject.
	- Clean up and comment DashState
	- Revise fix for dashing and attacking
	
	TODO (Team)
	- Maitham, make the Audio Manager capable of playing multiple clips at the same time without cutting out the previous one
	
	? Suggestions
	"what I'm getting is: have all the same individual scripts right? remove the monobehavior so you can instantiate them
	then in a "master script" you can instantiate them and just pass what you need in the master script's awake method"
	
	When adding a magic force use a circular object that gets bigger away from the player and knocks back stuff. Under the hood
	it works the same way as melee, I think.
	
	Look into object pooling
	
	* Notes:
	- Class Stats, Boons, Effects(Potions), and Relics will be done after the core game is done.
	
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
