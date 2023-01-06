using UnityEngine;
using UnityEngine.InputSystem;

/* 	
	This script:
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
	[SerializeField] public GameObject ProjectileSpawn;
	private Weapon EquippedWeapon;
	
	// Aiming
	private Quaternion rotation = new Quaternion();

	// Control flow
	public bool canLook = true;
	public bool canAttack = true;

	// State Machine
	public CombatState InitialState = new InitialState();
	public CombatState PrimaryAttackState = new PrimaryAttackState();
	public CombatState SecondaryAttackState = new SecondaryAttackState();
	public CombatState CurrentState;


	private void Start()
	{
		InputH = GetComponent<PlayerInputHandler>();
		CurrentState = InitialState;
		Data = GetComponent<PlayerData>();
		EquippedWeapon = Data.EquippedWeapon;
	}


	private void FixedUpdate()
	{
		if (canLook)
		{
			rotation = Quaternion.AngleAxis(InputH.AimAngle, Vector3.forward);
			WeaponObject.transform.rotation = rotation;
		}
		CurrentState.FixedUpdateState(this);
	}
	
	
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
		newState.PerformAction(this, button);
	}
}
