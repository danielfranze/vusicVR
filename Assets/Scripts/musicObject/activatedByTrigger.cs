using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;
using System.Linq;


public class activatedByTrigger : MonoBehaviour
{

    /// private Thread t1;
    private MeshRenderer mesh;
    //private List<GameObject> objectList =  new List<GameObject>();
    private int sizeList = 0;

    ICollection<KeyValuePair<GameObject, Material>> objectList = new Dictionary<GameObject, Material>();
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
        if (col.gameObject.tag == "musicSphere")
        {
            objectList.Add(new KeyValuePair<GameObject, Material>(col.gameObject, col.gameObject.GetComponent<MeshRenderer>().material));
            sizeList++;
        }

        if (col.gameObject.tag == "Trigger")
        {
            mesh.material = Resources.Load("spherePlay") as Material;

            foreach (KeyValuePair<GameObject, Material> element in objectList)
            {
                if(element.Key == null)
                {
                    objectList.Remove(element);
                    sizeList--;
                }
                else
                {
                    element.Key.GetComponent<MeshRenderer>().material = Resources.Load("spherePlay") as Material;
                    //mesh.material = Resources.Load("spherePlay") as Material;
                    element.Key.GetComponents<AudioSource>()[0].Play();
                   // element.Key.GetComponent<MeshRenderer>().material = element.Value;


                    //mesh.material = element.Value as Material;
                }
                    

            }

           }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Trigger")
        {
            var numberOfSeconds = 2f;
            StartCoroutine(SetMaterialAfter(numberOfSeconds));
            
        }
    }
    private IEnumerator SetMaterialAfter(float seconds)
    {
        yield return new WaitForSeconds(0.2f);
        mesh.material = Resources.Load("grid") as Material;
        foreach (KeyValuePair<GameObject, Material> element in objectList)
        {
            element.Key.GetComponent<MeshRenderer>().material = element.Value;
        }
    }



}
