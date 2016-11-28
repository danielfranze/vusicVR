using UnityEngine;
using System.Collections;

public class createObject : MonoBehaviour {
    private Valve.VR.EVRButtonId triggerButton;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device controller;
    private GameObject actorSphere;
    //private Collider col;
    //private SphereCollider sphereCollider;

    //Use this for initialization
    void Start () {
        triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
        trackedObject = GetComponent<SteamVR_TrackedObject>();

    }

	//Update is called once per frame
	void Update () {

        // Exception
        controller = SteamVR_Controller.Input((int)trackedObject.index);
        if(controller.GetPress(triggerButton))
        {
            actorSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            actorSphere.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            actorSphere.transform.position = new Vector3(controller.transform.pos.x, controller.transform.pos.y, controller.transform.pos.z);
            actorSphere.GetComponent<Renderer>().material.color = Color.red;
            actorSphere.tag = "Sound1";

            // Collider Settings
            //actorSphere.AddComponent<SphereCollider>();
            actorSphere.GetComponent<SphereCollider>().radius = 0.2f;
            //System.Threading.Thread.Sleep(500);

        }
    }
}
