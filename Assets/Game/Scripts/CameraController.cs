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

	public GameObject fpsCam;
	public GameObject tpsCam;
	public GameObject curCam;

	public float maxRadialBlurStrength=3;

	private bool radialBlurActive;
	private Vector2 radialBlurCenter;
	private float radialBlurTime = 1;

	// Use this for initialization
	void Start () {
	
	}

	public void SwitchCamera(){
		if (tpsCam.gameObject.activeInHierarchy){
			tpsCam.gameObject.SetActive(false);
			fpsCam.gameObject.SetActive(true);
			curCam=fpsCam;
		}
		else{
			tpsCam.gameObject.SetActive(true);
			fpsCam.gameObject.SetActive(false);
			curCam=tpsCam;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F) ){
			SwitchCamera();
		}
	}

	public void AddRadialBlur(bool customBlur = false, Vector3 blurPos = default(Vector3)) {
		if (!radialBlurActive) {
			radialBlurActive = true;
			StartCoroutine(DoRadialBlur());
		}
		else {

		}

		Vector2 blurCenter = new Vector2(0.5f,0.5f);
		if (customBlur) {
			Vector3 screenPos = tpsCam.WorldToScreenPoint(blurPos);
			blurCenter = new Vector2(screenPos.x/Screen.currentResolution.width,screenPos.y/Screen.currentResolution.height);
			Debug.Log(screenPos);
			Debug.Log(blurCenter);
		}

		radialBlurCenter = blurCenter;
	}

	public IEnumerator DoRadialBlur() {

		RadialBlur radialBlur = tpsCam.GetComponent<RadialBlur>();

		float blurStrength = 0;

		float toggle=0;
		float interval=0.3f;

		radialBlur.enabled = true;

		radialBlur.blurStrength = blurStrength;
		radialBlur.blurCenter = radialBlurCenter;

		while (toggle<interval){
			toggle+=Time.deltaTime;
			blurStrength=Mathf.Lerp (blurStrength,maxRadialBlurStrength,toggle/interval);
			radialBlur.blurStrength = blurStrength;
			radialBlur.blurCenter = radialBlurCenter;
			yield return new WaitForEndOfFrame();
		}
		blurStrength = maxRadialBlurStrength;
		
		yield return new WaitForSeconds(radialBlurTime);
		
		toggle=0;
		interval=1;
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
