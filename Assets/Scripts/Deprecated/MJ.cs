using UnityEngine;

public class MJ : MonoBehaviour
{
	private AudioManager Audio; 
	
	
	private void Start() {
		Audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
	
	public void Die()
	{
		Debug.LogWarning("MJ: DEAD");
		Audio.Play("MJ Death");
		Destroy(gameObject);
	}
}
