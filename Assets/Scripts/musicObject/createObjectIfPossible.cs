using UnityEngine;
using System.Collections;

namespace createSphereIfPossible
{
    public class createObjectIfPossible : MonoBehaviour
    {
        public static bool createSphereIsPossible;
        public static bool collision;
        // Use this for initialization
        void Start()
        {
            createSphereIsPossible = true;

        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerExit()
        {
            createSphereIsPossible = true;
            //collision = false;
            /*
            if (controller.GetPress(triggerButton))
            {
                createSphere();

            }
            */
            collision = false;
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Sound1")
            {
                Debug.Log("Fuuuuck");
                //collision = true;
            }
        }

        void OnTriggerStay(Collider col)
        {
            collision = true;
        }
    }
}
