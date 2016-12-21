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
            // Global
            createSphereIsPossible = true;
            collision = false;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerExit()
        {
            createSphereIsPossible = true;
            collision = false;
        }


        void OnTriggerStay()
        {
            collision = true;
        }
    }
}
