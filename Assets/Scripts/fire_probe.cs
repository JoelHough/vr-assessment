using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fire_probe : MonoBehaviour {

	public Rigidbody probe;
	public float velocity = 10.0f;

	List<Rigidbody> probes = new List<Rigidbody>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Jump")) {
			Vector3 startPosition = transform.position + new Vector3(1f, 0f, 1f);
			Vector3 shootVector = new Vector3(1f, 1f, 1f);
			Rigidbody newProbe = Instantiate(probe, startPosition, transform.rotation) as Rigidbody;
			newProbe.AddForce(shootVector * velocity,ForceMode.VelocityChange);
			probes.Add(newProbe);
		}
	}

	public void destroyAllProbes () {
		int i;
		for (i = 0; i < probes.Count; i++) {
			Destroy(probes[i].gameObject);
		}
		probes = new List<Rigidbody> ();
	}
}
