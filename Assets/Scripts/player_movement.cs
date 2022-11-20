using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 1f;
	[SerializeField] private Vector2 moveInput;
	
	private Rigidbody2D rigid;
	

	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update()
	{

	}
	
	private void FixedUpdate()
	{
		rigid.MovePosition(rigid.position + moveInput * moveSpeed * Time.fixedDeltaTime);
	}
	
	void OnMove(InputValue value)
	{
		moveInput = value.Get<Vector2>();
	}
}
