using System;
using UnityEngine;
using InControl;


namespace BasicExample
{
	public class CubeController : MonoBehaviour
	{
		void Start(){
			var inputDevice = InputManager.ActiveDevice;
			for (int i=0;i<inputDevice.Controls.Length;i++){
				if (inputDevice.Controls[i]!=null){
					Debug.Log(inputDevice.Controls[i].ToString());
				}
			}
		}
		void Update()
		{
			// Use last device which provided input.
			var inputDevice = InputManager.ActiveDevice;
//			Debug.Log(inputDevice.Name);


//			for (int i=0;i<inputDevice.Controls.Length;i++){
//				if (inputDevice.Controls[i]!=null && inputDevice.Controls[i].Value!=0){
//					Debug.Log(inputDevice.Controls[i].ToString());
//				}
//			}
			Debug.Log("analog 0: "+Input.GetAxis("joystick 1 analog 0") );
			Debug.Log("analog 1: "+Input.GetAxis("joystick 1 analog 1") );
//			Debug.Log(inputDevice.LeftStick.X);

//			Debug.Log(inputDevice.);
			// Rotate target object with left stick.
			transform.Rotate( Vector3.down,  500.0f * Time.deltaTime * inputDevice.LeftStickX, Space.World );
			transform.Rotate( Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World );
		}
	}
}

