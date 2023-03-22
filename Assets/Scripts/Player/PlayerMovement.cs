using UnityEngine;

/*
	! This script:
	Handles player movement
*/

public class PlayerMovement : MonoBehaviour
{
	// General Components needed
	private Rigidbody2D Rigid;
	private PlayerInputHandler InputH;
	private PlayerData Data;
	
	// Control flow
	public bool canMove = true;
	

	private void Start()
	{
		Rigid = GetComponent<Rigidbody2D>();
		InputH = GetComponent<PlayerInputHandler>();
		Data = GetComponent<PlayerData>();
	}
	
	
	private void FixedUpdate()
	{
		if(canMove)
		{
			Vector2 targetSpeed = new Vector2(InputH.Movement.x * Data.Stats.MoveSpeed, InputH.Movement.y * Data.Stats.MoveSpeed);
			Vector2 speedDif = targetSpeed - Rigid.velocity;
			Vector2 actualSpeed = speedDif * new Vector2(12,12); // Change the vector values to change acceleration
			Rigid.AddForce(actualSpeed);
		}
		else
		{
			Rigid.velocity = Vector2.zero;
		}
	}

}
