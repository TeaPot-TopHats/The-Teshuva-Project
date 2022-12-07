using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
	[SerializeField] private GameObject Weapon;
	[SerializeField] private GameObject ProjectileSpawn;
	[SerializeField] private GameObject Arrow;

	private Rigidbody2D Rigid;
	
	private SpriteRenderer Sprite;
	private PlayerInputHandler InputH;

	private Vector2 AimDirection;
	private bool canShoot = true;
	private float angle = 0f;
	private Quaternion rotation = new Quaternion();
	private bool rapidFire = false;
	private bool isPrimaryOn = false;
	private bool isSecondaryOn = false;


	private void Start()
	{
		Sprite = GetComponent<SpriteRenderer>();
		Rigid = GetComponent<Rigidbody2D>();
		InputH = GetComponent<PlayerInputHandler>();
	}


	private void Update()
	{
		if(rapidFire)
		{
			Fire();
		}
	}

	private void FixedUpdate()
	{
		AimDirection = InputH.MousePos - (Vector2)Weapon.transform.position;
		angle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
		rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		Weapon.transform.rotation = rotation;
		AnimationCheck();
	}


	public void RapidFire(InputAction.CallbackContext context)
	{
		if(!isSecondaryOn)
		{
			if (context.started)
			{
				Debug.Log("Rapid Started");
				rapidFire = true;
				isPrimaryOn = true;
			}
			else if (context.canceled)
			{
				Debug.Log("Rapid Ended");
				rapidFire = false;
				isPrimaryOn = false;
			}
		}
	}
	
	
	public void HoldFire(InputAction.CallbackContext context)
	{
		if(!isPrimaryOn)
		{
			if (context.started)
			{
				Debug.Log("Hold Started");
				//Debug.Log(context);
				isSecondaryOn = true;
			}
			else if (context.canceled && context.duration >= 0.4f)
			{
				//Debug.Log(context);
				Debug.Log("Hold Ended");
				SuperFire();
				isSecondaryOn = false;
			}
			else if (context.canceled)
			{
				//Debug.Log(context);
				Debug.Log("Hold Ended");	
				isSecondaryOn = false;			
			}
		}
	}
	
	
	public void Fire()
	{
		if (!canShoot){
			return;
		}
		else
		{
			Instantiate(Arrow, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
			StartCoroutine(CanShoot());
		}
	}
	public void SuperFire()
	{
		if (!canShoot) return;

		GameObject special = Instantiate(Arrow, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation);
		special.transform.localScale = new Vector3(0.1f, 0.8f, 1f);
		StartCoroutine(CanShoot());
	}
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(0.3f);
		canShoot = true;
	}


	private void AnimationCheck()
	{
		if (AimDirection.x < 0)
		{
			Sprite.flipX = true;
		}
		else if (AimDirection.x > 0)
		{
			Sprite.flipX = false;
		}
	}
	
}
