using UnityEngine;
using System.Collections;


    public class sphereIsOnGrid : MonoBehaviour
    {
        private bool sphereCreater;
        private bool sphereOnGrid;
        private bool collision;
        private GameObject currentGrid;
        private int fieldTag;

        public int getFieldTag()
        {
            return fieldTag;
        }

        public void setFieldTag(int tag)
        {
            fieldTag = tag;
        }

        public float getTransformPosition(int position)
        {
            return currentGrid.transform.position[position];
        }
        
        
        public bool getSphereCreater()
        {
            return sphereCreater;
        }

        public void setSphereCreater(bool value)
        {
            sphereCreater = value;
        }

         public bool getSphereOnGrid()
        {
            return sphereOnGrid;
        }

        public void setSphereOnGrid(bool value)
        {
            sphereOnGrid = value;
        }

        public bool getCollision()
        {
            return collision;
        }

        public void setCollision(bool value)
        {
            collision = value;
        }

        public GameObject getCurrentGrid()
        {
            return currentGrid;
        }

        public void setCurrentGrid(GameObject value)
        {
            currentGrid = value;
        }














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
