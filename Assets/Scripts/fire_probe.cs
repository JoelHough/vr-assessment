using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class fire_probe : MonoBehaviour {

	public Rigidbody probe;
	public float velocity = 10.0f;
	//public Slider changeVelocitySlider;
	public Transform creationPoint;

	List<Rigidbody> probes = new List<Rigidbody>();

	// Use this for initialization
	void Start () {
		//changeVelocitySlider.onValueChanged.AddListener(onVelocityChanged);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Jump")) {
			Vector3 shootVector = Camera.main.transform.forward.normalized;
			Rigidbody newProbe = Instantiate(probe, creationPoint.position, transform.rotation) as Rigidbody;
			newProbe.AddForce(shootVector*velocity,ForceMode.VelocityChange);
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

//	void onVelocityChanged (float value) {
//		velocity = value;
//	}
}
