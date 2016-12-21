using UnityEngine;
using System.Collections;


public class leftController : MonoBehaviour
{
    private SteamVR_Controller.Device controller;
    private Valve.VR.EVRButtonId touchPad;
    private SteamVR_TrackedObject trackedObject;

    // Use this for initialization
    void Start ()
    {

        // Lokal
        touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
        trackedObject = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void Update()
    {
        controller = SteamVR_Controller.Input((int)trackedObject.index);

        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (movePointSensorNamespace.movePointSensor.speed >= 3f || movePointSensorNamespace.movePointSensor.speed <= -3f)
            {
                //Debug.Log("speed nicht ok");

            }
            if (controller.GetAxis(touchPad).y <= -0.5f && movePointSensorNamespace.movePointSensor.speed >= -4f)
            {
                movePointSensorNamespace.movePointSensor.speed -= 0.1f;
                //Debug.Log(movePointSensorNamespace.movePointSensor.speed);
            }

            if (controller.GetAxis(touchPad).y >= 0.5f && movePointSensorNamespace.movePointSensor.speed <= 4f)
            {
                movePointSensorNamespace.movePointSensor.speed += 0.1f;

            }

            if (controller.GetAxis(touchPad).y < 0.5f && controller.GetAxis(touchPad).y > -0.5f)
            {
                movePointSensorNamespace.movePointSensor.speed = 0;
            }
        }
    }
}
