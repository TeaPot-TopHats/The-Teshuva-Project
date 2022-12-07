using UnityEngine;

// This script moves the player

public class PlayerMovement : MonoBehaviour
{
	private PlayerInputHandler InputH;
	private PlayerStats Stats;
	private Animator Animator;
	private Rigidbody2D Rigid;

	private void Start()
	{
		Animator = GetComponent<Animator>();
		Rigid = GetComponent<Rigidbody2D>();
		InputH = GetComponent<PlayerInputHandler>();
		Stats = GetComponent<PlayerStats>();
	}
	
	private void FixedUpdate()
	{
		AnimationCheck();
		Rigid.MovePosition(Rigid.position + InputH.Movement * Stats.MOVESPEED * Time.fixedDeltaTime);
	}

	private void AnimationCheck() // Checks which animation to play
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
