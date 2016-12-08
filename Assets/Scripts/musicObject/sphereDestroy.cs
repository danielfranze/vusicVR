using UnityEngine;
using System.Collections;

public class sphereDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Funktioniert!");
        if(col.gameObject.name == "musicSphere")
        {
            Destroy(col.gameObject);
        }
    }

}
