
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SixenseHand : MonoBehaviour
{
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;

	//Animator 	m_animator;
	float 		m_fLastTriggerVal;
	Vector3		m_initialPosition;
	Quaternion 	m_initialRotation;
	bool grabbing = false;

	protected void Start() 
	{
		// get the Animator
		//m_animator = gameObject.GetComponent<Animator>();
		m_initialRotation = transform.localRotation;
		m_initialPosition = transform.localPosition;
	}


	protected void Update()
	{
		if ( m_controller == null )
		{
			m_controller = SixenseInput.GetController( m_hand );
			if (m_controller == null) {
				return;
			}
		}

		float fTriggerVal = m_controller.Trigger;
		//fTriggerVal = Mathf.Lerp( m_fLastTriggerVal, fTriggerVal, 0.1f );
		//m_fLastTriggerVal = fTriggerVal;
		
		if ( fTriggerVal > 0.01f )
		{
			Grab();
		}
		else
		{
			Ungrab();
		}
	}

	protected void Grab()
	{
		if (grabbing) {
			return;
		}
		grabbing = true;
		//BroadcastMessage ("OnGrab");
	}

	protected void Ungrab()
	{
		if (!grabbing) {
			return;
		}
		grabbing = false;
		//BroadcastMessage ("OnUngrab");
	}
	
	// Updates the animated object from controller input.
	protected void UpdateHandAnimation()
	{
		/*
		// Point
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.ONE) : m_controller.GetButton(SixenseButtons.TWO) )
		{
			m_animator.SetBool( "Point", true );
		}
		else
		{
			m_animator.SetBool( "Point", false );
		}
		
		// Grip Ball
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.TWO) : m_controller.GetButton(SixenseButtons.ONE)  )
		{
			m_animator.SetBool( "GripBall", true );
		}
		else
		{
			m_animator.SetBool( "GripBall", false );
		}
				
		// Hold Book
		if ( m_hand == SixenseHands.RIGHT ? m_controller.GetButton(SixenseButtons.THREE) : m_controller.GetButton(SixenseButtons.FOUR) )
		{
			m_animator.SetBool( "HoldBook", true );
		}
		else
		{
			m_animator.SetBool( "HoldBook", false );
		}
				
		// Fist
		float fTriggerVal = m_controller.Trigger;
		fTriggerVal = Mathf.Lerp( m_fLastTriggerVal, fTriggerVal, 0.1f );
		m_fLastTriggerVal = fTriggerVal;
		
		if ( fTriggerVal > 0.01f )
		{
			m_animator.SetBool( "Fist", true );
		}
		else
		{
			m_animator.SetBool( "Fist", false );
		}
		
		m_animator.SetFloat("FistAmount", fTriggerVal);
		
		// Idle
		if ( m_animator.GetBool("Fist") == false &&  
			 m_animator.GetBool("HoldBook") == false && 
			 m_animator.GetBool("GripBall") == false && 
			 m_animator.GetBool("Point") == false )
		{
			m_animator.SetBool("Idle", true);
		}
		else
		{
			m_animator.SetBool("Idle", false);
		}*/
	}


	public Quaternion InitialRotation
	{
		get { return m_initialRotation; }
	}
	
	public Vector3 InitialPosition
	{
		get { return m_initialPosition; }
	}
}

