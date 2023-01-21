using UnityEngine;
using UnityEngine.InputSystem;


public class DashState : CombatState
{
	private PlayerCombat combat;
	private PlayerMovement PMove;
	private PlayerInputHandler InputH;
	public Rigidbody2D Rigid;
	
	private Vector2 direction;
	
	private float dashSpeed = 5f;
	
	public override void EnterState(PlayerCombat combat, InputAction.CallbackContext button, Weapon weapon)
	{
		Debug.Log("Entered Dash");
		this.combat = combat;
		this.PMove = combat.PMove;
		this.InputH = combat.InputH;
		this.Rigid = combat.Rigid;
	}


	public override void FixedUpdateState(PlayerCombat combat)
	{

	}


	public override void PerformAction(PlayerCombat combat, InputAction.CallbackContext button)
	{
		if (button.started)
		{
			direction = InputH.Movement;
			PMove.canMove = false;
			combat.canAttack = false;
			Rigid.AddForce(direction * dashSpeed, ForceMode2D.Impulse);
			
		}
	}
}
