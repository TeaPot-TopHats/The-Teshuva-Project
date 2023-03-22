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
	[SerializeField] public Weapon SecondWeapon;
	
	[SerializeField] public PlayerStat BasePlayerStats;
	[SerializeField] public PlayerClass PlayerClassStats;
	[SerializeField] public List<Boon> Boons;
	[SerializeField] public List<Effect> Effects;
	[SerializeField] public RelicStat Relic;
}


/*	
	* Git Commit
	- Reorganized some folders and scripts as well as scritable object menus.
	- Created Boon, Class, Effect, and RelicStat scriptable objects.
	- Started to work on PlayerData to add things like effects, the relic the player is holding, etc.
	- Commented some scripts.
	
	
	TODO
	Player Stats:
		- Consult with team: each stat script
		- Add a way to change weapons
		- Add a system for Effects
		- Add a way of changing relic and a system for adding and removing boons
	Finish BFA:
		- Do Melee attacks
		- Implement Ranged attacks
	
	
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
