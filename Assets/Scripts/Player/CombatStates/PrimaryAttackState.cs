using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrimaryAttackState : CombatState
{
	// Control flow
	private bool canShoot = true;
	private bool wasHeld = false;
	private bool rapidFire = false;
	private bool canSwitch = true;

	// Attack info		
	private WeaponAttack attack;
	private InteractionType interaction;
	private float holdTime;
	private float rechargeTime;
	
	
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
			GameObject.Instantiate(attack.Projectile, combat.ProjectileSpawn.transform.position, combat.ProjectileSpawn.transform.rotation);
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
				GameObject.Instantiate(attack.HoldProjectile, combat.ProjectileSpawn.transform.position, combat.ProjectileSpawn.transform.rotation);
				canSwitch = true;
				wasHeld = false;
			}
			else if (button.canceled && wasHeld)
			{
				Debug.Log("P: FAILED");
				combat.StartCoroutine(Cooldown());
				GameObject.Instantiate(attack.Projectile, combat.ProjectileSpawn.transform.position, combat.ProjectileSpawn.transform.rotation);
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
        Debug.Log("P: Held READY");
	}

}
