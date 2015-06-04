#pragma strict

@script RequireComponent(AudioSource)

public var BGMClip:AudioClip;
public var loopStartTime:double;
public var loopEndTime:double;
public var isLoop:boolean=false;

private var BGMAudioSource:AudioSource;

function Start () {
	BGMAudioSource = gameObject.AddComponent.<AudioSource>();
	BGMAudioSource.playOnAwake = false;
	BGMAudioSource.clip = BGMClip;
	
	BGMAudioSource.loop=false;
	isLoop = false;
	
	StartMusic();
}

function Update () {
	if (BGMAudioSource.isPlaying && BGMAudioSource.time >= loopEndTime) {
		isLoop = true;
		var delayTime:double = BGMAudioSource.time - loopEndTime;
		BGMAudioSource.time = loopStartTime + delayTime;
	}
	
}

function StartMusic () {
	BGMAudioSource.time = 0;
	BGMAudioSource.Play();
	
}