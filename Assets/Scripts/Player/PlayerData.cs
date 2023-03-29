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
	- Moved DamageCalculation script to stats folder.
	- Created simple enemy to test attacks, added the Audio Manager to my scene.
	- Edited arrow script for testing.
	- Made debug message for controller change a warning
	- Added RangedMultiple Attacks.
	- Fixed issue where I had not passed the Projectile prefabs to the new created object for BFA.
	
	
	
	TODO
	- Clean up BFA
	- Melee Attack
	
	TODO (Team)
	- Maitham, make the Audio Manager capable of playing multiple clips at the same time without cutting out the previous one
	
	? Suggestions
	"what I'm getting is: have all the same individual scripts right? remove the monobehavior so you can instantiate them
	then in a "master script" you can instantiate them and just pass what you need in the master script's awake method"
	
	When adding a magic force use a circular object that gets bigger away from the player and knocks back stuff. Under the hood
	it works the same way as melee, I think.
	
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
