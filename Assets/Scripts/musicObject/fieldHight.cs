using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldHight : MonoBehaviour {
    private Vector3 position = new Vector3();
    private int fieldTag = 0;
    

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ControllerSphere")
        {
            if (gameObject.tag == "0")
            {
                fieldTag = 0;
            }
            else if (gameObject.tag == "1")
            {
                fieldTag = 1;
            }
            else if (gameObject.tag == "2")
            {
                fieldTag = 2;
            }
            else if (gameObject.tag == "3")
            {
                fieldTag = 3;
            }
            else if (gameObject.tag == "4")
            {
                fieldTag = 4;
            }
            else if (gameObject.tag == "5")
            {
                fieldTag = 5;
            }
            else if (gameObject.tag == "6")
            {
                fieldTag = 6;
            }
            else if (gameObject.tag == "7")
            {
                fieldTag = 7;
            }
            col.gameObject.GetComponent<sphereIsOnGrid>().setFieldTag(fieldTag);

        }



    }
}
