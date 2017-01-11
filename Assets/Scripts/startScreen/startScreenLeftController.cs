using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using startScreen;


namespace startScreen
{
    public class startScreenLeftController : MonoBehaviour
    {
        private SteamVR_TrackedObject trackedObject;
        private SteamVR_TrackedController device;

        private int indexAudioList;
        private int audioListLength;


        public void rotIndexAudioList()
        {
            indexAudioList++;
            if (indexAudioList >= audioListLength)
            {
                indexAudioList = 0;
            }
        }

        //GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadRight");


        public SteamVR_Controller.Device controller;
        //private Valve.VR.EVRButtonId triggerButton;
        private Valve.VR.EVRButtonId touchPad;
        //Collider col;
        // Use this for initialization
        void Start()
        {
            audioListLength = GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getStartSphereMelodyListLength();
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
            if (controller.GetPress(SteamVR_Controller.ButtonMask.Trigger) == true)
            {
                PlayerPrefs.SetInt("currentMelody", GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList());
                EditorSceneManager.LoadScene("Assets/Scene/musicObjects.unity");
            }
        }

        void OnTriggerStay(Collider col)
        {
            if (controller.GetPress(SteamVR_Controller.ButtonMask.Trigger) == true)
            {
                PlayerPrefs.SetInt("currentMelody", GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList());
                EditorSceneManager.LoadScene("Assets/Scene/musicObjects.unity");
            }
        }

        void PadClicked(object sender, ClickedEventArgs e)
        {

            if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))

            {

                if (controller.GetAxis(touchPad).x > 0.5f) //right
                {
                    GameObject.Find("logo").GetComponent<startScreenChooseMelody>().addIndexAudioList();

                    if (GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList() == GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getAudioListLength())
                    {
                        GameObject.Find("logo").GetComponent<startScreenChooseMelody>().setIndexAudioList(0);
                    }
                    GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadRight");
                }

                if (controller.GetAxis(touchPad).x < -0.5f) //left
                {
                    GameObject.Find("logo").GetComponent<startScreenChooseMelody>().subIndexAudioList();

                    if (GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList() < 0)
                    {
                        GameObject.Find("logo").GetComponent<startScreenChooseMelody>().setIndexAudioList(GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getAudioListLength() - 1);
                    }
                    GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadLeft");
                }


            }
        }

        public static void rightSwitcher()
        {
            GameObject.Find("logo").GetComponent<startScreenChooseMelody>().addIndexAudioList();

            if (GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList() == GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getAudioListLength())
            {
                GameObject.Find("logo").GetComponent<startScreenChooseMelody>().setIndexAudioList(0);
            }
            GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadRight");
        }

        public static void leftSwitcher()
        {
            GameObject.Find("logo").GetComponent<startScreenChooseMelody>().subIndexAudioList();

            if (GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getIndexAudioList() < 0)
            {
                GameObject.Find("logo").GetComponent<startScreenChooseMelody>().setIndexAudioList(GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getAudioListLength() - 1);
            }
            GameObject.Find("logo").GetComponent<startScreenChooseMelody>().changeAudio("touchPadLeft");
        }


    }
}