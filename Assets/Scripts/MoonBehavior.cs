using UnityEngine;
using System.Collections;

public class MoonBehavior : MonoBehaviour {

	public float TTL = 4f;
	public Transform explosionObj;

	private Transform explosion;

	// Use this for initialization
	void Start () {
		StartCoroutine ("TimeToLive");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col)
	{
		if (explosion == null) {
			explosion = Instantiate (explosionObj, col.contacts [0].point, transform.rotation) as Transform;
			Destroy (gameObject);
		}
	}

	IEnumerator TimeToLive(){
		yield return new WaitForSeconds(TTL);
		Destroy (gameObject);
	}
}
