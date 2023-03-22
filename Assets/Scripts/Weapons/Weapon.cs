using UnityEngine;


/*
	! This script:
	Is a ScriptableObject to create all the weapons.
	It holds all the data for a weapon.
*/


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{	
	[Header("Basic Info")]
	public string WeaponID;
	public string Name;
	public string Description;
	public Sprite Sprite;
	

	[Header("Attacks")]
	public WeaponAttack PrimaryAttack;
	public WeaponAttack SecondaryAttack;
}