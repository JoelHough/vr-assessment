using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {
	
	public float planetSpeedRotation = 1.0f;
	
	float rotationSpeed = 10.0f;
	float lerpSpeed = 1.0f;
	
	private Vector3 speed = new Vector3();
	private Vector3 avgSpeed = new Vector3();
	private bool dragging = false;
	private Vector3 targetSpeedX = new Vector3();
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseOver() 
	{
		dragging = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && dragging) {
			speed = new Vector3(-Input.GetAxis ("Mouse X"), Input.GetAxis("Mouse Y"), 0);
			avgSpeed = Vector3.Lerp(avgSpeed,speed,Time.deltaTime * 5);
		} else {
			if (dragging) {
				speed = avgSpeed;
				dragging = false;
			}
			var i = Time.deltaTime * lerpSpeed;
			speed = Vector3.Lerp( speed, Vector3.zero, i);   
		}
		
		transform.Rotate(Vector3.up, speed.x * rotationSpeed, Space.World);
		
		
		if (!Input.GetMouseButton (0) && !dragging) {
			transform.Rotate (-Vector3.forward, Time.deltaTime * planetSpeedRotation);
		}
	}
}

