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
			Vector3 shootVector = transform.position + new Vector3(1f, 0f, 1f);
			Rigidbody newProbe = Instantiate(probe, shootVector, transform.rotation) as Rigidbody;
			newProbe.AddForce(transform.forward*velocity,ForceMode.VelocityChange);
		}
	}
}
