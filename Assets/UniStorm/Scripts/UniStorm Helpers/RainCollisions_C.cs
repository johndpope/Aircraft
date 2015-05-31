using UnityEngine;
using System.Collections;

public class RainCollisions_C : MonoBehaviour {

	public float burstEnergy = 10.0f;
	public Transform explosionObject;
	
	void LateUpdate () 
	{
		Particle[] theParticles = GetComponent<ParticleEmitter>().particles;
		int[] liveParticles = new int[theParticles.Length];
		var particlesToKeep = 0;
		for (var i = 0; i < GetComponent<ParticleEmitter>().particleCount; i++ )
		{
			if (theParticles[i].energy > burstEnergy)
			{
				theParticles[i].color = Color.yellow;
				
				//Once collided, splash.
				if (explosionObject)
					Transform.Instantiate(explosionObject, 
					                      theParticles[i].position,  
					                      Quaternion.identity );
				
			} else {
				liveParticles[particlesToKeep++] = i;
			}
		}
		// Copy
		Particle[] keepParticles = new Particle[particlesToKeep];
		
		for (var j = 0; j < particlesToKeep; j++)
			keepParticles[j] = theParticles[liveParticles[j]];
		GetComponent<ParticleEmitter>().particles = keepParticles;
	}
}
