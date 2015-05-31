#pragma strict

var uniStormSystem : GameObject;
//var zoneWeather : int;

var startingHour : int;
var endingHour : int;

var eventObject : GameObject;
var eventObject2 : GameObject;
var eventObject3 : GameObject;

var eventType : String;

function Start () {

	uniStormSystem = GameObject.Find("UniStormParent_JS/UniStormSystemEditor");

}

function Update () {

if (uniStormSystem.GetComponent(UniStormWeatherSystem_JS).hourCounter >= startingHour && uniStormSystem.GetComponent(UniStormWeatherSystem_JS).hourCounter <= endingHour)
{

		eventObject.SetActive(true);
		eventObject2.SetActive(false);
		eventObject3.GetComponent.<Renderer>().enabled = false;
}
else
{
eventObject.SetActive(false);
eventObject2.SetActive(true);
eventObject3.GetComponent.<Renderer>().enabled = true;
}


}

