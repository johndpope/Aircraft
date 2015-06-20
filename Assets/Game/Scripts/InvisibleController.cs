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
	public AudioSource invisibleSE1;
	public AudioSource invisibleSE2;
	public float fadeDuration=3;

	public GameObject invisibleAircraft;

	private Material bodyNomalMaterial;
	private Material wingsNomalMaterial;

	public override void Fire(){
		base.Fire();


		StartCoroutine(DoFire());
	}

	IEnumerator DoFire(){
		invisibleSE1.Play();
		isInvisible=true;
		float toggle=0;
		float interval=fadeDuration;

		invisibleAircraft.SetActive(true);

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

		toggle=fadeDuration;
		interval=fadeDuration;
		while (toggle>0){
			toggle-=TimerController.deltaTime;

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

		invisibleAircraft.SetActive(false);
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
				invisibleSE2.Play();
			}
		}
	}
}
