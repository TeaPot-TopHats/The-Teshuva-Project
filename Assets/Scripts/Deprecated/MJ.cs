using UnityEngine;
using System.Collections;

public class MJ : MonoBehaviour
{
	private HolyLocalAudio Audio; 
	private bool isDead = false;

	private void Start() {
		Audio = gameObject.GetComponent<HolyLocalAudio>();
	}
	
	public void Die()
	{
		if(!isDead){
            Debug.LogWarning("MJ: DEAD");
            Audio.Play("MJ");
            StartCoroutine(DieWait());
			isDead = true;
		}
	}

    private IEnumerator DieWait()
    {
		Destroy(GetComponent<Collider2D>());
		Destroy(GetComponent<Rigidbody2D>());
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
