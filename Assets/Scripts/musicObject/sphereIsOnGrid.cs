using UnityEngine;
using System.Collections;

namespace createSphereIfPossible
{
    public class sphereIsOnGrid : MonoBehaviour
    {
        public static bool sphereCreater;
        public static bool sphereOnGrid;
        public static bool collision;
        public static GameObject currentGrid;

        // Use this for initialization
        void Start()
        {
           // sphereCreater = true;
            collision = false;
            sphereOnGrid = false;
        }

        // Update is called once per frame
        void Update()
        {
      
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Grid")
            {
                currentGrid = col.gameObject;
                sphereOnGrid = true;
            }
            if (col.gameObject.tag == "musicSphere")
            {
                collision = true;
            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Grid")
            {
                sphereOnGrid = false;
            }
            if (col.gameObject.tag == "musicSphere")
            {
                collision = false;
            }


        }


        void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "musicSphere")
            {
                collision = true;
            }
            if (col.gameObject.tag == "Grid")
            {
                sphereOnGrid = true;
            }
        }
    }
}