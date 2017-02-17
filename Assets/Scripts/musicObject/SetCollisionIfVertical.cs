using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCollisionIfVertical : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "controllerSphere")
        {
            //Debug.Log("OnTriggerExit");
            GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().setCollision(false);
            //GameObject.Find("controllerCube").GetComponent<sphereIsOnGrid>().setCollision(false);
        }
    }

    
    void OnTriggerStay(Collider col)
    {
        // col.gameObject.tag == "horizontGrid" 
        if (col.gameObject.name == "controllerSphere")
        {
            //Debug.Log("OnTriggerStay");
            GameObject.Find("controllerSphere").GetComponent<sphereIsOnGrid>().setCollision(true);
            //GameObject.Find("controllerCube").GetComponent<sphereIsOnGrid>().setCollision(true);
        }
    }
    /*
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ControllerSphere")
        {
            Debug.Log("OnTriggerEnter");
            GameObject.FindWithTag("ControllerSphere").GetComponent<sphereIsOnGrid>().setCollision(true);
        }
    }*/

    }
