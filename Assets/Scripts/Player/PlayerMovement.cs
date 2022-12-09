using UnityEngine;

// This script moves the player

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D Rigid;
	private Animator Animator;
	private PlayerInputHandler InputH;
	private PlayerStats Stats;
	
	
	public bool CanMove = true;
	

	private void Start()
	{
		Rigid = GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator>();
		InputH = GetComponent<PlayerInputHandler>();
		Stats = GetComponent<PlayerStats>();
	}
	
	
	private void FixedUpdate()
	{
		// if(CanMove)
		// {
		// 	AnimationCheck();
		// 	Rigid.MovePosition(Rigid.position + InputH.Movement * Stats.MOVESPEED * Time.fixedDeltaTime);
		// }
		if(CanMove)
		{
			AnimationCheck();
			Vector2 targetSpeed = new Vector2(InputH.Movement.x * Stats.MOVESPEED, InputH.Movement.y * Stats.MOVESPEED);
			Vector2 speedDif = targetSpeed - Rigid.velocity;
			Vector2 actualSpeed = speedDif * new Vector2(12,12); // Change the vector values to change acceleration
			Rigid.AddForce(actualSpeed);
		}
		else
		{
			Animator.SetBool("IsMoving", false);
		}
	}


	private void AnimationCheck()
	{
		// Walk animation
		if (InputH.Movement  == Vector2.zero)
		{
			Animator.SetBool("IsMoving", false);
		}
		else
		{
			Animator.SetBool("IsMoving", true);
		}
	}
}
