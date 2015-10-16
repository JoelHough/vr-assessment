using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SixenseGrabber : MonoBehaviour {
	Collider touching;
	GameObject grabbed;
	Transform initialParent;
	Vector3 initialTranslation;
	Quaternion initialGrabbedRotation;
	Quaternion initialHandRotation;
	SixenseHand hand;
	Vector3 axis;
	float angle;

	protected void Start() {
		hand = GetComponent<SixenseHand> ();
	}

	protected void FixedUpdate() {
		if ( hand.m_controller == null ) {
			return;
		}

		float fTriggerVal = hand.m_controller.Trigger;

		if ( fTriggerVal > 0.02f ) {
			Grab();
			if (grabbed != null) {
				var rb = grabbed.GetComponent<Rigidbody>();
				rb.velocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
				(transform.rotation * Quaternion.Inverse(initialHandRotation)).ToAngleAxis(out angle, out axis);
				grabbed.transform.position = transform.position + initialTranslation;
				grabbed.transform.rotation = initialGrabbedRotation;
				grabbed.transform.RotateAround(transform.position, axis, angle);
			}
		}
		else {
			Ungrab();
		}


	}
	
	protected void OnTriggerEnter(Collider other) {
		var pointer = new PointerEventData(EventSystem.current);
		if (other.gameObject.GetComponent<Rigidbody> () != null) {
			touching = other;
		}
		ExecuteEvents.ExecuteHierarchy(other.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
	}
	
	protected void OnTriggerExit(Collider other) {
		var pointer = new PointerEventData(EventSystem.current);
		ExecuteEvents.ExecuteHierarchy(other.gameObject, pointer, ExecuteEvents.pointerExitHandler);
		if (other == touching) {
			touching = null;
		}
	}
	
	protected void Grab() {
		if (touching == null || grabbed != null) {
			return;
		}
		grabbed = touching.gameObject;
		initialTranslation = grabbed.transform.position - transform.position;
		initialGrabbedRotation = grabbed.transform.rotation; //Quaternion.Inverse (grabbed.transform.rotation) * transform.rotation;
		initialHandRotation = transform.rotation;
	}
	
	protected void Ungrab() {
		if (grabbed == null) {
			return;
		}
		grabbed = null;
	}
}
