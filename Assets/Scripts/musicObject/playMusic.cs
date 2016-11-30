using UnityEngine;
using System.Collections;

public class playMusic : MonoBehaviour
{
    AudioSource audio;
    MeshRenderer mesh;
    bool isActivate;
    // Use this for initialization
    void Start()
    {
        audio = GetComponents<AudioSource>()[0];
        mesh = GetComponents<MeshRenderer>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {


            if (tag == "Sound0")
            {
                mesh.material.color = Color.yellow;    
            }

            if (tag == "Sound1")
            {
                mesh.material.color = Color.yellow;
            }

            if (tag == "Sound2")
            {
                mesh.material.color = Color.yellow;
            }

            if (tag == "Sound3")
            {
                mesh.material.color = Color.yellow;
            }

            audio.Play();
            // audio.loop = true;

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            if (tag == "Sound0")
            {
                mesh.material.color = Color.red;
            }

            if (tag == "Sound1")
            {
                mesh.material.color = Color.blue;
            }

            if (tag == "Sound2")
            {
                mesh.material.color = Color.green;
            }

            if (tag == "Sound3")
            {
                mesh.material.color = Color.black;
            }

        }
    }


}