using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour {

	public float TTL = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("TimeToLive");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator TimeToLive(){
		yield return new WaitForSeconds(TTL);
		Destroy (gameObject);
	}
}
