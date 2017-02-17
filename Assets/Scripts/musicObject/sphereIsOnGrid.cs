using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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
            // FIX
            if(sphereOnGrid == false)
            {
                List<string> list_body = new List<string>();
                List<string> list_head = new List<string>();
                foreach (int index in Enumerable.Range(0, 32))
                {

                    list_body.Add("rod_" + index + "_body");
                    list_head.Add("rod_" + index + "_head");

                //GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
                //GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;


                if (GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 0)
                {
                    GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;

                }
                else if (GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 1)
                {
                    GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;

                }
                }

            }
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
                //Debug.Log("collision Enter: " + collision);
            }


        /* Test BUG FIX */
        List<string> list_body = new List<string>();
        List<string> list_head = new List<string>();
        foreach (int index in Enumerable.Range(0, 32))
        {

            list_body.Add("rod_" + index + "_body");
            list_head.Add("rod_" + index + "_head");

            //GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            //GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
        }
        if (list_body.Contains(col.gameObject.name) && GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 0)
        {
            collision = false;
            sphereOnGrid = true;
            GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().vibrateController();
        }
        else if (list_head.Contains(col.gameObject.name) && GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 1)
        {
            collision = false;
            sphereOnGrid = true;
            GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().vibrateController();
        }

    }

        //Material saved_material;
        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Grid")
            {
                sphereOnGrid = false;
            }
            if (col.gameObject.tag == "musicSphere")
            {
                collision = false;
                //Debug.Log("collision Exit: "+ collision);
            }

        List<string> list_body = new List<string>();
        List<string> list_head = new List<string>();
        foreach (int index in Enumerable.Range(0, 32))
        {

            list_body.Add("rod_" + index + "_body");
            list_head.Add("rod_" + index + "_head");

            //GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            //GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
        }


        if (list_body.Contains(col.gameObject.name))
        {
            //Debug.Log("Hello");
            //saved_material = col.gameObject.GetComponent<Renderer>().material as Material;
            if (GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 0)
            {
                col.gameObject.GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            }

        }
        if (list_head.Contains(col.gameObject.name))
        {
            if (GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 1)
            {
                col.gameObject.GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            }
        }

    }


        void OnTriggerStay(Collider col)
        {
        // col.gameObject.tag == "horizontGrid" 
            if (col.gameObject.tag == "musicSphere")
            {
                collision = true;
            }

            if (col.gameObject.tag == "Grid")
            {
                sphereOnGrid = true;
            }

       
        List<string> list_body = new List<string>();
        List<string> list_head = new List<string>();
        foreach (int index in Enumerable.Range(0, 32))
        {

            list_body.Add("rod_" + index + "_body");
            list_head.Add("rod_" + index + "_head");

            //GameObject.Find("rod_" + index + "_body").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
            //GameObject.Find("rod_" + index + "_head").GetComponent<Renderer>().material = Resources.Load("grid") as Material;
        }

        if (list_body.Contains(col.gameObject.name))
        {
            //Debug.Log("Hello");
            //saved_material = col.gameObject.GetComponent<Renderer>().material as Material;
            if(GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 0)
            {
                col.gameObject.GetComponent<Renderer>().material = GameObject.Find("controllerSphere").GetComponent<Renderer>().material;
            }

        }
        if (list_head.Contains(col.gameObject.name))
        {
            if (GameObject.FindWithTag("mainRightController").GetComponent<main.rightController>().getPossibilityCounter() == 1)
            {
                col.gameObject.GetComponent<Renderer>().material = GameObject.Find("controllerCube").GetComponent<Renderer>().material;
            }
        }





    }
    }
