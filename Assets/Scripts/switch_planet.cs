using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class switch_planet : MonoBehaviour {
	Dropdown dp;

	public GameObject PlanetToStartWith;

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

	void Start () {
		dp = GetComponent<Dropdown> ();
		dp.onValueChanged.AddListener(onChange);

		planets = new Rigidbody[] {Sun, Mercury, Venus, Earth, Mars, Jupiter, Saturn, Neptune, Uranus};
		CurrentPlanet = PlanetToStartWith;
	}

	void onChange (int value) {
		changeGameObject (planets [value]);
	}

	void changeGameObject (Rigidbody newBody) {
		GameObject oldPlanet = CurrentPlanet;
		CurrentPlanet = Instantiate(newBody, oldPlanet.transform.position, oldPlanet.transform.rotation) as GameObject;
		Destroy (oldPlanet);
	}

	
}
