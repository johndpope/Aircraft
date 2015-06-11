using UnityEngine;
using System.Collections;

public class MicroMissilePodController : WeaponObject {

	public MicroMissilePod microMissilePodPrefab;

	public CameraFollower cameraFollower;

	private MicroMissilePod microMissilePod;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.B)) {

			LaunchMicroMissilePod();
		}
	}

	public void Reload () {
		microMissilePod=null;
		cameraFollower.ChangeCameraMode(false);

	}

	void LaunchMicroMissilePod () {

		if (microMissilePod==null) {
			microMissilePod = (MicroMissilePod)Instantiate(microMissilePodPrefab,bulletTransform.transform.position,bulletTransform.transform.rotation);

			microMissilePod.player=owner.player;
			microMissilePod.microMissilePodController=this;

			this.GetComponent<AudioSource>().Play();

			cameraFollower.ChangeCameraMode(true);

		}
	}
}
