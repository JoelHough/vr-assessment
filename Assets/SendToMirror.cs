using UnityEngine;
using System.Collections;

public class SendToMirror : MonoBehaviour {

	public Transform mirror;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mirror.SendMessage ("addPositionToBuffer", transform.position);
		mirror.SendMessage ("addRotationToBuffer", transform.rotation);
	}
}
