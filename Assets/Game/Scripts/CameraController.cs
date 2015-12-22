using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraController : MonoBehaviour {
	private static CameraController instance ;
	public static  CameraController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<CameraController>();
		return instance;
	}

	public Camera fpsCam;
	public Camera tpsCam;

	public float maxRadialBlurStrength=3;

	private float maxBlurStrength = 3;
	private bool radialBlurActive;
	private Vector2 radialBlurCenter;
	private float radialBlurTime = 1;

	private IEnumerator blurCoroutine;
	public GameObject curCam;
	// Use this for initialization
	void Start () {
	
	}

	public void SwitchCamera(){
		if (tpsCam.gameObject.activeInHierarchy){
			tpsCam.gameObject.SetActive(false);
			fpsCam.gameObject.SetActive(true);
			curCam=fpsCam.gameObject;
		}
		else{
			tpsCam.gameObject.SetActive(true);
			fpsCam.gameObject.SetActive(false);
			curCam=tpsCam.gameObject;
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F) ){
			SwitchCamera();
		}
	}

	public void AddRadialBlur(float blurStrength = 3, float blurTime = 1, bool customBlurPos = false, Vector3 blurPos = default(Vector3)) {
		if (blurStrength > maxRadialBlurStrength) {
			blurStrength = maxRadialBlurStrength;
		}

		radialBlurTime = blurTime;

		Vector2 blurCenter = new Vector2(0.5f,0.5f);
		if (customBlurPos) {
			Vector3 screenPos = tpsCam.WorldToScreenPoint(blurPos);
			blurCenter = new Vector2(screenPos.x/Screen.currentResolution.width,screenPos.y/Screen.currentResolution.height);
			Debug.Log(screenPos);
			//Debug.Log(blurCenter);

			if (blurCenter.x<0 || blurCenter.x>1 || blurCenter.y<0 || blurCenter.y>1) {
				maxBlurStrength = 1.6f;

			}

			float screenDistance = Mathf.Abs(screenPos.z);

			if (screenDistance > 400) {
				maxBlurStrength -= screenDistance/1000;
			}

			if (maxBlurStrength < 0.2f) {
				maxBlurStrength = 0.2f;
			}
		}

		radialBlurCenter = blurCenter;

		if (!radialBlurActive) {
			radialBlurActive = true;
			maxBlurStrength = blurStrength;
			blurCoroutine = DoRadialBlur();
			StartCoroutine(blurCoroutine);
		}
		else {
			if (blurStrength >= maxBlurStrength) {
				maxBlurStrength = blurStrength;
				StopCoroutine(blurCoroutine);
				radialBlurActive = true;
				blurCoroutine = DoRadialBlur();
				StartCoroutine(blurCoroutine);
			}

		}
	}

	public IEnumerator DoRadialBlur() {

		RadialBlur radialBlur = tpsCam.GetComponent<RadialBlur>();

		float blurStrength = 0;

		float toggle=0;
		float interval=0.01f;

		radialBlur.enabled = true;

		radialBlur.blurStrength = blurStrength;
		radialBlur.blurCenter = radialBlurCenter;

		while (toggle<interval){
			toggle+=Time.deltaTime;
			blurStrength=Mathf.Lerp (blurStrength,maxBlurStrength,toggle/interval);
			radialBlur.blurStrength = blurStrength;
			radialBlur.blurCenter = radialBlurCenter;
			yield return new WaitForEndOfFrame();
		}
		blurStrength = maxRadialBlurStrength;
		
		yield return new WaitForSeconds(radialBlurTime);
		
		toggle=0;
		interval=0.5f;
		while (toggle<interval){
			toggle+=Time.deltaTime;
			blurStrength=Mathf.Lerp (blurStrength,0,toggle/interval);
			radialBlur.blurStrength = blurStrength;
			radialBlur.blurCenter = radialBlurCenter;
			yield return new WaitForEndOfFrame();
		}

		blurStrength = 0;

		radialBlur.blurStrength = blurStrength;
		radialBlur.blurCenter = radialBlurCenter;

		radialBlur.enabled = false;

		radialBlurActive = false;
	}
}
