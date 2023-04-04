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
	public PlayerInputHandler InputH;
	public  PlayerData PData;
	public PlayerMovement PMove;
	public Rigidbody2D Rigid;

	// Needed for combat
	[SerializeField] public GameObject WeaponObject;
	[SerializeField] public GameObject ProjectileSpawn;
	public Weapon EquippedWeapon;
	[SerializeField] public BFA nBFA;
	
	// Aiming
	private Quaternion rotation; // Stores rotation calculated from PlayerInputHandler (see fixed update)

	// Control flow
	public bool canLook = true;
	public bool canAttack = true;

	// State Machine
	public CombatState InitialState = new InitialState();
	public CombatState PrimaryAttackState = new PrimaryAttackState();
	public CombatState SecondaryAttackState = new SecondaryAttackState();
	public CombatState DashState = new DashState();
	
	public CombatState CurrentState;

	public bool switchBack = false;
	public string previousState;
	public bool attackCancelled = false;


	private void Start()
	{
		InputH = GetComponent<PlayerInputHandler>();
		PData = GetComponent<PlayerData>();
		PMove = GetComponent<PlayerMovement>();
		
		Rigid = GetComponent<Rigidbody2D>();
		
		CurrentState = InitialState;
		
		EquippedWeapon = PData.EquippedWeapon;
		
		nBFA = GetComponent<BFA>();
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
		newState.EnterState(this, button);
		newState.PerformAction(this, button); // ! We perform so when we attack and switch state the attack gets performed
		// ! I decided to do this (PerformAction) here because it should be done like this for all states
	}
	
	public PlayerStat GetPlayerStat()
	{
		return PData.GetPlayerStat();
	}
}
