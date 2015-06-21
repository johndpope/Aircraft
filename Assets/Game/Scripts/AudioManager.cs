using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance ;
	
	public static  AudioManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<AudioManager>();
		return instance;
	}

	private AudioSource audioSource;
	public float sfxVol=1;

	void Awake(){
		audioSource=GetComponent<AudioSource>();
	}

	public void PlaySFX(AudioClip _audioClip){
		audioSource.PlayOneShot(_audioClip,sfxVol);
	}
}
