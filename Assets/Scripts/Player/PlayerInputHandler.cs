using UnityEngine;
using UnityEngine.InputSystem;

/*
	This script:
	Handles the input received from the PlayerInput (which is an Input Actions Asset).
	The behavior of PlayerInput is set to "Invoke Unity Events". The event triggers a function here and passes a context.
	Stores the important information regarding input.
	Performs some calculations to convert mouse position to the correct angle where the player should be looking at.
*/

public class PlayerInputHandler : MonoBehaviour
{
	// General components needed
	[SerializeField] private Camera MainCamera; // Needed to convert the position of the mouse relatve to the camera to world coordinates
	[SerializeField] private PlayerInput PlayerInputComponent;

	// Movement
	[SerializeField] public Vector2 Movement;
	// [SerializeField] private float DeadZone = 0.1f;
	
	// Aiming
	private Vector2 AimCoord; // Stores the world location where the mouse or controller is pointing to
	[SerializeField] public  Vector2 AimVector {get; private set;} // Stores the vector that points to where we are aiming
	[SerializeField] public float AimAngle {get; set;} // We convert the AimVector to location and we put the angle where we are aiming here in degrees
	
	// Device
	[SerializeField] public string CurrentInputDevice { get; private set; }

	// Scripts that this script triggers
	private PlayerCombat Combat;
	
	
	private void Start()
	{
		Combat = GetComponent<PlayerCombat>();
	}	
	
	
	public void OnLook(InputAction.CallbackContext context)
	{
		if(CurrentInputDevice == "Keyboard&Mouse")
		{
			AimCoord = MainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
			AimVector = AimCoord - (Vector2)Combat.WeaponObject.transform.position;
			AimAngle = Mathf.Atan2(AimVector.y, AimVector.x) * Mathf.Rad2Deg;
		}
		else if (CurrentInputDevice == "Gamepad" && context.performed)
		{
			AimCoord = context.ReadValue<Vector2>();
			AimVector = AimCoord;
			AimAngle = Mathf.Atan2(context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x) * Mathf.Rad2Deg;
		}
	}
	

	public void OnMove(InputAction.CallbackContext context)
	{
		Movement = context.ReadValue<Vector2>();
		/*
			! Note
			! If using a controller; when pressing exactly up,down,left,or right; the value for that
			! may not be zero but some really small number such as 1.52E-05, instead. Be aware.
		*/
	}
	
	
	public void OnFire(InputAction.CallbackContext context)
	{

	}


	public void OnSecondary(InputAction.CallbackContext context)
	{

	}
	
	
	public void OnControlsChanged()
	{
		if(PlayerInputComponent.currentControlScheme == "Keyboard&Mouse" || PlayerInputComponent.currentControlScheme == "Gamepad")
		{
			Debug.Log("Controls Changed: Now using " + PlayerInputComponent.currentControlScheme);
			CurrentInputDevice = PlayerInputComponent.currentControlScheme;
		}
		else
		{
			Debug.Log("Input Device Not Supported: " + PlayerInputComponent.currentControlScheme);
			CurrentInputDevice = "NotSupported";
		}
	}

}
