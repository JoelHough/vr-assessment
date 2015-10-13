using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class switch_planet : MonoBehaviour {
	Dropdown dp;

	public GameObject PlanetToStartWith;

	public Camera Cam;

	public Rigidbody Sun;
	public Rigidbody Mercury;
	public Rigidbody Venus;
	public Rigidbody Earth;
	public Rigidbody Mars;
	public Rigidbody Jupiter;
	public Rigidbody Saturn;
	public Rigidbody Neptune;
	public Rigidbody Uranus;

	private Rigidbody[] planets;
	private GameObject CurrentPlanet;

	private const float ADDITIONAL_DISTANCE = 5;

	void Start () {
		dp = GetComponent<Dropdown> ();
		dp.onValueChanged.AddListener(onChange);

		planets = new Rigidbody[] {Sun, Mercury, Venus, Earth, Mars, Jupiter, Saturn, Neptune, Uranus};
		CurrentPlanet = PlanetToStartWith;
		adjustCameraDistance ();
	}

	void onChange (int value) {
		changeGameObject (planets [value]);
	}

	void changeGameObject (Rigidbody newBody) {
		GameObject oldPlanet = CurrentPlanet;
		CurrentPlanet = Instantiate(newBody, oldPlanet.transform.position, oldPlanet.transform.rotation) as GameObject;
		Destroy (oldPlanet);
		adjustCameraDistance ();
	}

	void adjustCameraDistance () {
		var distance = (CurrentPlanet.transform.lossyScale.y * -0.5 / Mathf.Tan (Cam.fieldOfView * 0.5f * Mathf.Deg2Rad)) - CurrentPlanet.transform.lossyScale.y - ADDITIONAL_DISTANCE;
		Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, (float)distance);
	}
}
