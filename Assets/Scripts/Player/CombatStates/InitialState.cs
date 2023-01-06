using UnityEngine;
using UnityEngine.InputSystem;


public class InitialState : CombatState
{
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button, Weapon weapon)
	{

	}
	
	
	public override void FixedUpdateState(PlayerCombat combat)
	{
		
	}
	

	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if (button.action.name == "Primary")
		{
			combat.SwitchState(combat.PrimaryAttackState, button);
		}
		else if (button.action.name == "Secondary")
		{
			combat.SwitchState(combat.SecondaryAttackState, button);
		}
	}
}
