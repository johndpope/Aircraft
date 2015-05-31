//Attach this script to a game object
//This script should automatically find the C# UniStorm editor
//Set your hour for the event for a printed debug log of a test event
//You will need to add a custom event yourself
//This is an example of how to access the time to do so

//UniStorm Time Event Script Example

//By: Black Horizon Studios

using UnityEngine;
using System.Collections;

public class UniStormTimeEventExample : MonoBehaviour {

	private GameObject uniStormSystem;
	public float hourOfEvent;
	public bool eventTestBool;
	
	void Awake () {

			//Find the UniStorm Weather System Editor, this must match the UniStorm Editor name
			uniStormSystem = GameObject.Find("UniStormSystemEditor");
	
	}
	
	void Start () {
		
		if (uniStormSystem == null)
		{
			//Error Log if script is unable to find UniStorm Editor
			Debug.LogError("<color=red>Null Reference:</color> You must have the UniStorm Editor in your scene and named 'UniStormSystemEditor'. Make sure your C# UniStorm Editor has this name. ");
		}
				
	}
	
	void Update () {
		
	if (uniStormSystem != null)
	{
			
		if (uniStormSystem.GetComponent<UniStormWeatherSystem_C>().hourCounter >= hourOfEvent && eventTestBool == false)
		{

     		//It's time for the an event based on the UniStorm time as long as there isn't an error finding the UniStorm Editor
			Debug.Log("This is a printed test event. If you see this your even was successful.");
			eventTestBool = true;
		}
		
	}
		
  }
	

}
