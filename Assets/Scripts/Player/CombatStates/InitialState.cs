using UnityEngine;
using UnityEngine.InputSystem;


public class InitialState : CombatState
{
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button)
	{

	}
	

	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if(button.action.name == "Fire")
		{
			combat.SwitchState(combat.PrimaryAttackState, button);
		}
		else if (button.action.name == "Secondary")
		{
			combat.SwitchState(combat.SecondaryAttackState, button);
		}
	}
}
