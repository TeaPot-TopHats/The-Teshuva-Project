using System.Collections;
using UnityEngine;

// ! Depricated, do not use this script. It's here for reference and testing

public class arrow : MonoBehaviour
{	
	[SerializeField] private float speed = 6f;
	private Rigidbody2D Rigid;
	private bool stop = false;

IEnumerator ArrowTimer()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

	void Start()
	{
		StartCoroutine(ArrowTimer());
		Rigid = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(!stop)
		{
			transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<MJ>().Die();
			GameObject.Destroy(Rigid);
			stop = true;
		}
	}
}
