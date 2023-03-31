using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
	// Passed down variables from the attack
	private float speed = 0;
	private float lifeTime = 0;
	private float travelTime = 0;
	private float AoE = 0;
	
	private void FixedUpdate() {
		transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
	}
	
	public void StartProjectile(WeaponAttack attack)
	{
		
	}
}
