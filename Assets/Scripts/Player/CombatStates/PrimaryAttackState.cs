using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrimaryAttackState : CombatState
{
	// Control flow
	private bool canShoot = true; // Can we perform an attack?
	private bool wasHeld = false; // Are we holding the button?
	private bool rapidFire = false; // If the attack type is press, and we hold the mouse the attack happens as soon as it can
	private bool canSwitch = true; // Are we allowed to switch to another state?

	// Attack info		
	private WeaponAttack attack; // Stores the primary attack
	private InteractionType interaction; // Stores the interaction of the attack
	private float holdTime; // Stores the hold time that determines if the attack is strong or normal
	private float rechargeTime; // Stores the recharge time for the attack
	
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button)
	{
		Debug.Log("Entered Primary");
		if (combat.attackCancelled)
		{
			rapidFire = false;
			canSwitch = true;
			wasHeld = false;
			canShoot = true;
			
			combat.attackCancelled = false;
		}
	}


	public override void FixedUpdateState(PlayerCombat combat)
	{
		if (rapidFire && canShoot)
		{
			combat.nBFA.PerformAttack(combat.GetPlayerStat(), attack, false);
			combat.StartCoroutine(Cooldown());
		}
	}
	
	
	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		this.attack = combat.EquippedWeapon.PrimaryAttack;

		this.interaction = attack.Interaction;
		this.holdTime = attack.HoldTime;
		this.rechargeTime = attack.Recharge;

		if (button.action.name == "Primary")
		{
			if (interaction == InteractionType.PRESS)
			{
				Press(combat, button);
			}
			else if (interaction == InteractionType.HOLD)
			{
				Hold(combat, button);
			}
		}
		else if (button.action.name == "Secondary" && canSwitch)
		{
			combat.SwitchState(combat.SecondaryAttackState, button);
		}
		else if (button.action.name == "Dash")
		{
			// combat.SwitchState(combat.DashState, button);
			// rapidFire = false;
			// canSwitch = true;
			// wasHeld = false;
			// canShoot = true;
			
			if(button.started)
			{
				combat.SwitchState(combat.DashState, button);
				combat.switchBack = true;
				combat.previousState = "Primary"; 
				// rapidFire = false;
				// canSwitch = true;
				// wasHeld = false;
				// canShoot = true;
			}
		}
	}
	
	
	private void Press(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if (button.started)// && button.action.name == "Primary") <- this is here for reference
		{
			Debug.Log("P: Press Started");
			rapidFire = true;
			canSwitch = false;
		}
		else if (button.canceled)// && button.action.name == "Primary") <- this is here for reference
		{
			Debug.Log("P: Press Stopped");
			rapidFire = false;
			canSwitch = true;
		}
	}
	
	
	private void Hold(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if(canShoot)
		{
			if (button.started)
			{
				Debug.Log("P: Started");
				canSwitch = false;
				wasHeld = true;
				combat.StartCoroutine(HoldTimer());
			}
			if (button.canceled && button.duration >= holdTime && wasHeld)
			{
				Debug.Log("P: PERFORMED");
				combat.StartCoroutine(Cooldown());
				combat.nBFA.PerformAttack(combat.GetPlayerStat(), attack, true);
				canSwitch = true;
				wasHeld = false;
			}
			else if (button.canceled && wasHeld)
			{
				Debug.Log("P: FAILED");
				combat.StartCoroutine(Cooldown());
				combat.nBFA.PerformAttack(combat.GetPlayerStat(), attack, false);
				canSwitch = true;
				wasHeld = false;
			}
		}
	}


	private IEnumerator Cooldown()
	{
		canShoot = false;
		yield return new WaitForSeconds(rechargeTime);
		canShoot = true;
	}


	private IEnumerator HoldTimer()
	{
		yield return new WaitForSeconds(holdTime);
		if (wasHeld)
		{
			Debug.Log("S: Held READY");
		}
	}

}
