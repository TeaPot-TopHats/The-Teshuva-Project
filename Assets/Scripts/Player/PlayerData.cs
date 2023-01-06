using UnityEngine;

/*
	This script:
	Stores all player information
*/

public class PlayerData : MonoBehaviour
{
	[SerializeField] public PlayerStat Stats;
	[SerializeField] public Weapon EquippedWeapon;
}

/*	
	* Git Commit
	Added HoldProjectile to weapon attacks
	Finished state machine with primary and secondary attack states, both functional
	Combat states can differentiate between hold and press action types
	Yet to add BFA for performing the attacks but added projectile spawning for testing
	
	TODO
	Implement BFA
*/


/*
	Get Assets by name
	GameObject newObject = (GameObject)Instantiate(Resources.Load("Square"));
*/


/*
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
