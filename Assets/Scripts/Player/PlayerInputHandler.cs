using UnityEngine;
using UnityEngine.InputSystem;

// This script gets all of the input and stores received input values

public class PlayerInputHandler : MonoBehaviour
{
	[SerializeField] private Camera MainCamera;
	[SerializeField] private PlayerInput PlayerInputComponent;


	[SerializeField] public Vector2 Movement {get; set;}
	[SerializeField] private Vector2 LookPos {get; set;}
	[SerializeField] public  Vector2 AimVector {get; set;}
	[SerializeField] public float AimAngle {get; set;}
	[SerializeField] public string CurrentInputDevice { get; private set; }


	private PlayerCombat Combat;
	
	
	private void Start()
	{
		Combat = GetComponent<PlayerCombat>();
	}	
	
	
	public void OnLook(InputAction.CallbackContext context)
	{
		if(CurrentInputDevice == "Keyboard&Mouse")
		{
			LookPos = MainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
			AimVector = LookPos - (Vector2)Combat.Weapon.transform.position;
			AimAngle = Mathf.Atan2(AimVector.y, AimVector.x) * Mathf.Rad2Deg;
		}
		else if (CurrentInputDevice == "Gamepad" && context.performed)
		{
			LookPos = context.ReadValue<Vector2>();
			AimVector = LookPos;
			AimAngle = Mathf.Atan2(context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x) * Mathf.Rad2Deg;
		}
	}


	public void OnMove(InputAction.CallbackContext context)
	{
		Movement = context.ReadValue<Vector2>();
	}
	
	
	public void OnFire(InputAction.CallbackContext context)
	{
		
	}


	public void OnSecondary(InputAction.CallbackContext context)
	{

	}
	
	
	public void OnControlsChanged()
	{
		CurrentInputDevice = PlayerInputComponent.currentControlScheme;
		
		if (PlayerInputComponent.currentControlScheme == "Keyboard&Mouse")
		{
			//Debug.Log("Using Keyboard&Mouse");
			CurrentInputDevice = PlayerInputComponent.currentControlScheme;
		}
		else if (PlayerInputComponent.currentControlScheme == "Gamepad")
		{
			//Debug.Log("Using Gamepad");
			CurrentInputDevice = PlayerInputComponent.currentControlScheme;
		}
		else
		{
			//Debug.Log("Invalid Input Device: " + PlayerInputComponent.currentControlScheme);
		}
	}
}
