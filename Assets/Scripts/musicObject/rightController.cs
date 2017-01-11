using UnityEngine;
using System.Collections;

namespace main
{
    public class rightController : MonoBehaviour
    {

        private SteamVR_TrackedObject trackedObject;
        public static SteamVR_Controller.Device controller;

        //event
        public SteamVR_TrackedController device;

        private Valve.VR.EVRButtonId triggerButton;
        private Valve.VR.EVRButtonId touchPad;

        private GameObject actorSphere;
        //private bool collision = false;
        private int currentColorCircle = 0;

        private Material[] colorList;
        private Material[] colorList1 = new Material[7];
        private Material[] colorList2 = new Material[7];

        private AudioClip[] audioList = new AudioClip[7];
        private AudioClip[] audioList1 = new AudioClip[7];
        private AudioClip[] audioList2 = new AudioClip[7];

        public GameObject colorCircle;
        public GameObject colorCircle1;
        public GameObject colorCircle2;

        private int indexAudioList = 0;
        private int indexAudioList1 = 0;
        private int indexAudioList2 = 0;

        private int possibilityCounter = 0;

        public GameObject[] possibilityList = new GameObject[3];
        public GameObject sphereDestroyer;  
        public GameObject controllerSphere;

        public static bool trigger = false;

        //private Collider col;
        //private SphereCollider sphereCollider;

        //Use this for initialization
        void Start()
        {
            // Lokal
            trackedObject = GetComponent<SteamVR_TrackedObject>();


            // Global
            controller = SteamVR_Controller.Input((int)trackedObject.index);
            // Global // event
            device = GetComponent<SteamVR_TrackedController>();
            device.PadClicked += PadClicked;


            // Lokal
            triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
            touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

            audioList1[0] = Resources.Load("R_Kick") as AudioClip;
            audioList1[1] = Resources.Load("HiHatOpen909") as AudioClip;
            audioList1[2] = Resources.Load("TomHi909") as AudioClip;
            audioList1[3] = Resources.Load("TomMid909") as AudioClip;
            audioList1[4] = Resources.Load("Rim909") as AudioClip;
            audioList1[5] = Resources.Load("Clap909") as AudioClip;
            audioList1[6] = Resources.Load("Kick909_2") as AudioClip;

            audioList2[0] = Resources.Load("Horn2") as AudioClip;
            audioList2[1] = Resources.Load("3_D#3") as AudioClip;
            audioList2[2] = Resources.Load("4_F") as AudioClip;
            audioList2[3] = Resources.Load("5_G3") as AudioClip;
            audioList2[4] = Resources.Load("6_As") as AudioClip;
            audioList2[5] = Resources.Load("7_B") as AudioClip;
            audioList2[6] = Resources.Load("8_C4") as AudioClip;

            colorList1[0] = Resources.Load("1lila") as Material;
            colorList1[1] = Resources.Load("1rot") as Material;
            colorList1[2] = Resources.Load("1rosa") as Material;
            colorList1[3] = Resources.Load("1pink") as Material;
            colorList1[4] = Resources.Load("1orangegelb") as Material;
            colorList1[5] = Resources.Load("1orange") as Material;
            colorList1[6] = Resources.Load("1lilapink") as Material;

            colorList2[0] = Resources.Load("2blau") as Material;
            colorList2[1] = Resources.Load("2türkies") as Material;
            colorList2[2] = Resources.Load("2hellgelb") as Material;
            colorList2[3] = Resources.Load("2hellblau") as Material;
            colorList2[4] = Resources.Load("2grün") as Material;
            colorList2[5] = Resources.Load("2gelbgrün") as Material;
            colorList2[6] = Resources.Load("2gelb") as Material;


            // Global
            sphereDestroyer = GameObject.Find("sphereDestroyer");
            controllerSphere = GameObject.Find("controllerSphere");
            colorCircle1 = GameObject.Find("colorCircle1");
            colorCircle2 = GameObject.Find("colorCircle2");

            possibilityList[0] = colorCircle1;
            possibilityList[1] = colorCircle2;
            possibilityList[2] = sphereDestroyer;
            
            colorCircle = colorCircle1;
            colorList = colorList1;
            audioList = audioList2;

            colorCircle1.SetActive(true);
            controllerSphere.SetActive(true);
   
            GameObject.Find("controllerSphere").GetComponent<MeshRenderer>().material = colorList[indexAudioList];

            sphereDestroyer.SetActive(false);
            colorCircle2.SetActive(false);

        }

        //Update is called once per frame
        void Update()
        {
            //var trackedObject = GetComponentInParent<SteamVR_TrackedObject>();


            // Bug Fix Destroyer
            if (controller.GetPress(triggerButton))
            {
                trigger = true;
            }
            else
            {
                trigger = false;
            }
            //GameObject.Find("logo").GetComponent<startScreenChooseMelody>().getStartSphereMelodyListLength();
            //controllerSphere

            //GameObject.Find("controllerSphere").GetComponent<createObjectIfPossible>().getCollision()

            

            if (controller.GetPress(triggerButton) && !(GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().getCollision()) && GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().getSphereOnGrid())
            {
                controller.TriggerHapticPulse(1000);
                
                createSphere();
                GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().setSphereCreater(false);
                
            }


        }


        void createSphere()
        {
            if(currentColorCircle == 0)
            {
                actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                actorSphere.GetComponent<SphereCollider>().radius = 1f;
                actorSphere.GetComponent<SphereCollider>().isTrigger = true;
            } else
            {
                actorSphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                actorSphere.gameObject.transform.Rotate(new Vector3(0, 0, 0));
                actorSphere.GetComponent<BoxCollider>();
                actorSphere.GetComponent<BoxCollider>().isTrigger = true;
            }
            
            //Debug.Log(audioList[0]);
            //actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            actorSphere.gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            actorSphere.transform.position = new Vector3(GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().getTransformPosition(0), 
                                                         GameObject.FindGameObjectWithTag("ControllerSphere").transform.position[1],
                                                         GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().getTransformPosition(2));

            actorSphere.AddComponent<Rigidbody>();
            actorSphere.GetComponent<Rigidbody>().useGravity = false;
            actorSphere.GetComponent<Rigidbody>().isKinematic = true;
            actorSphere.name = "Sound" + indexAudioList + currentColorCircle; 
            actorSphere.tag = "musicSphere";
            actorSphere.AddComponent<AudioSource>();
            actorSphere.GetComponent<AudioSource>().clip = audioList[indexAudioList];

            actorSphere.AddComponent<playMusic>();
            actorSphere.GetComponent<MeshRenderer>().material = colorList[indexAudioList];
            actorSphere.GetComponents<AudioSource>()[0].Play();
        }


        void switchCircle()
        {
            if (GameObject.Find("colorCircle1"))
            {
                currentColorCircle = 0;
                colorCircle = colorCircle1;
                colorList = colorList1;
                audioList = audioList1;
                indexAudioList = indexAudioList1;

            }
            if (GameObject.Find("colorCircle2"))
            {
                currentColorCircle = 1;
                colorCircle = colorCircle2;
                colorList = colorList2;
                audioList = audioList2;
                indexAudioList = indexAudioList2;
            }
        }


        void saveCircle()
        {
            if (GameObject.Find("colorCircle1"))
            {
                colorCircle1 = colorCircle;
                colorList1 = colorList;
                indexAudioList1 = indexAudioList;

            }
            if (GameObject.Find("colorCircle2"))
            {
                colorCircle2 = colorCircle;
                colorList2 = colorList;
                indexAudioList2 = indexAudioList;
            }
        }


        void PadClicked(object sender, ClickedEventArgs e)

        {

                if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
                {

                    if (controller.GetAxis(touchPad).x > 0.5f && (sphereDestroyer.gameObject.activeSelf == false)) //right
                    {
                        indexAudioList++;
                        if (indexAudioList == audioList.Length)
                        {
                            indexAudioList = 0;
                        }

                        // Error: NullReferenceException: Object reference not set to an instance of an object
                        GameObject.Find("invisSphere").transform.position = GameObject.Find("SphereRot0").transform.position;

                        for (int i = 0; i < audioList.Length; i++)
                        {
                            if (i == audioList.Length - 1)
                            {
                                GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("invisSphere").transform.position;
                            }
                            else
                            {
                                int k = i + 1;
                                GameObject.Find("SphereRot" + i).transform.position = GameObject.Find("SphereRot" + k).transform.position;
                            }
                        }
                    }

                    if (controller.GetAxis(touchPad).x < -0.5f && (sphereDestroyer.gameObject.activeSelf == false)) //left
                    {
                        indexAudioList--;
                        if (indexAudioList < 0)
                        {
                            indexAudioList = audioList.Length - 1;
                        }

                        GameObject.Find("invisSphere").transform.position = GameObject.Find("SphereRot6").transform.position;

                        for (int i = audioList.Length - 1; i > -1; i--)
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
                    }


                    if (controller.GetAxis(touchPad).y > 0.5f) //up 
                    {
                        saveCircle();

                        possibilityCounter++;

                        if (possibilityCounter == possibilityList.Length)
                        {
                            possibilityCounter = 0;
                        }

                        if (possibilityCounter == 0)
                        {
                            controllerSphere.GetComponent<SphereCollider>().enabled = true;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityList.Length - 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }
                        if (possibilityCounter == 1)
                        {
                            controllerSphere.GetComponent<SphereCollider>().enabled = true;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter - 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }

                        if (possibilityCounter == 2)
                        {
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                            //createSphereIfPossible.createObjectIfPossible.collision = false;
                            controllerSphere.GetComponent<SphereCollider>().enabled = false;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = false;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter - 1].SetActive(false);
                        }
                        switchCircle();

                    }



                    if (controller.GetAxis(touchPad).y < -0.5f) //down
                    {
                        saveCircle();

                        possibilityCounter--;

                        if (possibilityCounter < 0)
                        {
                            possibilityCounter = possibilityList.Length - 1;
                        }

                        if (possibilityCounter == 0)
                        {
                            controllerSphere.GetComponent<SphereCollider>().enabled = true;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter + 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }
                        if (possibilityCounter == 1)
                        {
                            controllerSphere.GetComponent<SphereCollider>().enabled = true;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter + 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }

                        if (possibilityCounter == 2)
                        {
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                            // createSphereIfPossible.createObjectIfPossible.collision = false;
                            controllerSphere.GetComponent<SphereCollider>().enabled = false;
                            controllerSphere.GetComponent<MeshRenderer>().enabled = false;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[0].SetActive(false);
                        }
                        switchCircle();
                    }
                }

                GameObject.Find("controllerSphere").GetComponent<MeshRenderer>().material = colorList[indexAudioList];

            

        }



    }
}