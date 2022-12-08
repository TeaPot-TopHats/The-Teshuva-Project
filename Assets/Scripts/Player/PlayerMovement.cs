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
		if(CanMove)
		{
			AnimationCheck();
			Rigid.MovePosition(Rigid.position + InputH.Movement * Stats.MOVESPEED * Time.fixedDeltaTime);
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
