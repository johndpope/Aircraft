using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Camera camera;
	public Transform target;
	public Vector3 offset;
	public bool useSlerp=true;
	public float slerpSpeed=8f;
	public bool longRangeMode=false;
	public float longRangeSlerpSpeed=1f;

	public Vector3 normalPos=new Vector3(0,8,-20);
	public Vector3 longRangePos=new Vector3(0,8,-30);

	private float cameraModeChangeTime=0.5f;
	private float cameraModeChangeTimer;

	// Use this for initialization
	void Start () {
		cameraModeChangeTimer=cameraModeChangeTime;
	}
	
	// Update is called once per frame
	void LateUpdate () {

//		transform.LookAt(target);
	}

	void Update() {
		if (target!=null){
			if (useSlerp) {
				if (longRangeMode) {
					transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, longRangeSlerpSpeed*Time.deltaTime);
				}
				else {
					transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, slerpSpeed*Time.deltaTime);
				}

			}
			else {
				transform.rotation=target.rotation;
			}

			if (camera!=null) {

				if (cameraModeChangeTimer<cameraModeChangeTime) {

					if (longRangeMode) {

						camera.transform.localPosition=Vector3.Lerp(normalPos,longRangePos,cameraModeChangeTimer/cameraModeChangeTime);
						
					}
					else {

						camera.transform.localPosition=Vector3.Lerp(longRangePos,normalPos,cameraModeChangeTimer/cameraModeChangeTime);
					}

					cameraModeChangeTimer+=Time.deltaTime;
				}

			}

			transform.position=target.TransformPoint(offset);
		}
	}

	public void ChangeCameraMode(bool _longRangeMode=false) {
		longRangeMode=_longRangeMode;
		cameraModeChangeTimer=0;
	}
}
