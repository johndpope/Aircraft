using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {


	public Transform target;
	public Vector3 offset;
	public bool useSlerp=true;
	public float slerpSpeed=10f;
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
				transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, slerpSpeed*Time.deltaTime);
			}
			else {
				transform.rotation=target.rotation;
			}
			
			
			transform.position=target.TransformPoint(offset);
		}
	}
}
