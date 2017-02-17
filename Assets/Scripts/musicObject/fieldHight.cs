using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class fieldHight : MonoBehaviour {
    private Vector3 position = new Vector3();
    private int fieldTag = 0;
    private Material startMaterial;
    private Material endMaterial;
    float fadeSpeed = 0.5f;


    // Use this for initialization
    void Start () {
        GetComponents<MeshRenderer>()[0].material = Resources.Load("fieldMaterial") as Material;
        endMaterial = Resources.Load("fieldMaterial") as Material;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "ControllerSphere")
        {
            fieldTag = int.Parse(tag.Substring(0, 1));
            col.gameObject.GetComponent<sphereIsOnGrid>().setFieldTag(fieldTag);
        }

    }

    public void setFieldMaterial(Material mat)
    {
        startMaterial = mat;
        StartCoroutine(ChangeMaterialBack());
    }

    IEnumerator ChangeMaterialBack()
    {
        // Lerp start value.
        float change = 0.0f;
        GetComponents<MeshRenderer>()[0].material = startMaterial;
        // Loop until lerp value is 1 (fully changed)
        while (change < 1.0f)
        {
            // Reduce change value by fadeSpeed amount.
            change += fadeSpeed * Time.deltaTime;
            GetComponents<MeshRenderer>()[0].material.Lerp(startMaterial, endMaterial, change);

            yield return null;
        }
    }
}
    
