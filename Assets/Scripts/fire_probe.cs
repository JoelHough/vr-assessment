using UnityEngine;
using System.Collections;

public class fire_probe : MonoBehaviour {

	public Rigidbody probe;
	public float velocity = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Jump")) {
			Vector3 startPosition = transform.position + new Vector3(1f, 0f, 1f);
			Vector3 shootVector = new Vector3(0f, 1f, 2f);
			Rigidbody newProbe = Instantiate(probe, startPosition, transform.rotation) as Rigidbody;
			newProbe.AddForce(shootVector*velocity,ForceMode.VelocityChange);
		}
	}
}
