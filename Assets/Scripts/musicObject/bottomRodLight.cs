using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;


public class bottomRodLight : MonoBehaviour
{

    /// private Thread t1;
    private MeshRenderer mesh;
    private Material saved_material;

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
            saved_material = gameObject.GetComponent<Renderer>().material;
            mesh.material = Resources.Load("spherePlay") as Material;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            var numberOfSeconds = 0.05f;
            StartCoroutine(SetMaterialAfter(numberOfSeconds));

        }
    }
    private IEnumerator SetMaterialAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        mesh.material = saved_material;
    }



}
