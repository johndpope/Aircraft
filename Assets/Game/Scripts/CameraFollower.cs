using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {


	public Transform target;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target!=null){
			transform.rotation=target.rotation;
			transform.position=target.TransformPoint(offset);
		}
//		transform.LookAt(target);
	}
}
