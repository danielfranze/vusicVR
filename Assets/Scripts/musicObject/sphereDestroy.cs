using UnityEngine;
using System.Collections;

public class sphereDestroy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

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
            //GameObject.Find("controllerSphere").GetComponent<createObjectIfPossible>().setCollision(false);
            //GameObject.Find("controllerSphere").GetComponent<createObjectIfPossible>().setCreateSphereIfPossible(false);
            GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().setCollision(false);
        }
    }

    /*void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "musicSphere")
        {
            GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().setCollision(false);
        }
    }*/

}
