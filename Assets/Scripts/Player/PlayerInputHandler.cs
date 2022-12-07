using UnityEngine;
using UnityEngine.InputSystem;

// This script gets all of the input and stores received input values

public class PlayerInputHandler : MonoBehaviour
{
	[SerializeField] private Camera MainCamera;

	[SerializeField] public Vector2 Movement{get; set;}
	[SerializeField] public Vector2 MousePos{get; set;}
	[SerializeField] public Vector2 AimDirection{get; set;}


	private PlayerCombat Combat;
	
	
	private void Start()
	{
		Combat = GetComponent<PlayerCombat>();
	}


	private void Update()
	{
		GetMousePos();
	}
	
	private void GetMousePos()
	{
		MousePos = MainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		Movement = context.ReadValue<Vector2>();
	}
	
	
	public void OnFire(InputAction.CallbackContext context)
	{
		Combat.RapidFire(context);
	}


	public void OnSecondary(InputAction.CallbackContext context)
	{
		Combat.HoldFire(context);
	}
}

// TODO: Add controller support. All that needs to be implemented is aiming, everything else works.