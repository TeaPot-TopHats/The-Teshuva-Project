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
	AnimationHandler can now update the weapon sprite
	Removed burst attack stats
*/

/*
	Get Assets by name
	GameObject newObject = (GameObject)Instantiate(Resources.Load("Square"));
*/
