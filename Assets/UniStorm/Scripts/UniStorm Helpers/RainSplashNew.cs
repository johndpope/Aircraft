using UnityEngine;
using System.Collections;

public class RainSplashNew : MonoBehaviour {

	public GameObject rainSplash;
	
	void OnParticleCollision ()
	{
		Particle[] particles = GetComponent<ParticleEmitter>().particles;
		Instantiate (rainSplash, particles[0].position, Quaternion.identity);
	}
}
