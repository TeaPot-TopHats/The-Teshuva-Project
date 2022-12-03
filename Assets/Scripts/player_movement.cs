using UnityEngine;
using UnityEngine.InputSystem;



// New Input System = NIS



public class player_movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 4.5f;
	[SerializeField] private Vector2 moveInput;
	// [SerializeField] private Vector2 lastPosition;
	[SerializeField] private bool isWalkingIntoWall;
	
	private SpriteRenderer sprite;
	private Rigidbody2D rigid;
	private Animator animator;
	

	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		rigid = GetComponent<Rigidbody2D>();
		animator =GetComponent<Animator>();
		// lastPosition = transform.position;
	}

	void Update()
	{
	}
	
	private void FixedUpdate()
	{
		AnimationCheck();
		rigid.MovePosition(rigid.position + moveInput * moveSpeed * Time.fixedDeltaTime);
		// lastPosition = transform.position;
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
		if (moveInput.x < 0)
		{
			sprite.flipX = true;
		}
		else if (moveInput.x > 0)
		{
			sprite.flipX = false;
		}
		//Debug.Log("AnimationCheck()");
	}
	
	// private bool IsWalkingIntoWall()
	// {
	// 	if(transform.position.x == lastPosition.x && transform.position.y == lastPosition.y)
	// 	{
	// 		return true;
	// 	}
	// 	else
	// 	{
	// 		return false;
	// 	}
	// }
	
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

// TODO: Add check not whole collider but each side (top/bottom and left/right) so animation plays even if we are colliding but we move on the perpedicular direction
// TODO: Look into continuous vs discrete collisions
