using UnityEngine;

/*
	This script:
	Handles sprites and animations
*/

public class AnimationHandler : MonoBehaviour
{
	private SpriteRenderer Sprite;
	private Rigidbody2D Rigid;
	private Animator Anim;
	
	private PlayerInputHandler InputH;
	private Weapon CurrentWeapon;
	[SerializeField] private GameObject WeaponObject;


	private SpriteRenderer WeaponSprite;
	
	
	private void Start()
	{
		Sprite = GetComponent<SpriteRenderer>();
		Rigid = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
		InputH = GetComponent<PlayerInputHandler>();
		CurrentWeapon = GetComponent<PlayerData>().EquippedWeapon;
		WeaponSprite = WeaponObject.GetComponent<SpriteRenderer>();
		UpdateWeaponSprite();
	}
	
	
	private void FixedUpdate()
	{
		SpriteFlipCheck();
		MovementAnimationCheck();
	}


	private void SpriteFlipCheck()
	{
		if (InputH.AimVector.x < 0)
		{
			Sprite.flipX = true;
			WeaponSprite.flipY = true;
		}
		else if (InputH.AimVector.x > 0)
		{
			Sprite.flipX = false;
			WeaponSprite.flipY = false;
			
		}
	}


	private void MovementAnimationCheck()
	{
		if (InputH.Movement == Vector2.zero)
		{
			Anim.SetBool("IsMoving", false);
		}
		else if ((InputH.Movement.y != 0 && Rigid.velocity.y == 0) && (Mathf.Abs(Rigid.velocity.x) != 0f))
		{
			Anim.SetBool("IsMoving", true);
		}
		else if ((InputH.Movement.y != 0 && Rigid.velocity.y == 0) && (Mathf.Abs(Rigid.velocity.x) == 0f))
		{
			Anim.SetBool("IsMoving", false);
		}
		else if ((InputH.Movement.x != 0 && Rigid.velocity.x == 0) && (Mathf.Abs(Rigid.velocity.y) != 0f))
		{
			Anim.SetBool("IsMoving", true);
		}
		else if ((InputH.Movement.x != 0 && Rigid.velocity.x == 0) && (Mathf.Abs(Rigid.velocity.y) == 0f))
		{
			Anim.SetBool("IsMoving", false);
		}
		else
		{
			Anim.SetBool("IsMoving", true);
		}
	}


	private void UpdateWeaponSprite()
	{
		WeaponSprite.sprite = CurrentWeapon.sprite;
	}
}
