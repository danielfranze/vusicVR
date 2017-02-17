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
        //GameObject.FindWithTag("mainRightController").SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        controller = SteamVR_Controller.Input((int)trackedObject.index);

        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {

            /*if (GameObject.Find("Trigger").GetComponent<movePointSensor>().getSpeed() >= 3f || GameObject.Find("Trigger").GetComponent<movePointSensor>().getSpeed() <= -3f)
            {
                //Debug.Log("speed nicht ok");

            }*/
            if (controller.GetAxis(touchPad).x <= -0.75f && GameObject.Find("Trigger").GetComponent<movePointSensor>().getSpeed() >= 1.0f) //left langsamer
            {
                GameObject.Find("Trigger").GetComponent<movePointSensor>().subSpeed(0.0175f);
            }

            if (controller.GetAxis(touchPad).x >= 0.75f && GameObject.Find("Trigger").GetComponent<movePointSensor>().getSpeed() <= 3.5f) //right schneller 
            {
                GameObject.Find("Trigger").GetComponent<movePointSensor>().addSpeed(0.0175f);
            }

            if (controller.GetAxis(touchPad).y >= 0.75f) //up starten
            {
                GameObject.Find("Trigger").GetComponent<movePointSensor>().setSpeed(2.5f);
            }

            if (controller.GetAxis(touchPad).y <= -0.75f) // down stopp
            {
                GameObject.Find("Trigger").GetComponent<movePointSensor>().setSpeed(0);
            }
        }
    }
}
