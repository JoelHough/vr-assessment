﻿using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public static float range = 1000;

	private Rigidbody body;

	void Awake () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{	
		if (body) {
			Collider[] cols = Physics.OverlapSphere (body.transform.position, range); 

			ArrayList rbs = new ArrayList ();
		
			foreach (Collider c in cols) {
				Rigidbody rb = c.attachedRigidbody;
				if (rb != null && rb != body && !rbs.Contains (rb)) {
					rbs.Add (rb);
					Vector3 offset = body.transform.position - c.transform.position;
					rb.AddForce (offset / offset.sqrMagnitude * body.GetComponent<Rigidbody>().mass);
				}
			}
		}
	}
}



// Mass for each planet:

// Mercury  5.53
// Venus    81.5
// Earth    100
// Moon     1.23
// Mars     10.7
// Jupiter  31780
// Saturn   9520
// Uranus   1450
// Neptune  1710
// Sun      33300000
// Pluto    .25  #neverforget
