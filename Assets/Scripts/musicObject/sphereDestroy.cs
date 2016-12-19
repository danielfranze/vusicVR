using UnityEngine;
using System.Collections;

public class sphereDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "musicSphere" && main.rightController.trigger == true)
        {
            main.rightController.controller.TriggerHapticPulse(1000);
            Destroy(col.gameObject);
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "musicSphere" && main.rightController.trigger == true)
        {
            main.rightController.controller.TriggerHapticPulse(1000);
            Destroy(col.gameObject);
        }
    }

}
