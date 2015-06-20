using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;

public class TransAMController : MonoBehaviour {
	public Camera mainCamera;
	public CameraFollower cameraFollower;
	public GameObject aircraft;
	public GameObject aircraftBody;
	public GameObject aircraftWings;
	public Material bodyTransAmMaterial;
	public Material wingsTransAmMaterial;
	public GameObject transAmAircraftShadow;
	public float transAmTime=10;
	public float transAmShadowDelayTime=0.02f;
	
	public bool inTransAM=false;
	
	public AudioSource transAmStartSE;
	public AudioSource transAmEndSE;

	public ParticleSystem gnParticle;

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
				transAmEndSE.Play();
				Reset();
			}
		}

		if (Input.GetKey(KeyCode.T) || GameInputController.Instance().GetButtonDown("Button4") ){
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

		gnParticle.enableEmission = false;

		cameraFollower.ChangeCameraMode(false);
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

			gnParticle.enableEmission = true;

			transAmStartSE.Play();

			cameraFollower.ChangeCameraMode(true);
			StartCoroutine(DoLerpFov() );
		}
	}

	public IEnumerator DoLerpFov(){
		float toggle=0;
		float interval=0.5f;
		Camera cam=CameraController.Instance().tpsCam;

		float orginFov=cam.fieldOfView;
		float targetFov=80;
		while (toggle<interval){
			toggle+=Time.deltaTime;
			cam.fieldOfView=Mathf.Lerp (orginFov,targetFov,toggle/interval);
			yield return new WaitForEndOfFrame();
		}
		cam.fieldOfView=targetFov;

		yield return new WaitForSeconds(transAmTime);

		toggle=0;
		while (toggle<interval){
			toggle+=Time.deltaTime;
			cam.fieldOfView=Mathf.Lerp (targetFov,orginFov,toggle/interval);
			yield return new WaitForEndOfFrame();
		}
		cam.fieldOfView=orginFov;
	}
}
