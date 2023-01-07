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
	Made BFA script and added stat calculation (adds up current player stats and weapons stats to help calculate final damage).
	Added isHeldReady to Primary and Secondary attack states to indicate when the the attack is ready (this might need to be implemented in another way, unity events?).
	
	
	TODO
	Finish BFA
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
