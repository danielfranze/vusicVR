using UnityEngine;
using System.Collections;
using System.Linq;

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

        private AudioClip[][] audioList = new AudioClip[7][];
        private AudioClip[][] audioList1 = new AudioClip[7][];
        private AudioClip[][] audioList2 = new AudioClip[7][];

        public GameObject colorCircle;
        public GameObject colorCircle1;
        public GameObject colorCircle2;
        public static GameObject currentController;

        private int indexAudioList = 0;
        private int indexAudioList1 = 0;
        private int indexAudioList2 = 0;
        private int toneList = 0;

        private int possibilityCounter = 0;

        public GameObject[] possibilityList = new GameObject[3];
        public GameObject sphereDestroyer;
        public GameObject controllerSphere;
        public GameObject controllerCube;


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

            audioList[0] = new AudioClip[8];
            audioList[1] = new AudioClip[8];
            audioList[2] = new AudioClip[8];
            audioList[3] = new AudioClip[8];
            audioList[4] = new AudioClip[8];
            audioList[5] = new AudioClip[8];
            audioList[6] = new AudioClip[8];

            audioList1[0] = new AudioClip[8];
            audioList1[1] = new AudioClip[8];
            audioList1[2] = new AudioClip[8];
            audioList1[3] = new AudioClip[8];
            audioList1[4] = new AudioClip[8];
            audioList1[5] = new AudioClip[8];
            audioList1[6] = new AudioClip[8];

            audioList2[0] = new AudioClip[8];
            audioList2[1] = new AudioClip[8];
            audioList2[2] = new AudioClip[8];
            audioList2[3] = new AudioClip[8];
            audioList2[4] = new AudioClip[8];
            audioList2[5] = new AudioClip[8];
            audioList2[6] = new AudioClip[8];

            audioList1[0][0] = Resources.Load("aTechNote1") as AudioClip;
            audioList1[0][1] = Resources.Load("aTechNote2") as AudioClip;
            audioList1[0][2] = Resources.Load("aTechNote3") as AudioClip;
            audioList1[0][3] = Resources.Load("aTechNote4") as AudioClip;
            audioList1[0][4] = Resources.Load("aTechNote5") as AudioClip;
            audioList1[0][5] = Resources.Load("aTechNote7") as AudioClip;
            audioList1[0][6] = Resources.Load("aTechNote6") as AudioClip;
            audioList1[0][7] = Resources.Load("aTechNote8") as AudioClip;
  

            audioList1[1][0] = Resources.Load("gTechNote1") as AudioClip;
            audioList1[1][1] = Resources.Load("gTechNote2") as AudioClip;
            audioList1[1][2] = Resources.Load("gTechNote3") as AudioClip;
            audioList1[1][3] = Resources.Load("gTechNote4") as AudioClip;
            audioList1[1][4] = Resources.Load("gTechNote5") as AudioClip;
            audioList1[1][5] = Resources.Load("gTechNote6") as AudioClip;
            audioList1[1][6] = Resources.Load("gTechNote7") as AudioClip;
            audioList1[1][7] = Resources.Load("gTechNote8") as AudioClip;

            audioList1[2][0] = Resources.Load("cBassnote1") as AudioClip;
            audioList1[2][1] = Resources.Load("cBassnote2") as AudioClip;
            audioList1[2][2] = Resources.Load("cBassnote3") as AudioClip;
            audioList1[2][3] = Resources.Load("cBassnote4") as AudioClip;
            audioList1[2][4] = Resources.Load("cBassnote5") as AudioClip;
            audioList1[2][5] = Resources.Load("cBassnote6") as AudioClip;
            audioList1[2][6] = Resources.Load("cBassnote7") as AudioClip;
            audioList1[2][7] = Resources.Load("cBassnote8") as AudioClip;

            audioList1[3][0] = Resources.Load("dHighnote1") as AudioClip;
            audioList1[3][1] = Resources.Load("dHighnote2") as AudioClip;
            audioList1[3][2] = Resources.Load("dHighnote3") as AudioClip;
            audioList1[3][3] = Resources.Load("dHighnote4") as AudioClip;
            audioList1[3][4] = Resources.Load("dHighnote5") as AudioClip;
            audioList1[3][5] = Resources.Load("dHighnote6") as AudioClip;
            audioList1[3][6] = Resources.Load("dHighnote7") as AudioClip;
            audioList1[3][7] = Resources.Load("dHighnote8") as AudioClip;

            audioList1[4][0] = Resources.Load("eHighnote1") as AudioClip;
            audioList1[4][1] = Resources.Load("eHighnote2") as AudioClip;
            audioList1[4][2] = Resources.Load("eHighnote3") as AudioClip;
            audioList1[4][3] = Resources.Load("eHighnote4") as AudioClip;
            audioList1[4][4] = Resources.Load("eHighnote5") as AudioClip;
            audioList1[4][5] = Resources.Load("eHighnote6") as AudioClip;
            audioList1[4][6] = Resources.Load("eHighnote7") as AudioClip;
            audioList1[4][7] = Resources.Load("eHighnote8") as AudioClip;

            audioList1[5][0] = Resources.Load("bTechNote1") as AudioClip;
            audioList1[5][1] = Resources.Load("bTechNote2") as AudioClip;
            audioList1[5][2] = Resources.Load("bTechNote3") as AudioClip;
            audioList1[5][3] = Resources.Load("bTechNote4") as AudioClip;
            audioList1[5][4] = Resources.Load("bTechNote5") as AudioClip;
            audioList1[5][5] = Resources.Load("bTechNote6") as AudioClip;
            audioList1[5][6] = Resources.Load("bTechNote7") as AudioClip;
            audioList1[5][7] = Resources.Load("bTechNote8") as AudioClip; 

            audioList1[6][0] = Resources.Load("TechNote1") as AudioClip;
            audioList1[6][1] = Resources.Load("TechNote2") as AudioClip;
            audioList1[6][2] = Resources.Load("TechNote3") as AudioClip;
            audioList1[6][3] = Resources.Load("TechNote4") as AudioClip;
            audioList1[6][4] = Resources.Load("TechNote5") as AudioClip;
            audioList1[6][5] = Resources.Load("TechNote6") as AudioClip;
            audioList1[6][6] = Resources.Load("TechNote7") as AudioClip;
            audioList1[6][7] = Resources.Load("TechNote8") as AudioClip;

            audioList2[0][0] = Resources.Load("Kick909") as AudioClip;
            audioList2[1][0] = Resources.Load("Snare909") as AudioClip;
            audioList2[2][0] = Resources.Load("Rim909") as AudioClip;
            audioList2[3][0] = Resources.Load("TomLow909") as AudioClip;
            audioList2[4][0] = Resources.Load("Crash909") as AudioClip;
            audioList2[5][0] = Resources.Load("HiHatClosed909") as AudioClip;
            audioList2[6][0] = Resources.Load("HiHatOpen909") as AudioClip;

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
            colorCircle1 = GameObject.Find("colorCircle1");
            colorCircle2 = GameObject.Find("colorCircle2");
            controllerSphere = GameObject.Find("controllerSphere");
            controllerCube = GameObject.Find("controllerCube");

            possibilityList[0] = colorCircle1;
            possibilityList[1] = colorCircle2;
            possibilityList[2] = sphereDestroyer;
            
            colorCircle = colorCircle1;
            colorList = colorList1;
            audioList = audioList1;
            currentController = controllerSphere;

            colorCircle1.SetActive(true);
            currentController.SetActive(true);
            currentController.GetComponent<MeshRenderer>().material = colorList[indexAudioList];
            //GameObject.Find("controllerCube").GetComponent<MeshRenderer>().material = colorList[indexAudioList];
            controllerCube.SetActive(false);
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

            

            if (controller.GetPress(triggerButton) && !(currentController.GetComponent<sphereIsOnGrid>().getCollision()) && currentController.GetComponent<sphereIsOnGrid>().getSphereOnGrid())
            {
                controller.TriggerHapticPulse(1000);
                
                createSphere();
                currentController.GetComponent<sphereIsOnGrid>().setSphereCreater(false);
                
            }


        }

        public int getPossibilityCounter()
        {
            return possibilityCounter;
        }

        void createSphere()
        {
            if (currentColorCircle == 0)
            {
                if (currentController.transform.position[1] < 3.48f)
                {
                    actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    actorSphere.GetComponent<SphereCollider>().radius = 1f;
                    actorSphere.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    actorSphere.GetComponent<SphereCollider>().isTrigger = true;


                    actorSphere.transform.position = new Vector3(currentController.GetComponent<sphereIsOnGrid>().getTransformPosition(0),
                                                         currentController.transform.position[1],
                                                         currentController.GetComponent<sphereIsOnGrid>().getTransformPosition(2));
                    actorSphere.AddComponent<AudioSource>();
                    Debug.Log("Tonhöhe: " + currentController.GetComponent<sphereIsOnGrid>().getFieldTag());
                    actorSphere.GetComponent<AudioSource>().clip = audioList[indexAudioList][currentController.GetComponent<sphereIsOnGrid>().getFieldTag()];
                } else
                {
                    return;
                }
            } else
            {
                if (currentController.transform.position[1] > 3.5f)
                {
                    actorSphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    actorSphere.gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
                    actorSphere.gameObject.transform.Rotate(new Vector3(0, 0, 0));
                    actorSphere.GetComponent<BoxCollider>().size = new Vector3(2f, 2f, 2f);
                    actorSphere.GetComponent<BoxCollider>().isTrigger = true;

                    actorSphere.transform.position = new Vector3(currentController.transform.position[0],
                                                        currentController.GetComponent<sphereIsOnGrid>().getTransformPosition(1),
                                                        currentController.transform.position[2]);
                    actorSphere.AddComponent<AudioSource>();
                    actorSphere.GetComponent<AudioSource>().clip = audioList[indexAudioList][0];


                }
                else
                {
                    return;
            }
        }
            
            //Debug.Log(audioList[0]);
            //actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            

            actorSphere.AddComponent<Rigidbody>();
            actorSphere.GetComponent<Rigidbody>().useGravity = false;
            actorSphere.GetComponent<Rigidbody>().isKinematic = true;
            actorSphere.name = "Sound" + indexAudioList + currentColorCircle; 
            actorSphere.tag = "musicSphere";
            

            //actorSphere.AddComponent<playMusic>();
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

        public void addIndexAudioList() {
            indexAudioList++;
        }
        public void subIndexAudioList()
        {
            indexAudioList--;
        }
        public int getIndexAudioList()
        {
            return indexAudioList;
        }
        public int getAudioListLength()
        {
            return audioList.Length;
        }
        public void setIndexAudioList(int value)
        {
            indexAudioList = value;
        }
        public void changeColorControllerSphere()
        {
            currentController.GetComponent<MeshRenderer>().material = colorList[indexAudioList];
        }


        private IEnumerator SetBodyAndHeadActiveAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            }
        }

        private IEnumerator SetHeadActiveAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("nicht aktiv_Querstangen") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            }
        }

        private IEnumerator SetBodyActiveAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("nicht aktiv_Querstangen") as Material;
            }
        }

        void setHeadActive()
        {
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("nicht aktiv_Querstangen") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                var numberOfSeconds = 0.07f;
                StartCoroutine(SetHeadActiveAfter(numberOfSeconds));
            }

        }

       void setBodyActive()
        {
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("nicht aktiv_Querstangen") as Material;
            }
            var numberOfSeconds = 0.07f;
            StartCoroutine(SetBodyActiveAfter(numberOfSeconds));
        }

        void setBodyAndHeadActive()
        {
            foreach (int index in Enumerable.Range(0, 32))
            {
                GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            }
            var numberOfSeconds = 0.07f;
            StartCoroutine(SetBodyAndHeadActiveAfter(numberOfSeconds));
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
                    GameObject.Find("invisSphere").transform.position = GameObject.Find("SphereRot0").transform.position;
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
                            setBodyActive();
                            currentController = controllerSphere;
                            controllerCube.SetActive(false);
                            controllerSphere.SetActive(true);
                            currentController.GetComponent<SphereCollider>().enabled = true;
                            currentController.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityList.Length - 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }
                        if (possibilityCounter == 1)
                        {
                            setHeadActive();
                            currentController = controllerCube;
                            controllerCube.SetActive(true);
                            controllerSphere.SetActive(false);
                            currentController.GetComponent<BoxCollider>().enabled = true;
                            currentController.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter - 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }

                        if (possibilityCounter == 2)
                        {
                            setBodyAndHeadActive();
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                            //createSphereIfPossible.createObjectIfPossible.collision = false;
                            currentController.GetComponent<BoxCollider>().enabled = false;
                            currentController.GetComponent<MeshRenderer>().enabled = false;
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
                            setBodyActive();
                            currentController = controllerSphere;
                            controllerCube.SetActive(false);
                            controllerSphere.SetActive(true);
                            currentController.GetComponent<SphereCollider>().enabled = true;
                            currentController.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter + 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }
                        if (possibilityCounter == 1)
                        {
                            setHeadActive();
                            currentController = controllerCube;
                            controllerCube.SetActive(true);
                            controllerSphere.SetActive(false);
                            currentController.GetComponent<BoxCollider>().enabled = true;
                            currentController.GetComponent<MeshRenderer>().enabled = true;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[possibilityCounter + 1].SetActive(false);
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        }

                        if (possibilityCounter == 2)
                        {
                            setBodyAndHeadActive();
                            //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                            // createSphereIfPossible.createObjectIfPossible.collision = false;
                            currentController.GetComponent<SphereCollider>().enabled = false;
                            currentController.GetComponent<MeshRenderer>().enabled = false;
                            possibilityList[possibilityCounter].SetActive(true);
                            possibilityList[0].SetActive(false);
                        }
                        switchCircle();
                    }
                }

            changeColorControllerSphere();




        }



    }
}