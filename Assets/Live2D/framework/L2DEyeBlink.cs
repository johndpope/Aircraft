/**
 *
 *  You can modify and use this source freely
 *  only for the development of application related Live2D.
 *
 *  (c) Live2D Inc. All rights reserved.
 */
using System.Collections;
using live2d;

namespace live2d.framework
{
    

    
    enum EYE_STATE
    {
        STATE_FIRST,
        STATE_INTERVAL,
        STATE_CLOSING,
        STATE_CLOSED,
        STATE_OPENING,
    }
    public class L2DEyeBlink
    {
        
        long nextBlinkTime;
        long stateStartTime;

        EYE_STATE eyeState;

        bool closeIfZero;

        string eyeID_L;
        string eyeID_R;
        
        int blinkIntervalMsec;

        int closingMotionMsec;
        int closedMotionMsec;
        int openingMotionMsec;


        public L2DEyeBlink()
        {
            eyeState = EYE_STATE.STATE_FIRST;

            blinkIntervalMsec = 4000;

            closingMotionMsec = 100;
            closedMotionMsec = 50;
            openingMotionMsec = 150;

            closeIfZero = true;

            eyeID_L = "PARAM_EYE_L_OPEN";
            eyeID_R = "PARAM_EYE_R_OPEN";
        }


        
        public long calcNextBlink()
        {
            long time = UtSystem.getUserTimeMSec();
            double r = UtMath.randDouble();//0..1
            return (long)(time + r * (2 * blinkIntervalMsec - 1));
        }


        public void setInterval(int blinkIntervalMsec)
        {
            this.blinkIntervalMsec = blinkIntervalMsec;
        }


        public void setEyeMotion(int closingMotionMsec, int closedMotionMsec, int openingMotionMsec)
        {
            this.closingMotionMsec = closingMotionMsec;
            this.closedMotionMsec = closedMotionMsec;
            this.openingMotionMsec = openingMotionMsec;
        }


        
        public void updateParam(ALive2DModel model)
        {
            long time = UtSystem.getUserTimeMSec();
            float eyeParamValue;
            float t = 0;

            switch (this.eyeState)
            {
                case EYE_STATE.STATE_CLOSING:
                    
                    t = (time - stateStartTime) / (float)closingMotionMsec;
                    if (t >= 1)
                    {
                        t = 1;
                        this.eyeState = EYE_STATE.STATE_CLOSED;
                        this.stateStartTime = time;
                    }
                    eyeParamValue = 1 - t;
                    break;
                case EYE_STATE.STATE_CLOSED:
                    t = (time - stateStartTime) / (float)closedMotionMsec;
                    if (t >= 1)
                    {
                        this.eyeState = EYE_STATE.STATE_OPENING;
                        this.stateStartTime = time;
                    }
                    eyeParamValue = 0;
                    break;
                case EYE_STATE.STATE_OPENING:
                    t = (time - stateStartTime) / (float)openingMotionMsec;
                    if (t >= 1)
                    {
                        t = 1;
                        this.eyeState = EYE_STATE.STATE_INTERVAL;
                        this.nextBlinkTime = calcNextBlink();
                    }
                    eyeParamValue = t;
                    break;
                case EYE_STATE.STATE_INTERVAL:
                    //
                    if (this.nextBlinkTime < time)
                    {
                        this.eyeState = EYE_STATE.STATE_CLOSING;
                        this.stateStartTime = time;
                    }
                    eyeParamValue = 1;
                    break;
                case EYE_STATE.STATE_FIRST:
                default:
                    this.eyeState = EYE_STATE.STATE_INTERVAL;
                    this.nextBlinkTime = calcNextBlink();
                    eyeParamValue = 1;
                    break;
            }

            if (!closeIfZero) eyeParamValue = -eyeParamValue;

            
            model.setParamFloat(eyeID_L, eyeParamValue);
            model.setParamFloat(eyeID_R, eyeParamValue);
        }
    }
}