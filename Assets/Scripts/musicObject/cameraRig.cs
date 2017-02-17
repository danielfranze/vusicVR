using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour {
    private Vector3 position; 
	// Use this for initialization
	void Start () {
        position.x = 0.3f;
        position.y = 1.05f;
        position.z = -0.03f;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name.Substring(0, 5) == "field")
        {
            GameObject.Find("[CameraRig]").transform.position = position;
            Debug.Log("position wo ich hin bin:" + GameObject.Find("[CameraRig]").transform.position);
        }
    }
}
