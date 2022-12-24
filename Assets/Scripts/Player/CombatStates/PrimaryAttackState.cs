using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrimaryAttackState : CombatState
{
	// private bool canShoot = true;
	
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button)
	{
		PerformAction(combat, button);
	}
	
	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if(button.action.name == "Fire")
		{
			Debug.Log("Fire");
		}
		else if(button.action.name == "Secondary")
		{
			combat.SwitchState(combat.SecondaryAttackState, button);
		}
	}

}
