using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{	
	[Header("Basic Info")]
	public string WeaponID;
	public string Name;
	public string Description;
	public Sprite sprite;
	

	[Header("Attacks")]
	public WeaponAttack PrimaryAttack;
	public WeaponAttack SecondaryAttack;
}