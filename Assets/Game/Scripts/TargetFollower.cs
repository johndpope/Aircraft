using UnityEngine;
using System.Collections;

public class TargetFollower : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target!=null){
			transform.position=target.position+offset;
		}
	}
}
