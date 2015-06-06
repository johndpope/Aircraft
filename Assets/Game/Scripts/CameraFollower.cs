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

	private float cameraModeChangeTime=0.5f;

	// Use this for initialization
	void Start () {
	
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

				if (longRangeMode) {
					if (camera.transform.localPosition.z > -30) {
						camera.transform.localPosition=new Vector3(0,6,camera.transform.localPosition.z-(30-20)/cameraModeChangeTime*Time.deltaTime);
						
					}
					
				}
				else {
					if (camera.transform.localPosition.z < -20) {
						camera.transform.localPosition=new Vector3(0,6,camera.transform.localPosition.z+(30-20)/cameraModeChangeTime*Time.deltaTime);
					}
				}
			}


			
			
			transform.position=target.TransformPoint(offset);
		}
	}

}
