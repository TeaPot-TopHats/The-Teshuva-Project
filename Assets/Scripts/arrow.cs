using System.Collections;
using UnityEngine;

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
}
