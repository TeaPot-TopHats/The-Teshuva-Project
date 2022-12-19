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
	Added copy constructor in WeaponAttack script for future use with BFA
	Added PlayerStat class
	Restructured code, cleaned up some dependencies
	Now the PlayerData holds player stats and the equipped weapon 
*/
