using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/* 	
	This script:
	Handles aiming and combat
	TODO: Add Finite State Machine for Player Actions
	TODO: Add a Pause State
*/

public class PlayerCombat : MonoBehaviour
{
	// General Components needed
	private PlayerInputHandler InputH;

	// Needed for combat
	[SerializeField] public GameObject WeaponObject;
	[SerializeField] private GameObject Arrow;
	[SerializeField] private GameObject ProjectileSpawn;
	
	// Aiming
	private Quaternion rotation = new Quaternion();

	// Control flow
	public bool canLook = true;
	private bool canShoot = true;


	private void Start()
	{
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
			WeaponObject.transform.rotation = rotation;
		}
	}	
	
	
	public void Fire(InputAction.CallbackContext context)
	{
		if (!canShoot){
			return;
		}
		else
		{
			if(context.canceled)
			{
				Instantiate(Arrow, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
				StartCoroutine(CanShoot());
			}
		}
	}
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(0.3f);
		canShoot = true;
	}
	
}
