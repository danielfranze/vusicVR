using UnityEngine;
using System.Collections;

public class triggerPlayMusic : MonoBehaviour
{

    private AudioSource audioSource;
    private MeshRenderer mesh;
    private bool isActivate;

    // Use this for initialization
    void Start ()
    {
        // Lokal
        audioSource = GetComponents<AudioSource>()[0];
        mesh = GetComponents<MeshRenderer>()[0];
        isActivate = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Trigger")
        {
            if (isActivate)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (isActivate)
            {
                audioSource.Stop();
                mesh.material.color = Color.white;
                isActivate = false;
            }
            else
            {   
                if(tag == "Zeile1")
                {
                    mesh.material.color = Color.red;
                }

                if (tag == "Zeile2")
                {
                    mesh.material.color = Color.green;
                }

                if(tag == "Zeile3")
                {
                    mesh.material.color = Color.blue;
                }

                if(tag == "Zeile4")
                {
                    mesh.material.color = Color.yellow;
                }
                // audio.Play();
                // audio.loop = true;
                isActivate = true;
            }
        }

    }
    
}
