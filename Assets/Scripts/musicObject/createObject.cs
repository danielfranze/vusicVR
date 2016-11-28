using UnityEngine;
using System.Collections;
using createSphereIfPossible;

public class createObject : MonoBehaviour
{
    private Valve.VR.EVRButtonId triggerButton;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device controller;
    private GameObject actorSphere;
    private bool collision = false;

    //private Collider col;
    //private SphereCollider sphereCollider;

    //Use this for initialization
    void Start()
    {

        triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        trackedObject = GetComponent<SteamVR_TrackedObject>();
      
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
            createSphereIfPossible.createObjectIfPossible.createSphereIsPossible = false;
            createSphere();

        }
        //collision = false;
    }

    void createSphere()
    {
        actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        actorSphere.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        actorSphere.transform.position = GameObject.FindGameObjectWithTag("ControllerSphere").transform.position;
        actorSphere.GetComponent<Renderer>().material.color = Color.red;
        actorSphere.AddComponent<Rigidbody>();
        actorSphere.GetComponent<Rigidbody>().useGravity = false;
        actorSphere.GetComponent<Rigidbody>().isKinematic = true;
        actorSphere.tag = "Sound1";
        actorSphere.GetComponent<SphereCollider>().radius = 0.65f;
        actorSphere.GetComponent<SphereCollider>().isTrigger = true;
        AudioSource audio = actorSphere.AddComponent<AudioSource>();
        audio.clip = Resources.Load("HiHatOpen909") as AudioClip;
    }


}