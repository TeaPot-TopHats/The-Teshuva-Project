using UnityEngine;

public class PlayerWeaponObject : MonoBehaviour
{
	private Weapon CurrentWeapon;

	private SpriteRenderer Sprite;
	
	void Start()
	{
		Sprite = GetComponent<SpriteRenderer>();
		CurrentWeapon = GetComponentInParent<PlayerData>().EquippedWeapon;
		Sprite.sprite = CurrentWeapon.sprite;
	}
}
