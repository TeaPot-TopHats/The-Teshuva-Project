using UnityEngine;
using UnityEngine.InputSystem;

public abstract class CombatState
{	
	public abstract void EnterState(PlayerCombat combat, InputAction.CallbackContext button);
	public abstract void PerformAction(PlayerCombat combat, InputAction.CallbackContext button);
	public abstract void FixedUpdateState(PlayerCombat combat);
}
