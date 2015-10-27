 using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
    [RequireComponent(typeof (AeroplaneController))]
    public class AeroplaneUserControl2Axis : MonoBehaviour
    {
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;
		public float pow=-1;

        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;


        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AeroplaneController>();
        }


        private void FixedUpdate()
        {
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.


			float roll=0;
			float pitch=0; 
			bool airBrakes=false; 
			float throttle=0;
//			roll= CrossPlatformInputManager.GetAxis("Horizontal");
//			pitch= CrossPlatformInputManager.GetAxis("Vertical");
//			airBrakes = CrossPlatformInputManager.GetButton("Fire1");
//			roll=Input.GetAxis("joystick 1 analog 0");

			if (GameInputController.Instance().GetDevice()!=null ){
				roll=GameInputController.Instance().GetAxis("Analog0");
				pitch=-GameInputController.Instance().GetAxis("Analog1");
//				Debug.Log("roll: "+roll);

			}
			else{

				if (Input.GetKey(KeyCode.UpArrow) ){
					pitch=1;
				}

				if (Input.GetKey(KeyCode.DownArrow) ){
					pitch=-1;
				}

				if (Input.GetKey(KeyCode.LeftArrow) ){
					roll=-1;
				}

				if (Input.GetKey(KeyCode.RightArrow) ){
					roll=1;
				}

				if (Input.GetKey(KeyCode.Q) ){
					pow+=Time.fixedDeltaTime;
				}
				
				if (Input.GetKey(KeyCode.W) ){
					pow-=Time.fixedDeltaTime;
				}
				pow=Mathf.Clamp(pow,-1,1);
//				roll=CrossPlatformInputManager.GetAxis("Horizontal");
//				pitch= CrossPlatformInputManager.GetAxis("Vertical");
				PlayerController.Instance().powBar.fillAmount=(pow+1)*0.5f;
			}

            // auto throttle up, or down if braking.
//			Debug.Log(GameInputController.Instance().GetDevice());
			if (GameInputController.Instance().GetDevice()!=null ){
				airBrakes=false;
				throttle=-GameInputController.Instance().GetAxis("Analog2");

			}
			else{
				airBrakes=Input.GetKey(KeyCode.LeftShift);
				throttle= airBrakes ? -1 : pow;
			}

			
//			Debug.Log(throttle);
#if MOBILE_INPUT
            AdjustInputForMobileControls(ref roll, ref pitch, ref throttle);
#endif
            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, 0, throttle, airBrakes);
        }


        private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        {
            // because mobile tilt is used for roll and pitch, we help out by
            // assuming that a centered level device means the user
            // wants to fly straight and level!

            // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
            // and the roll input is calculated to achieve that.
            // whereas on non-mobile, the input directly controls the roll of the aeroplane.

            float intendedRollAngle = roll*maxRollAngle*Mathf.Deg2Rad;
            float intendedPitchAngle = pitch*maxPitchAngle*Mathf.Deg2Rad;
            roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
            pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

            // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
            float intendedThrottle = throttle*0.5f + 0.5f;
            throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        }
    }
}
