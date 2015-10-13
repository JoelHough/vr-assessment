using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public static float range = 1000;
	public GameObject planet;
	public Rigidbody body;

	void Awake () {
		body = planet.GetComponent<Rigidbody> ();
	}

	public void changeGameObject (Rigidbody newBody) {
		GameObject oldPlanet = planet;
		Rigidbody oldBody = body;
		planet = Instantiate(newBody, body.transform.position, body.transform.rotation) as GameObject;
		body = planet.GetComponent<Rigidbody> ();
		Destroy (oldBody);
		Destroy (oldPlanet);
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
