using UnityEngine;
using System.Collections;

public class ZoomBehavior : MonoBehaviour {

	public Transform initialTarget;
	public Transform target;

	public float distance = 5f;
	public float zoomSpeed = 2;

	// ZoomCameraMouse
	public float MouseWheelSensitivity = 1;
	public float MouseZoomMin = 1.5f;
	public float MouseZoomMax = 18;

	// Use this for initialization
	void Start () {
		target = initialTarget;
		MouseZoomMin = calculateMin ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		Vector3 newPosition = target.position;
		newPosition.z = target.position.z - distance;
		transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * zoomSpeed);
		setDistanceWithMouse ();
	}

	void setDistanceWithMouse(){
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			
			if (distance >= MouseZoomMin && distance <= MouseZoomMax)
			{
				
				distance -= Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensitivity;
				
				if (distance < MouseZoomMin) { distance = MouseZoomMin; }
				if (distance > MouseZoomMax) { distance = MouseZoomMax; }
			}
		}
	}

	void changePlanet(Transform planet){
		target = planet;
		distance = 5f;
		MouseZoomMin = calculateMin ();
		if (MouseZoomMin > distance)
			distance = MouseZoomMin + 5f;
	}

	float calculateMin(){
		return (target.GetComponent<SphereCollider> ().radius * target.transform.lossyScale.x) + 1f;
	}
}
