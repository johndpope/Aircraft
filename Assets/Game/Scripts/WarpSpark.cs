using UnityEngine;
using System.Collections;

public class WarpSpark : MonoBehaviour {

	public GameObject warpWave;
	public GameObject warpHeatwave;
	public Light warpLight;

	public float animationTime=0.3f;
	public float lifeTime=1;

	public float moveSpeed=2;

	private float lifeTimer;
	private float animationTimer;

	// Use this for initialization
	void Start () {
		warpWave.transform.localScale = new Vector3(1f,1,1f);
		warpHeatwave.transform.localScale = new Vector3(1f,1,1f);

		lifeTimer = 0;
		animationTimer = 0;

	}
	
	// Update is called once per frame
	void Update () {

		if (lifeTimer < lifeTime) {
			lifeTimer+=Time.deltaTime;

			warpWave.transform.localScale = Vector3.Lerp(new Vector3(1f,1,1f),new Vector3(4,1,4),(animationTimer)/animationTime);
			warpHeatwave.transform.localScale = Vector3.Lerp(new Vector3(1f,1,1f),new Vector3(4,1,4),(animationTimer)/animationTime);
			animationTimer+=Time.deltaTime;

			transform.localPosition += new Vector3(0,0,-moveSpeed);
		}
		else {
			Destroy(this.gameObject);
		}
	
	}
}
