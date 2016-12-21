using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using startScreen;



public class startScreenRightController : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_TrackedController device;
    private int indexAudioList;

    private int audioListLength = startScreen.startScreenChooseMelody.startSphereMelodyList.Length;
    public SteamVR_Controller.Device controller;
    //private Valve.VR.EVRButtonId triggerButton;
    private Valve.VR.EVRButtonId touchPad;
    //Collider col;
    // Use this for initialization
    void Start()
    {
        //col = GetComponent<Collider>();
        indexAudioList = 0;
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        controller = SteamVR_Controller.Input((int)trackedObject.index);
        //triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;
        device = GetComponent<SteamVR_TrackedController>();
        device.TriggerClicked += TriggerClicked;
        device.PadClicked += PadClicked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TriggerClicked(object sender, ClickedEventArgs e)
    {
        // Save Player Input in PlayerPrefs (the melody)
        /*if (col.tag == "rightController")
        {
            PlayerPrefs.SetInt("currentMelody", indexAudioList);
            EditorSceneManager.LoadScene("Assets/Scene/musicObjects.unity");
        }*/
        //PlayerPrefs.SetInt("currentMelody", indexAudioList);
        //EditorSceneManager.LoadScene("Assets/Scene/musicObjects.unity");

    }
    
    void OnTriggerEnter(Collider col)
    {
        if(controller.GetPress(SteamVR_Controller.ButtonMask.Trigger) == true)
        {
            PlayerPrefs.SetInt("currentMelody", indexAudioList);
            EditorSceneManager.LoadScene("Assets/Scene/musicObjects.unity");
        }
    }



    void PadClicked(object sender, ClickedEventArgs e)

    {

        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))

        {

            if (controller.GetAxis(touchPad).x > 0.5f) //right
            {
                indexAudioList++;
                if(indexAudioList == audioListLength)
                {
                    indexAudioList = 0;
                }
                GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadRight");
            }

            if (controller.GetAxis(touchPad).x < -0.5f) //left
            {
                indexAudioList--;
                if (indexAudioList < 0)
                {
                    indexAudioList = audioListLength -1;
                }
                GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadLeft");
            }

            
        }
    }
}