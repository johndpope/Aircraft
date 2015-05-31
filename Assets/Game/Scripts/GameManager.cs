using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static GameManager instance ;
	
	public static  GameManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<GameManager>();
		return instance;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
