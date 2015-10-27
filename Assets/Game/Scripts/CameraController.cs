using UnityEngine;
using System.Collections;

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
}
