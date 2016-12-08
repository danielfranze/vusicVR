using UnityEngine;

public class rightController : MonoBehaviour
{
    public AudioClip audioClip;

    private Valve.VR.EVRButtonId triggerButton;
    private Valve.VR.EVRButtonId touchPad;

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device controller;
    private GameObject actorSphere;
    private bool collision = false;
    private int fps = 0;

    Material[] colorList = new Material[7];
    AudioClip[] audioList = new AudioClip[7];
    public GameObject[] possibilityList = new GameObject[2];
    int possibilityCounter = 0;
    public GameObject sphereDestroyer;
    public GameObject colorCircle1;
    public GameObject controllerSphere;
    int indexAudioList = 0;
    int currentRotPos = 0;
    bool boole = true;

    //private Collider col;
    //private SphereCollider sphereCollider;

    //Use this for initialization
    void Start()
    {


        triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

        trackedObject = GetComponent<SteamVR_TrackedObject>();

        audioList[0] = Resources.Load("Crash909") as AudioClip;
        audioList[1] = Resources.Load("R_Clap") as AudioClip;
        audioList[2] = Resources.Load("R_Hi-Hat") as AudioClip;
        audioList[3] = Resources.Load("R_Kick") as AudioClip;
        audioList[4] = Resources.Load("Snare909_2") as AudioClip;
        audioList[5] = Resources.Load("TomLow909_2") as AudioClip;
        audioList[6] = Resources.Load("Melodie3_House2") as AudioClip;

        colorList[0] = Resources.Load("gelb") as Material;
        colorList[1] = Resources.Load("magenta") as Material;
        colorList[2] = Resources.Load("pink") as Material;
        colorList[3] = Resources.Load("lila") as Material; 
        colorList[4] = Resources.Load("rosa") as Material;
        colorList[5] = Resources.Load("rot") as Material;
        colorList[6] = Resources.Load("orange") as Material;

        sphereDestroyer = GameObject.Find("sphereDestroyer");
        controllerSphere = GameObject.Find("controllerSphere");
        colorCircle1 = GameObject.Find("colorCircle1");

        possibilityList[0] = colorCircle1;
        possibilityList[1] = sphereDestroyer;

        colorCircle1.SetActive(true);
        sphereDestroyer.SetActive(true);
        controllerSphere.SetActive(true);




    }

    //Update is called once per frame
    void Update()
    {
        // Exception
        if(boole)
        {
            sphereDestroyer.SetActive(false);
            boole = false;
        }
        controller = SteamVR_Controller.Input((int)trackedObject.index);

        if (controller.GetPress(triggerButton) && createSphereIfPossible.createObjectIfPossible.createSphereIsPossible && !createSphereIfPossible.createObjectIfPossible.collision)
        {
            createSphere();
            createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = false;
        }

        fps++;
        if (fps == 15)
        {
            if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            
            {

                if (controller.GetAxis(touchPad).x > 0.5f) //right
                {
                    Debug.Log("falsch");
                    indexAudioList++;
                    if (indexAudioList == audioList.Length)
                    {
                        indexAudioList = 0;
                    }

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

                if (controller.GetAxis(touchPad).x < -0.5f) //left
                {
                    Debug.Log("falsch");
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
                    Debug.Log("hallo");
                    possibilityCounter++;

                    if (possibilityCounter > possibilityList.Length - 1)
                    {
                        controllerSphere.GetComponent<SphereCollider>().enabled = true;
                        controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                        possibilityList[possibilityCounter - 1].SetActive(false);
                        possibilityCounter = 0;
                        possibilityList[possibilityCounter].SetActive(true);
                        //controllerSphere.SetActive(true);
                        createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;

                        Debug.Log("poss = 0");
                    }
                    else
                    {
                        createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = false;
                        controllerSphere.GetComponent<SphereCollider>().enabled = false;
                        controllerSphere.GetComponent<MeshRenderer>().enabled = false;
                        possibilityList[possibilityCounter].SetActive(true);
                        possibilityList[possibilityCounter - 1].SetActive(false);
                        //controllerSphere.SetActive(false);


                        Debug.Log("poss = 1");
                    }


                }



                if (controller.GetAxis(touchPad).y < -0.5f) //down
                {
                    possibilityCounter--;
                    if (possibilityCounter < 0)
                    {
                        createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = false;
                        controllerSphere.GetComponent<SphereCollider>().enabled = false;
                        controllerSphere.GetComponent<MeshRenderer>().enabled = false;
                        possibilityList[possibilityCounter + 1].SetActive(false);
                        possibilityCounter = possibilityList.Length - 1;
                        possibilityList[possibilityCounter].SetActive(true);
                        //controllerSphere.SetActive(true);


                        Debug.Log("poss = 0");
                    }
                    else
                    {

                        controllerSphere.GetComponent<SphereCollider>().enabled = true;
                        controllerSphere.GetComponent<MeshRenderer>().enabled = true;
                        possibilityList[possibilityCounter].SetActive(true);
                        possibilityList[possibilityCounter + 1].SetActive(false);
                        createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
                        //controllerSphere.SetActive(false);


                        Debug.Log("poss = 1");
                    }

                }
            }

            GameObject.Find("controllerSphere").GetComponent<MeshRenderer>().material = colorList[indexAudioList];
            fps = 0;
        }
        //collision = false;
    }

    void createSphere()
    {
        actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        actorSphere.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        actorSphere.transform.position = GameObject.FindGameObjectWithTag("ControllerSphere").transform.position;

        actorSphere.AddComponent<Rigidbody>();
        actorSphere.GetComponent<Rigidbody>().useGravity = false;
        actorSphere.GetComponent<Rigidbody>().isKinematic = true;
        actorSphere.name = "musicSphere";
        actorSphere.tag = "Sound" + indexAudioList;
        actorSphere.GetComponent<SphereCollider>().radius = 0.65f;
        actorSphere.GetComponent<SphereCollider>().isTrigger = true;
        actorSphere.AddComponent<AudioSource>();
        actorSphere.GetComponent<AudioSource>().clip = audioList[indexAudioList];

        actorSphere.AddComponent<playMusic>();
        actorSphere.GetComponent<MeshRenderer>().material = colorList[indexAudioList];
        actorSphere.GetComponents<AudioSource>()[0].Play();
    }


}