using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class switch_planet : MonoBehaviour {
	Dropdown dp;

	public fire_probe probes;
	public Gravity gravity;

	public Rigidbody Sun;
	public Rigidbody Mercury;
	public Rigidbody Venus;
	public Rigidbody Earth;
	public Rigidbody Moon;
	public Rigidbody Mars;
	public Rigidbody Jupiter;
	public Rigidbody Saturn;
	public Rigidbody Neptune;
	public Rigidbody Uranus;

	private Rigidbody[] bodys;

	void Awake () {
		dp = GetComponent<Dropdown> ();
		dp.onValueChanged.AddListener(onChange);

		bodys = new Rigidbody[] {Sun, Mercury, Venus, Earth, Moon, Mars, Jupiter, Saturn, Neptune, Uranus};
	}

	void onChange (int value) {
		probes.destroyAllProbes ();
		gravity.changeGameObject (bodys [value]);
	}
	
}
