using UnityEngine;

/*
	! This script:
	Is a ScriptableObject holds the basic data for projectiles.
*/

[CreateAssetMenu(fileName = "Projectile", menuName = "Weapons/Projectile")]
public class Projectile : ScriptableObject
{
	[Header("Empty Projectile")]
	[Header("Basic Info")]
	public string ProjectileID;
	public string Name;
	public string Description;

	[Header("Projectile Info")]
	public Sprite Sprite;
	public Vector3 Scale;
	public ProjectileType Type;
	
}
