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


	public enum ControlType{
		Keyboard=0,
		Controller=1,
		FlightAxis=2,

	}

	public ControlType controlType=ControlType.Keyboard;

	public InputDevice GetDevice(){
		if (controlType==ControlType.Keyboard){
			return null;
		}

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
//			Debug.Log(_axis+": "+inputDevice.GetControlByName(_axis).Value);
			return inputDevice.GetControlByName(_axis).Value;
		}
		else{
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

	void Start(){
		InputDevice inputDevice = InputManager.ActiveDevice;
		for (int i=0;i<inputDevice.Controls.Length;i++){
			if (inputDevice.Controls[i]!=null ){
				Debug.Log(inputDevice.Controls[i].ToString());
				Debug.Log(inputDevice.GetControlByName(inputDevice.Controls[i].Handle.ToString()) );
			}
		}
	}

	void Update(){
		InputDevice inputDevice = InputManager.ActiveDevice;
		if (inputDevice.AnyButton.WasPressed){
			Debug.Log(inputDevice.AnyButton.ToString());
		}

//		Debug.Log("analog 0: "+Input.GetAxis("Analog0") );
//		Debug.Log("analog 1: "+Input.GetAxis("Analog1") );
//		Debug.Log("analog 2: "+Input.GetAxis("Analog2") );
		for (int i=0;i<inputDevice.Controls.Length;i++){
			if (inputDevice.Controls[i]!=null && inputDevice.Controls[i].Value!=0){
				Debug.Log(inputDevice.Controls[i].ToString());
			}
		}
	}
}
