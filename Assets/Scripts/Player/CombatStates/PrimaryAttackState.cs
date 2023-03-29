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
	
	// BFA
	private bool isStrong = false;
	
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button, Weapon weapon)
	{
		Debug.Log("Entered Primary");
		this.attack = weapon.PrimaryAttack;

		this.interaction = attack.Interaction;
		this.holdTime = attack.HoldTime;
		this.rechargeTime = attack.Recharge;
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
				isStrong = true;
				combat.nBFA.PerformAttack(combat.GetPlayerStat(), attack, isStrong);
				canSwitch = true;
				wasHeld = false;
			}
			else if (button.canceled && wasHeld)
			{
				Debug.Log("P: FAILED");
				combat.StartCoroutine(Cooldown());
				isStrong = false;
				combat.nBFA.PerformAttack(combat.GetPlayerStat(), attack, false);
				canSwitch = true;
				wasHeld = false;
			}
		}
	}


	IEnumerator Cooldown()
	{
		canShoot = false;
		yield return new WaitForSeconds(rechargeTime);
		canShoot = true;
	}


	IEnumerator HoldTimer()
	{
		yield return new WaitForSeconds(holdTime);
		if (wasHeld)
		{
			Debug.Log("S: Held READY");
		}
	}

}
