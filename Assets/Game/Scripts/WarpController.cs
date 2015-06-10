using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Vehicles.Aeroplane;

public class WarpController : MonoBehaviour {

	public Camera mainCamera;
	public GameObject aircraft;
	public GameObject[] AircraftParts;
	public GameObject warpAircraft;
	public float warpTime=5;

	public bool inWarp=false;

	public AudioSource warpSE1;
	public AudioSource warpSE2;

	public WarpSpark warpSpark;
	public GameObject sparkTransform;

	private MotionBlur motionBlurScript;
	private Bloom bloomScript;
	private AeroplaneController aircraftController;
	private float warpFadeTime=0.5f;
	private float warpFadeTimer;
	private float warpTimer;

	private float normalMaxEnginePower;
	private float normalAerodynamicEffect;
	private float normalIntensity;
	private float normalFieldOfView;

	private float readyToWarpTime=0.2f;
	private float readyToWarpTimer;
	private bool readyToWarp=false;
	// Use this for initialization
	void Start () {
		motionBlurScript=mainCamera.GetComponent<MotionBlur>();
		bloomScript=mainCamera.GetComponent<Bloom>();
		aircraftController=aircraft.GetComponent<AeroplaneController>();

		normalFieldOfView = mainCamera.fieldOfView;
		normalIntensity = bloomScript.bloomIntensity;

		normalMaxEnginePower = aircraftController.MaxEnginePower;
		normalAerodynamicEffect = aircraftController.AircraftAerodynamicEffect();

		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (inWarp) {

			if (mainCamera.fieldOfView < 100) {

				mainCamera.fieldOfView+=(100-normalFieldOfView)/warpFadeTime*Time.deltaTime;
			}

			if (warpTimer < warpTime) {
				warpTimer += Time.deltaTime;
			}
			else {
				Object spark = Instantiate(warpSpark,sparkTransform.transform.position,sparkTransform.transform.rotation);
				warpSE2.Play();
				Reset();
			}
		}
		else {
			if (mainCamera.fieldOfView > normalFieldOfView) {
				
				mainCamera.fieldOfView-=(100-normalFieldOfView)/warpFadeTime*Time.deltaTime;
			}
		}


		if (Input.GetKeyUp(KeyCode.Q)){
			//Warp();
			ReadyToWarp();
		}

		if (readyToWarp) {
			if (readyToWarpTimer<readyToWarpTime) {
				readyToWarpTimer+=Time.deltaTime;
			}
			else {
				readyToWarp=false;
				Warp();
			}
		}
	}

	void ReadyToWarp() {
		if (!readyToWarp && !inWarp) {
			readyToWarp=true;
			Object spark = Instantiate(warpSpark,transform.position,transform.rotation);
			
			Time.timeScale=0.2f;
			warpSE1.Play();
		}
	}

	void Reset () {
		inWarp = false;

		warpTimer=0;
		warpFadeTimer=0;

		readyToWarpTimer=0;

		warpAircraft.SetActive(false);
		foreach (GameObject singlePart in AircraftParts) {

			foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.enabled=true;
			}
		}
		Time.timeScale=1;
		//mainCamera.fieldOfView=normalFieldOfView;
		bloomScript.bloomIntensity=normalIntensity;
		motionBlurScript.enabled=false;

		aircraftController.AircraftMaxEnginePower(normalMaxEnginePower);
		aircraftController.SetAircraftAerodynamicEffect(normalAerodynamicEffect);
	}

	public void Warp () {
		if (!inWarp) {
			inWarp = true;

			foreach (GameObject singlePart in AircraftParts) {
				foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
					singleMeshRenderer.enabled=false;
				}
			}
			Time.timeScale=0.5f;

			warpAircraft.SetActive(true);

			bloomScript.bloomIntensity=1;
			motionBlurScript.enabled=true;
			
			aircraftController.AircraftMaxEnginePower(200);
			aircraftController.SetAircraftAerodynamicEffect(0);



		}
	}
}
