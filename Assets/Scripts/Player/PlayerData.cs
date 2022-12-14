using UnityEngine;

/*
	This script:
	Stores all player information
	
	TODO: Add way to handle damage, and attack damage calculation
*/

public class PlayerData : MonoBehaviour
{
	public int Health {get; set;}
	public float MoveSpeed {get; set;}
	public int Attack {get; set;}
	public int Defense {get; set;}
	public int Regen {get; set;}
	
	private void Start()
	{
		Health = 10;
		MoveSpeed = 4.5f;
		Attack = 5;
		Defense = 5;
		Regen = 1;
	}

}

/*	
	* Git Commit
	Added the following WeaponAttack variables: MultipleProjectileNumber, MultipleProjectilesRange, BurstSpeed, NumberOfBursts
	Rearranged some files in the editor's file structure
	Added editor icons to scritable objects
*/

// ? Ranged types: Single, Spread, Burst, Spread Burst
// ADD: Make a copy constructor for WeaponAttack and PlayerStats