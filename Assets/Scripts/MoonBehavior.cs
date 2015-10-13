using UnityEngine;
using System.Collections;

public class MoonBehavior : MonoBehaviour {

	public float TTL = 4f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("TimeToLive");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col)
	{
		Destroy (gameObject);
	}

	IEnumerator TimeToLive(){
		yield return new WaitForSeconds(TTL);
		Destroy (gameObject);
	}
}
