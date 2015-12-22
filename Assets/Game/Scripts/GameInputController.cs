using UnityEngine;
using System.Collections;
using InControl;

public class GameInputController : MonoBehaviour {

	private static GameInputController instance ;
	
	public static  GameInputController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<GameInputController>();
		return instance;
	}

	public InputDevice GetDevice(){
		if (InputManager.Devices.Count>0){
			return  InputManager.Devices[0];
		}
		else{
			return null;
		}
	}

	public float GetAxis(string _axis){
		InputDevice inputDevice = GetDevice();
		if (inputDevice!=null){
			return inputDevice.GetControlByName(_axis).Value;
		}
		else {
			return 0;
		}
	}

	public bool GetButtonDown(string _buttonName){
		InputDevice inputDevice =GetDevice();
		if (inputDevice!=null){
			return inputDevice.GetControlByName(_buttonName).WasPressed;
		}
		else{
			return false;
		}
	}

	public bool GetButton(string _buttonName){
		InputDevice inputDevice =GetDevice();
		if (inputDevice!=null){
			return inputDevice.GetControlByName(_buttonName).IsPressed;
		}
		else{
			return false;
		}
	}

	public bool GetButtonUp(string _buttonName){
		InputDevice inputDevice = GetDevice();
		if (inputDevice!=null){
			return inputDevice.GetControlByName(_buttonName).WasReleased;
		}
		else{
			return false;
		}
	}

	void Update(){
		InputDevice inputDevice = InputManager.ActiveDevice;
		if (inputDevice.AnyButton.IsNotNull){
			Debug.Log(inputDevice.AnyButton.ToString());
		}
	}
}
