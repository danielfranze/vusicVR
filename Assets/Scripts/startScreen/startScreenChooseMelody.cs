using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace startScreen
{
    public class startScreenChooseMelody : MonoBehaviour
    {

        public static AudioClip[] startSphereMelodyList = new AudioClip[3];
        private Material[] startSphereColorList = new Material[3];
        private GameObject startSphere;
        public int startSphereIndex = 0;
        // Use this for initialization
        void Start()
        {
            startSphereMelodyList[0] = Resources.Load("Melodie3_House2") as AudioClip;
            startSphereMelodyList[1] = Resources.Load("Melodie2_House1") as AudioClip;
            startSphereMelodyList[2] = Resources.Load("Melodie5_düster") as AudioClip;

            startSphereColorList[0] = Resources.Load("1pink") as Material;
            startSphereColorList[1] = Resources.Load("2hellblau") as Material;
            startSphereColorList[2] = Resources.Load("2gelbgrün") as Material;
            startSphere = GameObject.Find("logo");

            startSphere.GetComponent<MeshRenderer>().material = startSphereColorList[startSphereIndex];
            startSphere.AddComponent<AudioSource>();
            startSphere.GetComponent<AudioSource>().clip = startSphereMelodyList[startSphereIndex];
            startSphere.GetComponents<AudioSource>()[0].Play();
        }

        // Update is called once per frame
        void Update()
        {
            if (!startSphere.GetComponent<AudioSource>().isPlaying)
            {
                changeColorAndSoundRightSide();
            }

        }


        public void changeAudio(string padInput)
        {

            if (padInput == "touchPadRight")
            {
                changeColorAndSoundRightSide();
            }
            if (padInput == "touchPadLeft")
            {
                changeColorAndSoundLeftSide();
            }
        }

        private void changeColorAndSoundRightSide()
        {
            startSphereIndex++;
            if (startSphereIndex == startSphereMelodyList.Length)
            {
                startSphereIndex = 0;

            }
            startSphere.GetComponent<AudioSource>().clip = startSphereMelodyList[startSphereIndex];
            startSphere.GetComponent<MeshRenderer>().material = startSphereColorList[startSphereIndex];
            startSphere.GetComponents<AudioSource>()[0].Play();

        }
        private void changeColorAndSoundLeftSide()
        {
            startSphereIndex--;
            if (startSphereIndex < 0)
            {
                startSphereIndex = 2;

            }
            startSphere.GetComponent<AudioSource>().clip = startSphereMelodyList[startSphereIndex];
            startSphere.GetComponent<MeshRenderer>().material = startSphereColorList[startSphereIndex];
            startSphere.GetComponents<AudioSource>()[0].Play();
        }


    }

}