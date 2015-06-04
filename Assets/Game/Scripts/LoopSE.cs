using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LoopSE : MonoBehaviour {

	public float loopStartTime;
	public float loopEndTime;
	public bool isLoop=false;
	public bool isPlaying=false;
	
	private AudioSource SEAudioSource;

	// Use this for initialization
	void Start () {
		SEAudioSource = gameObject.GetComponent<AudioSource>();
		SEAudioSource.playOnAwake = false;
		
		SEAudioSource.loop=true;
		isLoop = false;
		isPlaying = false;
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
		if (!isPlaying && !SEAudioSource.isPlaying) {
			SEAudioSource.time = 0;
			SEAudioSource.Play();
			isPlaying = true;
		}
	}

	public void StopSE () {
		if (isPlaying) {
			SEAudioSource.Stop();
			isPlaying = false;
		}

	}
}
