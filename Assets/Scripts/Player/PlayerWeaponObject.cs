using UnityEngine;

public class PlayerWeaponObject : MonoBehaviour
{
	private Weapon CurrentWeapon;
	
	void Start()
	{
		CurrentWeapon = GetComponentInParent<PlayerData>().EquippedWeapon;
	}
}
