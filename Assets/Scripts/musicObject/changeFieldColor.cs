using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFieldColor : MonoBehaviour {
    
    private int currentTag = 0;
    private GameObject colorField;
    public sphereHelper helper;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name.Substring(0, 5) == "field")
        { 
            GetComponent<sphereHelper>().setFieldObject(col.gameObject);
        }
        if(col.gameObject.tag == "Trigger")
        {
            colorField = GetComponent<sphereHelper>().getFieldObject();
            colorField.GetComponent<fieldHight>().setFieldMaterial(this.GetComponents<Renderer>()[0].material);

        }
    }
 

}
