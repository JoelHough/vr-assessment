using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MirrorBehavior : MonoBehaviour {

	private List<Vector3> positionBuffer;
	private List<Quaternion> rotationBuffer;
	private bool started;
	private bool reading;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (reading) {
			Vector3 position = positionBuffer[0];
			Quaternion rotation = rotationBuffer[0];

			transform.position = position;
			transform.rotation = rotation;

			positionBuffer.Remove (position);
			rotationBuffer.Remove (rotation);
		}
	}

	void addPositionToBuffer(Vector3 position){
		positionBuffer.Add (position);

		if (!started) {
			StartCoroutine ("startReadBuffer");
			started = true;
		}
	}

	void addRotationToBuffer(Quaternion rotation){
		rotationBuffer.Add (rotation);
	}

	IEnumerable startReadBuffer(){
		yield return new WaitForSeconds(30f);
		reading = true;
	}

}
