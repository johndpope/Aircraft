using UnityEngine;
using System.Collections;

public class TransAMShadow : MonoBehaviour {

	public float lifeTime = 0.3f;
	public GameObject[] aircraftParts;

	private float lifeTimer;

	private Color originColor;
	// Use this for initialization
	void Start () {
		lifeTimer=0;

		//aircraftParts=this.gameObject.GetComponentsInChildren<GameObject>();

		originColor=aircraftParts[0].GetComponentInChildren<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTimer<lifeTime) {
			foreach (GameObject singlePart in aircraftParts) {
				
				foreach (MeshRenderer singleMeshRenderer in singlePart.GetComponentsInChildren<MeshRenderer>()) {
					Color matColor = singleMeshRenderer.material.color;
					matColor = Color.Lerp(originColor,new Color(0,0,0),lifeTimer/lifeTime);
					//matColor.r = matColor.r - originColor.r/lifeTime*Time.deltaTime;
					//matColor.g = matColor.g - originColor.g/lifeTime*Time.deltaTime;
					//matColor.b = matColor.b - originColor.b/lifeTime*Time.deltaTime;

					singleMeshRenderer.material.color=matColor;
				}
			}
			lifeTimer+=Time.deltaTime;
		}
		else {
			Destroy(this.gameObject);
		}
	}
}