using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



// Comments
// New Input System = NIS




public class player_aiming : MonoBehaviour
{
	[SerializeField] private Vector2 mousePos;
	[SerializeField] private Camera camera;
	[SerializeField] private GameObject weapon;
	[SerializeField] private GameObject arrow;
	[SerializeField] private GameObject projectileSpawn;
	
	[SerializeField] private Vector2 lookDirection;
	private SpriteRenderer sprite;

	private bool canShoot = true;
	private Rigidbody2D rigid;


	void Start()
	{
		sprite = GetComponent<SpriteRenderer>();
		rigid = GetComponent<Rigidbody2D>();
	}


	void Update()
	{
		
	}
	
	
	private void FixedUpdate() 
	{
		lookDirection = mousePos - (Vector2)weapon.transform.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		weapon.transform.rotation = rotation;
		AnimationCheck();
	}


	void OnLook(InputValue value)
	{
		mousePos = camera.ScreenToWorldPoint(value.Get<Vector2>());
	}
	
	void OnFire(InputValue value)
	{
		FireArrow();
	}
	
	void FireArrow()
	{
		if(!canShoot) return;
		
		Instantiate(arrow, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
		StartCoroutine(CanShoot());
	}
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(0.1f);
		canShoot = true;
	}
	
	void AnimationCheck()
	{
		if (lookDirection.x < 0)
		{
			sprite.flipX = true;
		}
		else if (lookDirection.x > 0)
		{
			sprite.flipX = false;
		}
	}
	
}
