using System.Collections;
using UnityEngine;

// ! Depricated, do not use this script. It's here for reference

public class arrow : MonoBehaviour
{
	[SerializeField] private float speed = 6f; 

	IEnumerator ArrowTimer()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

	void Start()
	{
		StartCoroutine(ArrowTimer());
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
	}
	
	private void OnCollisionEnter2D(Collision2D other) {
		speed = 0;
	}
}
