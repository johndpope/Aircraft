using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour {
	private static TimerController instance ;
	
	public static  TimerController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<TimerController>();
		return instance;
	}

	private float lastRealTime;
	public static float realDeltaTime;
	
	public static float deltaTime;
	public static float time;
	


	public void Awake()
	{
		lastRealTime = Time.realtimeSinceStartup;
	} 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		realDeltaTime=Time.realtimeSinceStartup - lastRealTime;
		lastRealTime=Time.realtimeSinceStartup;
		realDeltaTime=Mathf.Clamp(realDeltaTime,0,0.05f);
		deltaTime=realDeltaTime*Time.timeScale;
		
		time+=deltaTime;
	}
}
