using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryAttackState : CombatState
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
		Debug.Log("Entered Secondary");
		this.attack = weapon.SecondaryAttack;

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
		if(button.action.name == "Secondary")
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
		else if(button.action.name == "Primary" && canSwitch)
		{
			combat.SwitchState(combat.PrimaryAttackState, button);
		}
	}


	private void Press(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if (button.started && button.action.name == "Secondary")
		{
			Debug.Log("S: Press Started");
			rapidFire = true;
			canSwitch = false;
		}
		else if (button.canceled && button.action.name == "Secondary")
		{
			Debug.Log("S: Press Stopped");
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
				Debug.Log("S: Started");
				canSwitch = false;
				wasHeld = true;
			}
			if (button.canceled && button.duration >= holdTime && wasHeld)
			{
				Debug.Log("S: PERFORMED");
				combat.StartCoroutine(Cooldown());
				GameObject.Instantiate(attack.HoldProjectile, combat.ProjectileSpawn.transform.position, combat.ProjectileSpawn.transform.rotation);
				canSwitch = true;
				wasHeld = false;
			}
			else if (button.canceled && wasHeld)
			{
				Debug.Log("S: FAILED");
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
	
}
