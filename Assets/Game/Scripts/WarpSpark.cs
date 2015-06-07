using UnityEngine;
using System.Collections;

public class WarpSpark : MonoBehaviour {

	public GameObject warpWave;
	public GameObject warpHeatwave;
	public Light warpLight;

	public float animationTime=0.5f;
	public float lifeTime=1;

	private float lifeTimer;
	private float animationTimer;

	// Use this for initialization
	void Start () {
		warpWave.transform.localScale = new Vector3(0.2f,1,0.2f);
		warpHeatwave.transform.localScale = new Vector3(0.2f,1,0.2f);

		lifeTimer = 0;
		animationTimer = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (lifeTimer < lifeTime) {
			lifeTimer+=Time.deltaTime;

			warpWave.transform.localScale = Vector3.Lerp(new Vector3(0.2f,1,0.2f),new Vector3(4,1,4),(animationTime-animationTimer)/animationTime);
			warpHeatwave.transform.localScale = Vector3.Lerp(new Vector3(0.2f,1,0.2f),new Vector3(4,1,4),(animationTime-animationTimer)/animationTime);
			animationTimer+=Time.deltaTime;
		}
		else {
			Destroy(this.gameObject);
		}
	
	}
}
