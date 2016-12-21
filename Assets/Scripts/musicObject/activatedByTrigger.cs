using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class activatedByTrigger : MonoBehaviour
{
    private MeshRenderer mesh;
    //private DateTime isActiveTime = DateTime.Now;

    // Use this for initialization
    void Start()
    {
        // Lokal
        mesh = GetComponents<MeshRenderer>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            mesh.material = Resources.Load("spherePlay") as Material;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            mesh.material = Resources.Load("grid") as Material;
        }
    }
}
