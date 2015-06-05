using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {
	public AudioClip BGMClip;
	public float loopStartTime;
	public float loopEndTime;
	public AudioClip BGMClip2;
	public float loopStartTime2;
	public float loopEndTime2;
	public bool isLoop=false;
	public bool isPlaying=false;
	
	private AudioSource BGMAudioSource;

	// Use this for initialization
	void Start () {
		BGMAudioSource = gameObject.AddComponent<AudioSource>();
		BGMAudioSource.playOnAwake = false;
		BGMAudioSource.clip = BGMClip2;
		
		BGMAudioSource.loop=false;
		isLoop = false;
		isPlaying = false;

		StartMusic();
	}
	
	// Update is called once per frame
	void Update () {
		if (BGMAudioSource.isPlaying && BGMAudioSource.time >= loopEndTime2) {
			isLoop = true;
			float delayTime = BGMAudioSource.time - loopEndTime2;
			BGMAudioSource.time = loopStartTime2 + delayTime;
		}
	}

	public void StartMusic () {
		if (!isPlaying) {
			BGMAudioSource.time = 0;
			BGMAudioSource.Play();
			isPlaying = true;

		}
	}

	public void StopMusic () {
		if (isPlaying) {
			isPlaying = false;
			isLoop = false;
			BGMAudioSource.Stop();
		}

	}
}
