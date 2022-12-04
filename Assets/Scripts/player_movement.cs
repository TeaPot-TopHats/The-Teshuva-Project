using UnityEngine;
using UnityEngine.InputSystem;


// Comments
// New Input System = NIS



public class player_movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 4.5f;
	[SerializeField] private Vector2 moveInput;
	[SerializeField] private bool isWalkingIntoWall;
	

	private Rigidbody2D rigid;
	private Animator animator;
	

	private void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		animator =GetComponent<Animator>();
	}

	private void Update()
	{
	}
	
	private void FixedUpdate()
	{
		AnimationCheck();
		rigid.MovePosition(rigid.position + moveInput * moveSpeed * Time.fixedDeltaTime);
	}
	
	// This method is executed when the NIS calls it
	void OnMove(InputValue value)
	{
		moveInput = value.Get<Vector2>();
	}
	
	private void AnimationCheck() // Checks which animation to play
	{
		// Walk animation
		if (moveInput == Vector2.zero || isWalkingIntoWall)
		{
			animator.SetBool("IsMoving", false);
		}
		else
		{
			animator.SetBool("IsMoving", true);
		}

		// Flip sprite
	}

	
	private void OnCollisionStay2D(Collision2D other)
	{
		if((moveInput.x == 0 && moveInput.y != 0) || (moveInput.y == 0 && moveInput.x != 0))
		{
			isWalkingIntoWall = true;
		}
		else
		{
			isWalkingIntoWall = false;
		}
	}
	
	
	private void OnCollisionExit2D(Collision2D other)
	{
		isWalkingIntoWall = false;
	}

}
