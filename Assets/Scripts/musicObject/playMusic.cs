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
                mesh.material = Resources.Load("spherePlay") as Material;
            }

            if (tag == "Sound1")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
            }

            if (tag == "Sound2")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
            }

            if (tag == "Sound3")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
            }
            if (tag == "Sound4")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
            }

            if (tag == "Sound5")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
            }

            if (tag == "Sound6")
            {
                mesh.material = Resources.Load("spherePlay") as Material;
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
                mesh.material = Resources.Load("gelb") as Material;
            }

            if (tag == "Sound1")
            {
                mesh.material = Resources.Load("magenta") as Material;
            }

            if (tag == "Sound2")
            {
                mesh.material = Resources.Load("pink") as Material;
            }

            if (tag == "Sound3")
            {
                mesh.material = Resources.Load("lila") as Material;
            }

            if (tag == "Sound4")
            {
                mesh.material = Resources.Load("rosa") as Material;
            }

            if (tag == "Sound5")
            {
                mesh.material = Resources.Load("rot") as Material;
            }

            if (tag == "Sound6")
            {
                mesh.material = Resources.Load("orange") as Material;
            }

        }
    }


}