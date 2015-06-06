using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {
	public AudioClip BGMClip;
	public float loopStartTime;
	public float loopEndTime;
	public AudioClip BGMClip2;
	public float loopStartTime2;
	public float loopEndTime2;
	public BGMData[] bgmData=new BGMData[1];
	public bool isLoop=false;
	public bool isPlaying=false;
	public int bgmID=0;
	public bool random=false;
	
	private AudioSource BGMAudioSource;


	// Use this for initialization
	void Start () {
		BGMAudioSource = gameObject.AddComponent<AudioSource>();
		BGMAudioSource.playOnAwake = false;

		
		BGMAudioSource.loop=false;
		isLoop = false;
		isPlaying = false;

		if (bgmID > bgmData.Length-1){
			bgmID=0;
		}
		BGMData currentBGMData;

		if (random) {
			int num = Mathf.FloorToInt(Random.Range(0,bgmData.Length));
			if (num>bgmData.Length-1) {
				num=bgmData.Length-1;
			}
			bgmID=num;
		}
		currentBGMData = bgmData[bgmID];
		BGMAudioSource.clip = currentBGMData.bgmClip;
		loopStartTime = currentBGMData.loopStartTime;
		loopEndTime = currentBGMData.loopEndTime;
		
		StartMusic();
	}
	
	// Update is called once per frame
	void Update () {
		if (BGMAudioSource.isPlaying && BGMAudioSource.time >= loopEndTime) {
			isLoop = true;
			float delayTime = BGMAudioSource.time - loopEndTime;
			BGMAudioSource.time = loopStartTime + delayTime;
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
