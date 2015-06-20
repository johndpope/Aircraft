using UnityEngine;
using System.Collections;

public class InvisibleController : WeaponObject {
	public Material invisibleMat;
	public Material originMat;
	public Transform invisibleTarget;
	public GameObject aircraftBody;
	public GameObject aircraftWings;
	public Material bodyInvisibleMaterial;
	public Material wingsInvisibleMaterial;
	public bool isInvisible=false;
	public AudioSource warpSE1;
	public AudioSource warpSE2;
	public float fadeDuration=3;

	public GameObject warpAircraft;

	private Material bodyNomalMaterial;
	private Material wingsNomalMaterial;

	public override void Fire(){
		base.Fire();


		StartCoroutine(DoFire());
	}

	IEnumerator DoFire(){
		//warpSE1.Play();
		isInvisible=true;
		float toggle=0;
		float interval=fadeDuration;

		//warpAircraft.SetActive(true);

		while (toggle<interval){
			toggle+=TimerController.deltaTime;

			/*
			foreach (Transform singlePart in invisibleTarget) {
				foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {

					singleMeshRenderer.material=invisibleMat;
					invisibleMat.SetFloat("_Cutoff", (toggle/interval) );
				}
			}
			*/

			foreach (MeshRenderer singleMeshRenderer in aircraftBody.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.material=bodyInvisibleMaterial;
				bodyInvisibleMaterial.SetFloat("_Cutoff", (toggle/interval) );
			}
			
			foreach (MeshRenderer singleMeshRenderer in aircraftWings.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.material=wingsInvisibleMaterial;
				wingsInvisibleMaterial.SetFloat("_Cutoff", (toggle/interval) );
			}

			yield return new WaitForEndOfFrame();
		}

		while (isInvisible){
			yield return new WaitForEndOfFrame();
		}

		toggle=0;
		interval=fadeDuration;
		while (toggle<interval){
			toggle+=TimerController.deltaTime;

			foreach (MeshRenderer singleMeshRenderer in aircraftBody.GetComponentsInChildren<MeshRenderer>()) {
				//singleMeshRenderer.material=bodyInvisibleMaterial;
				bodyInvisibleMaterial.SetFloat("_Cutoff", (toggle/interval) );
			}
			
			foreach (MeshRenderer singleMeshRenderer in aircraftWings.GetComponentsInChildren<MeshRenderer>()) {
				//singleMeshRenderer.material=wingsInvisibleMaterial;
				wingsInvisibleMaterial.SetFloat("_Cutoff", (toggle/interval) );
			}
			/*
			foreach (Transform singlePart in invisibleTarget) {
				foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
//					singleMeshRenderer.material=invisibleMat;
					invisibleMat.SetFloat("_Cutoff", (1-toggle/interval) );
				}
			}
			*/


			
			yield return new WaitForEndOfFrame();
		}

		/*
		foreach (Transform singlePart in invisibleTarget) {
			foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
				singleMeshRenderer.material=originMat;
			}
		}
		*/

		foreach (MeshRenderer singleMeshRenderer in aircraftBody.GetComponentsInChildren<MeshRenderer>()) {
			singleMeshRenderer.material=bodyNomalMaterial;
		}
		
		foreach (MeshRenderer singleMeshRenderer in aircraftWings.GetComponentsInChildren<MeshRenderer>()) {
			singleMeshRenderer.material=wingsNomalMaterial;
		}

		//warpAircraft.SetActive(false);
	}


	// Use this for initialization
	void Start () {
		bodyNomalMaterial=aircraftBody.GetComponentInChildren<MeshRenderer>().material;
		wingsNomalMaterial=aircraftWings.GetComponentInChildren<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I) ){
			if (!isInvisible){
				Fire ();
			}
			else{
				isInvisible=false;
				//warpSE2.Play();
			}
		}
	}
}
