using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LoopSE : MonoBehaviour {

	public float loopStartTime;
	public float loopEndTime;
	public bool isLoop=false;
	
	private AudioSource SEAudioSource;

	// Use this for initialization
	void Start () {
		SEAudioSource = gameObject.GetComponent<AudioSource>();
		SEAudioSource.playOnAwake = false;
		
		SEAudioSource.loop=true;
		isLoop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (SEAudioSource.isPlaying && SEAudioSource.time >= loopEndTime) {
			isLoop = true;
			float delayTime = SEAudioSource.time - loopEndTime;
			SEAudioSource.time = loopStartTime + delayTime;
		}
	}

	public void PlaySE () {
		if (!SEAudioSource.isPlaying) {
			SEAudioSource.time = 0;
			SEAudioSource.Play();
		}
	}

	public void StopSE () {
		SEAudioSource.Stop();
	}
}
