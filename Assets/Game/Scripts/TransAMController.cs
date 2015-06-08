using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;

public class TransAMController : MonoBehaviour {
	public Camera mainCamera;
	public GameObject aircraft;
	public GameObject aircraftBody;
	public GameObject aircraftWings;
	public Material bodyTransAmMaterial;
	public Material wingsTransAmMaterial;
	public GameObject transAmAircraftShadow;
	public float transAmTime=10;
	public float transAmShadowDelayTime=0.02f;
	
	public bool inTransAM=false;
	
	public AudioSource transAmSE;

	private Material bodyNomalMaterial;
	private Material wingsNomalMaterial;
	
	private AeroplaneController aircraftController;

	private float transAmTimer;
	private float transAmShadowDelayTimer;
	
	private float normalMaxEnginePower;
	private float normalFieldOfView;
	// Use this for initialization
	void Start () {
	
		aircraftController=aircraft.GetComponent<AeroplaneController>();
		
		normalFieldOfView = mainCamera.fieldOfView;
		
		normalMaxEnginePower = aircraftController.MaxEnginePower;

		bodyNomalMaterial=aircraftBody.GetComponentInChildren<MeshRenderer>().material;
		wingsNomalMaterial=aircraftWings.GetComponentInChildren<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (inTransAM) {
			if(transAmTimer<transAmTime) {
				if (transAmShadowDelayTimer>transAmShadowDelayTime) {
					Object shadow = Instantiate(transAmAircraftShadow,transform.position,transform.rotation);
					transAmShadowDelayTimer=0;
				}
				else {
					transAmShadowDelayTimer+=Time.deltaTime;
				}
				transAmTimer+=Time.deltaTime;
			}
			else {
				Reset();
			}
		}

		if (Input.GetKey(KeyCode.T)){
			TransAM();
		}
	}

	void Reset() {
		inTransAM=false;
		transAmShadowDelayTimer=0;
		transAmTimer=0;
		foreach (MeshRenderer singleMeshRenderer in aircraftBody.GetComponentsInChildren<MeshRenderer>()) {
			singleMeshRenderer.material=bodyNomalMaterial;
		}

		foreach (MeshRenderer singleMeshRenderer in aircraftWings.GetComponentsInChildren<MeshRenderer>()) {
			singleMeshRenderer.material=wingsNomalMaterial;
		}

		aircraftController.AircraftMaxEnginePower(normalMaxEnginePower);
	}

	public void TransAM() {
		if (!inTransAM) {
			inTransAM=true;
			foreach (MeshRenderer singleMeshRenderer in aircraftBody.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.material=bodyTransAmMaterial;
			}
			
			foreach (MeshRenderer singleMeshRenderer in aircraftWings.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.material=wingsTransAmMaterial;
			}
			
			aircraftController.AircraftMaxEnginePower(50);

			transAmSE.Play();
		}
	}
}
