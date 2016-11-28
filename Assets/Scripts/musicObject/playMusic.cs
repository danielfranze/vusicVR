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
        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            if (isActivate)
            {
                audio.Play();
            }
        }
        else
        {
            if (isActivate)
            {
                audio.Stop();
                mesh.material.color = Color.white;
                isActivate = false;
            }
            else
            {
                if (tag == "Zeile1")
                {
                    mesh.material.color = Color.red;
                }

                if (tag == "Zeile2")
                {
                    mesh.material.color = Color.green;
                }

                if (tag == "Zeile3")
                {
                    mesh.material.color = Color.blue;
                }

                if (tag == "Zeile4")
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
