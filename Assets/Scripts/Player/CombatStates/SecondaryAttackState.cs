using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryAttackState : CombatState
{
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button)
	{
		Debug.Log("Entered Secondary");
	}
	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		
	}
}
