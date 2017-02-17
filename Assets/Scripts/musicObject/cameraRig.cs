using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour {
    private Vector3 position; 
	// Use this for initialization
	void Start () {
        position = GameObject.Find("GameObject").transform.position;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("had collision");
        /*if(col.gameObject.name.Substring(0, 5) == "field")
        {
            GameObject.Find("GameObject").transform.position = position;
            Debug.Log("position wo ich hin bin:" + GameObject.Find("[CameraRig]").transform.position);
        }*/
    }
}
