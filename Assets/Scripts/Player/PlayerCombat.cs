using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// This script handles aiming and combat
// TODO: Add Finite State Machine for Player Actions
// TODO: Add a Pause State

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] public GameObject Weapon;
	[SerializeField] private GameObject Arrow;
	[SerializeField] private GameObject ProjectileSpawn;

	
	private Rigidbody2D Rigid;
	private SpriteRenderer Sprite;
	private PlayerInputHandler InputH;


	private Quaternion rotation = new Quaternion();


	public bool canLook = true;
	private bool canShoot = true;


	private void Start()
	{
		Rigid = GetComponent<Rigidbody2D>();
		Sprite = GetComponent<SpriteRenderer>();
		InputH = GetComponent<PlayerInputHandler>();
	}


	private void Update()
	{

	}


	private void FixedUpdate()
	{
		if(canLook)
		{
			rotation = Quaternion.AngleAxis(InputH.AimAngle, Vector3.forward);
			Weapon.transform.rotation = rotation;
			SpriteFlipCheck();
		}
	}	
	
	
	public void Fire()
	{
		if (!canShoot){
			return;
		}
		else
		{
			Instantiate(Arrow, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
			StartCoroutine(CanShoot());
		}
	}
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(0.3f);
		canShoot = true;
	}


	private void SpriteFlipCheck()
	{
		if (InputH.AimVector.x < 0)
		{
			Sprite.flipX = true;
		}
		else if (InputH.AimVector.x > 0)
		{
			Sprite.flipX = false;
		}
	}
	
}
