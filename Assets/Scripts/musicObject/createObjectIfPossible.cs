using UnityEngine;
using System.Collections;


    public class createObjectIfPossible : MonoBehaviour
    {
        private bool createSphereIsPossible;
        private bool collision;


        public bool getCreateSphereIfPossible()
        {
            return createSphereIsPossible;
        }

        public void setCreateSphereIfPossible(bool value)
        {
            createSphereIsPossible = value;
        }

        public bool getCollision()
        {
            return collision;
        }

        public void setCollision(bool value)
        {
            collision = value;
        }


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

