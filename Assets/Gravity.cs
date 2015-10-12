using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public static float range = 1000;
	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () 
	{
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 

		ArrayList rbs = new ArrayList();
		
		foreach(Collider c in cols)
		{
			Rigidbody rb = c.attachedRigidbody;
			if(rb != null && rb != body && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * body.mass);
			}
		}
	}
}
