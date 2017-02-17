using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereHelper : MonoBehaviour {
    private GameObject[] fieldList = new GameObject[2];
    private GameObject colorField;
    private int counter = 0;
    private int field1;
    private string fieldString1;
    private int field2;
    private string fieldString2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setFieldObject(GameObject fieldObject)
    {
        fieldList[counter] = fieldObject;

        if (counter == 1)
        {
            counter = 0;
        } else
        {
            counter++;
        }
    }

    public GameObject getFieldObject()
    {
        if(fieldList[0].name.Substring(7, 1) == "_")
        {
            fieldString1 = fieldList[0].name.Substring(6, 1);
        } else
        {
           fieldString1 = fieldList[0].name.Substring(6, 2); 
        }
        field1 = int.Parse(fieldString1);


        if (fieldList[1].name.Substring(7, 1) == "_")
        {
            fieldString2 = fieldList[1].name.Substring(6, 1);
        }
        else
        {
            fieldString2 = fieldList[1].name.Substring(6, 2);
        }
        field2 = int.Parse(fieldString2);

        if (field1 == 0)
        {
            if(field2 == 31)
            {
                return fieldList[1];
            }
        }

        if (field1 == 31)
        {
            if (field2 == 1)
            {
                return fieldList[0];
            }
        }

        if (field1 > field2)
        {
            return fieldList[1];
        } else
        {
            return fieldList[0];
        }
    }
}
