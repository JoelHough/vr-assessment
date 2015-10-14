using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	private Rigidbody body;
	private Camera Cam;

	private string state = "";
	private Quaternion startRotation, endRotation;
	private Vector3 startPosition, endPosition;
	private float time = 0f;
	private const float period = 3f;

	public int velocity = 10;

	bool Move = false;
	bool showMenu = true;
	string showMenuText = "Hide";

	public GUISkin guiSkin;
	
	public string planetName;
	private GameObject planet;
	
	public float baseDistant = 2.5f;
	public float baseScrolSpeed = 0.1f;
	
	public Light SunLight;

	public ParticleSystem particles;

	void Start () {
		body = GetComponent<Rigidbody> ();
		Cam = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			body.AddForce(transform.forward * velocity, ForceMode.Acceleration);
		}

		if (Input.GetKey (KeyCode.S)) {
			body.AddForce (-1 * transform.forward * velocity, ForceMode.Acceleration);
		}

		if (state == "rotate") {
			if (time >= period) {
				state = "move";
				time = 0;
			} else {
				time += Time.deltaTime;
				Cam.transform.rotation = Quaternion.Slerp(startRotation, endRotation, time/period);
			}
		}

		if (state == "move") {
			particles.GetComponent<Renderer> ().enabled = true;
			if (time >= period) {
				state = "";
				time = 0;
				particles.GetComponent<Renderer> ().enabled = false;
			} else {
				time += Time.deltaTime;
				Cam.transform.position = Vector3.Slerp(startPosition, endPosition, time/period);
			}
		}
	}
		
	void OnGUI () {
		
		GUI.skin = guiSkin;
		
		if(GUI.Button(new Rect(20,Screen.height/2 + 200,100,40), showMenuText) && !Move) {
			if(showMenu)
			{
				showMenuText = "Show";
				showMenu = false;
			}
			else
			{
				showMenuText = "Hide";
				showMenu = true;
			}
		}
		if(showMenu)
		{
			GUI.Label(new Rect(Screen.width/2 + 40, 60,500,200), planetName);
			
			
			if(GUI.Button(new Rect(20,60,100,40), "Mercury")) {
				AssignPlanetCameraCoordinates("Mercury");
			}
			
			
			if(GUI.Button(new Rect(20,100,100,40), "Venus")) {
				AssignPlanetCameraCoordinates("Venus");
			}
			
			if(GUI.Button(new Rect(20,140,100,40), "Earth")) {
				AssignPlanetCameraCoordinates("Earth");
			}
			
			if(GUI.Button(new Rect(220,140,100,40), "Moon")) {
				AssignPlanetCameraCoordinates("Moon");
			}
			
			if(GUI.Button(new Rect(20,180,100,40), "Mars")) {
				AssignPlanetCameraCoordinates("Mars");
			}
			
			if(GUI.Button(new Rect(20,220,100,40), "Jupiter")) {
				AssignPlanetCameraCoordinates("Jupiter");
			}
			
			if(GUI.Button(new Rect(20,260,100,40), "Saturn")) {
				AssignPlanetCameraCoordinates("Saturn");
			}
			
			if(GUI.Button(new Rect(20,300,100,40), "Uranus")) {
				AssignPlanetCameraCoordinates("Uranus");
			}
			
			if(GUI.Button(new Rect(20,340,100,40), "Neptune")) {
				AssignPlanetCameraCoordinates("Neptune");
			}
			
			if(GUI.Button(new Rect(20,380,100,40), "Sun")) {
				AssignPlanetCameraCoordinates("Sun");
			}
		}
	}
	
	void AssignPlanetCameraCoordinates (string selectedPlanetName)
	{
		planetName = selectedPlanetName;
		planet = GameObject.Find(selectedPlanetName);

		body.velocity = Vector3.zero;
		body.angularVelocity = Vector3.zero;

		state = "rotate";

		startRotation = Cam.transform.rotation;
		Vector3 direction = Cam.transform.position - planet.transform.position;
		endRotation = Quaternion.LookRotation (direction * -1);

		startPosition = Cam.transform.position;
		var distance = (planet.transform.localScale.y * -0.5 / Mathf.Tan (Cam.fieldOfView * 0.5f * Mathf.Deg2Rad)) - planet.transform.localScale.y - baseDistant;
		endPosition = new Vector3(planet.transform.position.x, planet.transform.position.y, planet.transform.position.z + (float)distance);

		// Switch off flare if sun is selected
//		if(selectedPlanetName == "Sun")
//		{
//			SunLight.enabled = false;
//		}
//		else
//		{
//			SunLight.enabled = true;
//		}
	}
		
}
