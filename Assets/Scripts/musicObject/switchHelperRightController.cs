using main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace helper
{
    public class switchHelperRightController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void leftSwitcherIfSwipe()
        {
            GameObject.FindWithTag("mainRightController").GetComponent<rightController>().addIndexAudioList();
            if (GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getIndexAudioList() == GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getAudioListLength())
            {
                GameObject.FindWithTag("mainRightController").GetComponent<rightController>().setIndexAudioList(0);
            }

            // Error: NullReferenceException: Object reference not set to an instance of an object
            GameObject.Find("invisSphere").transform.position = GameObject.Find("SphereRot0").transform.position;

            for (int i = 0; i < GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getAudioListLength(); i++)
            {
                if (i == GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getAudioListLength() - 1)
                {
                    GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("invisSphere").transform.position;

                }
                else
                {
                    int k = i + 1;
                    GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("SphereRot" + k).transform.position;
                }
            }
            GameObject.FindWithTag("mainRightController").GetComponent<rightController>().changeColorControllerSphere();
        }

        public void rightSwitcherIfSwipe()
        {
            GameObject.FindWithTag("mainRightController").GetComponent<rightController>().subIndexAudioList();
            if (GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getIndexAudioList() < 0)
            {
                GameObject.FindWithTag("mainRightController").GetComponent<rightController>().setIndexAudioList(GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getAudioListLength() - 1);
            }

            GameObject.Find("invisSphere").transform.position = GameObject.Find("SphereRot6").transform.position;

            for (int i = GameObject.FindWithTag("mainRightController").GetComponent<rightController>().getAudioListLength() - 1; i > -1; i--)
            {
                if (i == 0)
                {
                    GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("invisSphere").transform.position;
                }
                else
                {
                    int k = i - 1;
                    GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("SphereRot" + k).transform.position;
                }
            }
            GameObject.FindWithTag("mainRightController").GetComponent<rightController>().changeColorControllerSphere();
        }

    }
}