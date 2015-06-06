using UnityEngine;
using System.Collections;

public class MagnumLaunchSpark : MonoBehaviour {

	public GameObject sparkRing;
	public GameObject sparkBall;
	public GameObject sparkLight;

	public Vector3 sparkRingStartScale=new Vector3(1,1,1);
	public Vector3 sparkRingEndScale=new Vector3(5,1,5);
	public Vector3 sparkBallStartScale=new Vector3(1,1,0.1f);
	public Vector3 sparkBallEndScale=new Vector3(6,1,0.1f);

	public float sparkLightStartIntensity=1.5f;
	public float sparkLightEndIntensity=0;

	public float time=1;
	public float startFadeOutTime=0.2f;

	private float sparkRingMaterialAlpha;
	private float sparkBallMaterialAlpha;
	private bool isSparking=false;
	private float currentTime=0;
	private Light lightComponent;

	// Use this for initialization
	void Start () {
		sparkRingMaterialAlpha=sparkRing.GetComponent<Renderer>().material.GetColor("_TintColor").a;
		sparkBallMaterialAlpha=sparkBall.GetComponent<Renderer>().material.GetColor("_TintColor").a;
		Reset();

	}
	
	// Update is called once per frame
	void Update () {
		if (isSparking) {
			float fracComplete = (time - currentTime) / time;
			sparkRing.transform.localScale=Vector3.Lerp(sparkRingEndScale,sparkRingStartScale,fracComplete);
			sparkBall.transform.localScale=Vector3.Lerp(sparkBallEndScale,sparkBallStartScale,fracComplete);

			float lSpeed = (sparkLightStartIntensity-sparkLightEndIntensity)/time*Time.deltaTime;
			lightComponent.intensity-=lSpeed;

			if (currentTime>startFadeOutTime) {
				Color matColor = sparkRing.GetComponent<Renderer>().material.GetColor("_TintColor");
				matColor.a = sparkRingMaterialAlpha*(1-(currentTime-startFadeOutTime)/(time-startFadeOutTime));

				sparkRing.GetComponent<Renderer>().material.SetColor("_TintColor", matColor);

				Color matColor2 = sparkBall.GetComponent<Renderer>().material.GetColor("_TintColor");
				matColor2.a = sparkBallMaterialAlpha*(1-(currentTime-startFadeOutTime)/(time-startFadeOutTime));
				sparkBall.GetComponent<Renderer>().material.SetColor("_TintColor", matColor2);


			}

			currentTime += Time.deltaTime;

			if (fracComplete<=0) {
				Reset();
			}
		}
	}

	public void Reset () {
		sparkRing.SetActive(false);
		sparkBall.SetActive(false);
		sparkLight.SetActive(false);
		
		sparkRing.transform.localScale = sparkRingStartScale;
		sparkBall.transform.localScale = sparkRingStartScale;

		Color matColor = sparkRing.GetComponent<Renderer>().material.GetColor("_TintColor");
		matColor.a = sparkRingMaterialAlpha;
		sparkRing.GetComponent<Renderer>().material.SetColor("_TintColor", matColor);
		
		Color matColor2 = sparkBall.GetComponent<Renderer>().material.GetColor("_TintColor");
		matColor2.a = sparkBallMaterialAlpha;
		sparkBall.GetComponent<Renderer>().material.SetColor("_TintColor", matColor2);
		
		lightComponent=sparkLight.GetComponent<Light>();
		lightComponent.intensity=sparkLightStartIntensity;
		isSparking=false;
		currentTime=0;
	}

	public void PlayAnimation () {
		sparkRing.SetActive(true);
		sparkBall.SetActive(true);
		sparkLight.SetActive(true);
		isSparking=true;
	}

	public bool IsSparking () {
		return isSparking;
	}
}
