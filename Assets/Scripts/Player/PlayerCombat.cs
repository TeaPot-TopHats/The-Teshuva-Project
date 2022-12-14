using UnityEngine;
using UnityEngine.InputSystem;


/* 	
	! This script:
	Handles aiming and combat
	TODO: Add a Pause State
*/


public class PlayerCombat : MonoBehaviour
{
	// General Components needed
	private PlayerInputHandler InputH;
	private PlayerData Data;

	// Needed for combat
	[SerializeField] public GameObject WeaponObject;
	[SerializeField] public GameObject ProjectileSpawn; // ! Temp
	private Weapon EquippedWeapon;
	
	// Aiming
	private Quaternion rotation = new Quaternion(); // Stores rotation calculated from PlayerInputHandler (see fixed update)

	// Control flow
	public bool canLook = true;
	public bool canAttack = true;

	// State Machine
	public CombatState InitialState = new InitialState();
	public CombatState PrimaryAttackState = new PrimaryAttackState();
	public CombatState SecondaryAttackState = new SecondaryAttackState();
	// ! => Dash state goes here
	public CombatState CurrentState;


	private void Start()
	{
		InputH = GetComponent<PlayerInputHandler>();
		CurrentState = InitialState;
		Data = GetComponent<PlayerData>();
		EquippedWeapon = Data.EquippedWeapon;
	}


	private void Update() {
		if (canLook)
		{
			rotation = Quaternion.AngleAxis(InputH.AimAngle, Vector3.forward);
			WeaponObject.transform.rotation = rotation;
		}
	}


	private void FixedUpdate()
	{
		CurrentState.FixedUpdateState(this);
	}
	
	
	// State Machine
	public void TriggerAction(InputAction.CallbackContext button)
	{
		if(canAttack)
		{
			CurrentState.PerformAction(this, button);
		}
	}
	
	
	public void SwitchState(CombatState newState, InputAction.CallbackContext button)
	{
		CurrentState = newState;
		newState.EnterState(this, button, EquippedWeapon);
		newState.PerformAction(this, button); // ! We perform so when we attack and switch state the attack gets performed
		// ! I decided to do this (PerformAction) here because it should be done like this for all states
	}
}
