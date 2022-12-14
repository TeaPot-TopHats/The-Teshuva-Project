using UnityEngine;

public class PlayerWeaponObject : MonoBehaviour
{
	[SerializeField] private Weapon CurrentWeapon;

	private SpriteRenderer Sprite;
	
	void Start()
	{
		Sprite = GetComponent<SpriteRenderer>();
		Sprite.sprite = CurrentWeapon.sprite;
	}
}
