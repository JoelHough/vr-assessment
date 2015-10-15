using UnityEngine;
using System.Collections;

public class InvisibleObjectMovement : MonoBehaviour {
	
	
	public float speed;
	private Rigidbody rb;
	private Transform tf;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		tf = GetComponent<Transform> ();
	}

	
	void FixedUpdate () 
	{
	    float moveHorizontal = Input.GetAxis ("Horizontal");
	    float moveVertical = Input.GetAxis ("Vertical");
		
	    Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.MovePosition(transform.position + movement * Time.deltaTime * speed);

	}
}
