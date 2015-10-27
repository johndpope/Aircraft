using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Vehicles.Aeroplane;

public class WarpController : WeaponObject {

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


	public Material warpMat;


	public float readyToWarpTime=0.2f;


	void Awake(){
		motionBlurScript=mainCamera.GetComponent<MotionBlur>();
		bloomScript=mainCamera.GetComponent<Bloom>();
		aircraftController=aircraft.GetComponent<AeroplaneController>();

	}

	// Use this for initialization
	void Start () {







//		ResetWarp();
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (Input.GetKeyUp(KeyCode.Q) || GameInputController.Instance().GetButtonDown("Button5") ){
			Warp();
		*/
	}

//	void ReadyToWarp() {
//		if (!readyToWarp && !inWarp) {
//			readyToWarp=true;
//			Object spark = Instantiate(warpSpark,transform.position,transform.rotation);
//			warpSE1.Play();
//			Time.timeScale=0.2f;
//
//		}
//	}

//	void ResetWarp () {
//		inWarp = false;
//
//		WarpSpark spark =(WarpSpark) Instantiate(warpSpark,sparkTransform.transform.position,sparkTransform.transform.rotation);
//		spark.transform.SetParent(transform);
//		warpSE2.Play();
//
//		warpAircraft.SetActive(false);
//		foreach (GameObject singlePart in AircraftParts) {
//
//			foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
//				singleMeshRenderer.enabled=true;
//			}
//		}
//
//		bloomScript.bloomIntensity=normalIntensity;
//		motionBlurScript.enabled=false;
//
//		aircraftController.AircraftMaxEnginePower(normalMaxEnginePower);
//		aircraftController.SetAircraftAerodynamicEffect(normalAerodynamicEffect);
//	}

	public void Warp () {
		if (!inWarp) {
			inWarp = true;
			inSpecialState=true;
			PlayVoice();
			StartCoroutine(DoWarp() );
		}
		else{
			inWarp = false;
		}
	}

	public override void FireButtonDown() {
		Warp();
	}



	public IEnumerator DoWarp(){
//		Fisheye eye=CameraController.Instance().tpsCam.GetComponent<Fisheye>();
//		eye.enabled=true;
//		eye.strengthX=0.0f;
//		eye.strengthY=eye.strengthX;

		float normalMaxEnginePower = aircraftController.MaxEnginePower;
		float normalAerodynamicEffect = aircraftController.AircraftAerodynamicEffect();
		float normalFieldOfView = mainCamera.fieldOfView;
		float normalIntensity = bloomScript.bloomIntensity;


		float interval=0.5f;
		Camera cam=CameraController.Instance().tpsCam.GetComponent<Camera>();

		WarpSpark spark = (WarpSpark)Instantiate(warpSpark,transform.position,transform.rotation);
		spark.transform.SetParent(transform);
		//spark.moveSpeed=aircraftController.ForwardSpeed;

		warpSE1.Play();

		//WARP Ready
		float toggle=0;
		float originTimeScale=Time.timeScale;
		float targetTimeScale=0.2f;


		Time.timeScale=targetTimeScale;
		interval=readyToWarpTime;
		while (toggle<interval){
			toggle+=TimerController.realDeltaTime;


//			Time.timeScale=Mathf.Lerp (originTimeScale,targetTimeScale,toggle/interval);
			yield return new WaitForEndOfFrame();
		}


		foreach (GameObject singlePart in AircraftParts) {
			foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
									singleMeshRenderer.enabled=false;
				
				//				singleMeshRenderer.material.shader.
				//				Material tmpMat=singleMeshRenderer.material;
				
				//				singleMeshRenderer.material.SetFloat("_Mode", 3);
				//				singleMeshRenderer.material.SetColor("_Color", new Color(0,0,0,0) );
				//				singleMeshRenderer.material.SetTexture("_MainTex",null);
				//				singleMeshRenderer.material.SetTexture("_SpecGlossMap",null);
				//				singleMeshRenderer.material.SetTexture("_BumpMap",null);
				//				singleMeshRenderer.material.SetTexture("_OcclusionMap",null);
				
				//				tmpMat.SetColor("_EmissionColor", new Color(0,1,0) );
				//				tmpMat.EnableKeyword("_ALPHABLEND_ON");
				//								singleMeshRenderer.material=tmpMat;
				
//				singleMeshRenderer.material=warpMat;
//				warpMat.SetFloat("_Cutoff",toggle/interval);
				//				singleMeshRenderer.materials=new Material[1];
				//				singleMeshRenderer.materials[0]=warpMat;
				//				singleMeshRenderer.materials[1]=warpMat;
			}
		}
		warpAircraft.SetActive(true);
		bloomScript.bloomIntensity=1;
		motionBlurScript.enabled=true;
		aircraftController.AircraftMaxEnginePower(200);
		aircraftController.SetAircraftAerodynamicEffect(0);

		//WARP
		toggle=0;
		originTimeScale=0.2f;
		targetTimeScale=0.5f;
		interval=0.5f;
		float orginFov=cam.fieldOfView;
		float targetFov=100;
//		Time.timeScale=targetTimeScale;
		while (toggle<interval){
			toggle+=TimerController.realDeltaTime;
			cam.fieldOfView=Mathf.Lerp (orginFov,targetFov,toggle/interval);
			Time.timeScale=Mathf.Lerp (originTimeScale,targetTimeScale,toggle/interval);
			yield return new WaitForEndOfFrame();
		}

		cam.fieldOfView=targetFov;
		Time.timeScale=targetTimeScale;

		//Warp mode
//		yield return new WaitForSeconds(warpTime);
		while(inWarp){

//			if (eye.strengthX<0.5f){
//				eye.strengthX+=0.2f*TimerController.realDeltaTime;
//				eye.strengthY=eye.strengthX;
//			}
			yield return new WaitForEndOfFrame();
		}


		//WARP Finished
		spark =(WarpSpark) Instantiate(warpSpark,sparkTransform.transform.position,sparkTransform.transform.rotation);
		//		spark.transform.SetParent(transform);
		spark.transform.SetParent(transform);
		spark.moveSpeed=6;
		warpSE2.Play();


		toggle=0;
		interval=0.3f;
		originTimeScale=1;
		while (toggle<interval){
			toggle+=TimerController.realDeltaTime;
			cam.fieldOfView=Mathf.Lerp (targetFov,orginFov,toggle/interval);
			//Time.timeScale=Mathf.Lerp (targetTimeScale,originTimeScale,toggle/interval);
			yield return new WaitForEndOfFrame();
		}
		cam.fieldOfView=orginFov;
		Time.timeScale=originTimeScale;

		
		warpAircraft.SetActive(false);
		foreach (GameObject singlePart in AircraftParts) {
			
			foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.enabled=true;
			}
		}
		
		bloomScript.bloomIntensity=normalIntensity;
		motionBlurScript.enabled=false;
		
		aircraftController.AircraftMaxEnginePower(normalMaxEnginePower);
		aircraftController.SetAircraftAerodynamicEffect(normalAerodynamicEffect);

//		while (eye.strengthX>0){
//			eye.strengthX-=TimerController.realDeltaTime;
//			eye.strengthY=eye.strengthX;
//			yield return new WaitForEndOfFrame();
//		}
//		eye.enabled=false;

		inWarp=false;
		inSpecialState=false;
	}
}
