using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject invisibleCameraObject;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		
		offset = transform.position - invisibleCameraObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = invisibleCameraObject.transform.position + offset;
	}
}
