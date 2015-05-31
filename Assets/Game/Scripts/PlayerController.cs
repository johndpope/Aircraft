using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : BasePlayer {
	private static PlayerController instance ;
	
	public static  PlayerController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<PlayerController>();
		return instance;
	}

	public Image aimLockOn;

	public Aircraft player;

	void Update(){

	}
}
