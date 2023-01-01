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
	ActionType is now called InteractionType
	Added PlayerCombat state machine and added InitialState, PrimaryAttackState, and SecondaryAttackState
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
