using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryAttackState : CombatState
{
    // Control flow
    private bool canShoot = true; // Can we perform an attack?
    private bool wasHeld = false; // Did we perform a strong attack?
    private bool rapidFire = false; // If the attack type is press, and we hold the mouse the attack happens as soon as it can
    private bool canSwitch = true; // Are we allowed to switch to another state?

    // Attack info
    private WeaponAttack attack; // Stores the primary attack
    private InteractionType interaction; // Stores the interaction of the attack
    private float holdTime; // Stores the hold time that determines if the attack is strong or normal
    private float rechargeTime; // Stores the recharge time for the attack


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
		if (button.started)// && button.action.name == "Secondary") <- this is here for reference
        {
			Debug.Log("S: Press Started");
			rapidFire = true;
			canSwitch = false;
		}
		else if (button.canceled)// && button.action.name == "Secondary") <- this is here for reference
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
				combat.StartCoroutine(HoldTimer());
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
	
	IEnumerator HoldTimer()
	{
		yield return new WaitForSeconds(holdTime);
		if (wasHeld)
		{
			Debug.Log("S: Held READY");
		}
	}
	
}
