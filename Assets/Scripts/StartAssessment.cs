using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartAssessment : MonoBehaviour {

	private Button button;

	private bool buttonEnabled = false;

	private float time = 0f;

	void Start () {
		button = GetComponent<Button> ();
		button.onClick.AddListener (switchLevels);
	}

	// Use this for initialization
	void Update () {
		if (buttonEnabled) {
			if (time >= 1) {
				time = 0;
				buttonEnabled = false;
			} else {
				time += Time.deltaTime;
				Color oldColor = button.image.color;
				button.image.color = new Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Lerp(0, 1, time));
			}
		}
	}

	public void showButton () {
		buttonEnabled = true;
	}

	public void hideButton () {
		buttonEnabled = false;
	}

	void switchLevels () {
		Application.LoadLevel ("shoot_em_up");
	}

}
