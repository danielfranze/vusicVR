using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMelody : MonoBehaviour
{

    public AudioClip[] startSphereMelodyList = new AudioClip[3];

    private GameObject objectOfMelody;
    // Use this for initialization
    void Start ()
    {

        // Global
        startSphereMelodyList[0] = Resources.Load("basemelody1") as AudioClip;
        startSphereMelodyList[1] = Resources.Load("basemelody2") as AudioClip;
        startSphereMelodyList[2] = Resources.Load("basemelody3") as AudioClip;


        // Lokal
        //objectOfMelody = GameObject.Find("Gitter_Karussell");
        objectOfMelody.AddComponent<AudioSource>();
        objectOfMelody.GetComponent<AudioSource>().clip = startSphereMelodyList[PlayerPrefs.GetInt("currentMelody")];
        objectOfMelody.GetComponents<AudioSource>()[0].loop = true;
        objectOfMelody.GetComponents<AudioSource>()[0].Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
