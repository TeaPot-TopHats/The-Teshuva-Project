using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DashState : CombatState
{
	private PlayerCombat combat;
	private PlayerMovement PMove;
	private PlayerInputHandler InputH;
	public Rigidbody2D Rigid;
	
	private Vector2 direction;
	
	private bool canSwitch = true;
	private bool isDashing = false;
	private bool canDash = true;
	private bool isDirectionZero = false;
	
	
	private float dashSpeed = 35f;
	private float dashCooldown = 1f;
	private float dashTime = 0.12f;

		
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button)
	{
		Debug.Log("Entered Dash");
		this.combat = combat;
		this.PMove = combat.PMove;
		this.InputH = combat.InputH;
		this.Rigid = combat.Rigid;
	}


	public override void FixedUpdateState(PlayerCombat combat)
	{
		if(isDashing)
		{
			// combat.transform.Translate(direction * Time.fixedDeltaTime * dashSpeed);
			Rigid.velocity = direction * dashSpeed;
		}
	}


	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if (button.action.name == "Dash")
		{
			Dash(button);	
		}
		else if(button.action.name == "Primary")
		{
			if (button.canceled)
			{
				combat.attackCancelled = true;
			}
			else if (button.started && isDashing)
			{
				combat.attackCancelled = false;
			}
			else if (canSwitch)
			{
				combat.SwitchState(combat.PrimaryAttackState, button);
			}
		}
		else if (button.action.name == "Secondary")
		{
			if (button.canceled)
			{
				combat.attackCancelled = true;
			}
			else if (button.started && isDashing)
			{
				combat.attackCancelled = false;
			}
			else if (canSwitch)
			{
				combat.SwitchState(combat.SecondaryAttackState, button);
			}
		}
	}
	
	private void Dash(InputAction.CallbackContext button)
	{
		isDirectionZero = InputH.Movement.x == 0 && InputH.Movement.y == 0 ? true : false;

		if (button.started && canDash && !isDirectionZero)
		{
			direction = InputH.Movement;
			combat.StartCoroutine(DashTimer(button));
			combat.StartCoroutine(Cooldown());

			// Debug.Log("Dash: Dashed!");
		}
	}

	private IEnumerator DashTimer(InputAction.CallbackContext button)
	{
		isDashing = true;
		canSwitch = false;
		PMove.isDashing = true;
		
		yield return new WaitForSeconds(dashTime);
		// Rigid.velocity = Vector2.zero;
		// ! This bit above is optional and changes the feel of the dash
		
		isDashing = false;
		canSwitch = true;
		PMove.isDashing = false;
		
		if (combat.switchBack)
		{
			if (combat.previousState == "Primary")
			{
				combat.SwitchState(combat.PrimaryAttackState, button);
			}
			else if (combat.previousState == "Secondary")
			{
				combat.SwitchState(combat.SecondaryAttackState, button);
			}
			combat.switchBack = false;
		}
	}
	
	private IEnumerator Cooldown()
	{
		canDash = false;
		
		yield return new WaitForSeconds(dashTime + dashCooldown);
		Debug.Log("Dash Ready!");
		canDash = true;
	}
}
