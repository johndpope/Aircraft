using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {
	private ParticleSystem ps;
	// Use this for initialization
	void Awake () {
		ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(ps)
		{
			if(!ps.IsAlive()){
				Destroy(gameObject);
			}
		}
	}
}
