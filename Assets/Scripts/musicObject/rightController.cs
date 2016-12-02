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

    Color[] colorList = new Color[4];
    AudioClip[] audioList = new AudioClip[4];
    int indexAudioList = 0;

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

        colorList[0] = Color.red;
        colorList[1] = Color.blue;
        colorList[2] = Color.green;
        colorList[3] = Color.black;



        //createSphereIsPossible = true;
        //createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = true;
        //collision = false;

    }

    //Update is called once per frame
    void Update()
    {
        // Exception

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

                if (controller.GetAxis(touchPad).y > 0.5f)
                {
                    indexAudioList++;
                    if (indexAudioList == audioList.Length)
                    {
                        indexAudioList = 0;
                    }
                }

                if (controller.GetAxis(touchPad).y < -0.5f)
                {
                    indexAudioList--;
                    if (indexAudioList < 0)
                    {
                        indexAudioList = audioList.Length - 1;
                    }
                }
            }

            GameObject.Find("controllerSphere").GetComponent<MeshRenderer>().material.color = colorList[indexAudioList];
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
        actorSphere.tag = "Sound" + indexAudioList;
        actorSphere.GetComponent<SphereCollider>().radius = 0.65f;
        actorSphere.GetComponent<SphereCollider>().isTrigger = true;
        actorSphere.AddComponent<AudioSource>();
        actorSphere.GetComponent<AudioSource>().clip = audioList[indexAudioList];

        actorSphere.AddComponent<playMusic>();
        actorSphere.GetComponent<MeshRenderer>().material.color = colorList[indexAudioList];
        actorSphere.GetComponents<AudioSource>()[0].Play();
    }


}