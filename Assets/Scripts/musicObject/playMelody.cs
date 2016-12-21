using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMelody : MonoBehaviour
{

    public static AudioClip[] startSphereMelodyList = new AudioClip[3];

    private GameObject objectOfMelody;
    // Use this for initialization
    void Start ()
    {

        // Global
        startSphereMelodyList[0] = Resources.Load("Melodie3_House2") as AudioClip;
        startSphereMelodyList[1] = Resources.Load("Melodie2_House1") as AudioClip;
        startSphereMelodyList[2] = Resources.Load("Melodie5_düster") as AudioClip;


        // Lokal
        objectOfMelody = GameObject.Find("Gitter_Karussell");
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
