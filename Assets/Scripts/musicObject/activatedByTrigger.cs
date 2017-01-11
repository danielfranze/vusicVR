using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;
///using System.Threading;


public class activatedByTrigger : MonoBehaviour
{

    /// private Thread t1;
    private MeshRenderer mesh;
    //private DateTime isActiveTime = DateTime.Now;

    // Use this for initialization
    void Start()
    {
        // Lokal
        mesh = GetComponents<MeshRenderer>()[0];
        /// t1 = new Thread(doLogic) { Name = "Thread 1" };
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
            /// t1.Start();
            /// t1.Join();

            mesh.material = Resources.Load("grid") as Material;
        }
    }

    /*void doLogic()
    {
        Thread.Sleep(1000);

    }*/

}
