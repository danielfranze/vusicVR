using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMelody : MonoBehaviour {

    public static AudioClip[] startSphereMelodyList = new AudioClip[3];

    GameObject Gitter_Karussell;
    // Use this for initialization
    void Start () {

        startSphereMelodyList[0] = Resources.Load("Melodie3_House2") as AudioClip;
        startSphereMelodyList[1] = Resources.Load("Melodie2_House1") as AudioClip;
        startSphereMelodyList[2] = Resources.Load("Melodie5_düster") as AudioClip;
        
        Gitter_Karussell = GameObject.Find("Gitter_Karussell");
        Gitter_Karussell.AddComponent<AudioSource>();
        Gitter_Karussell.GetComponent<AudioSource>().clip = startSphereMelodyList[PlayerPrefs.GetInt("currentMelody")];
        Gitter_Karussell.GetComponents<AudioSource>()[0].loop = true;
        Gitter_Karussell.GetComponents<AudioSource>()[0].Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
