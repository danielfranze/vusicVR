using UnityEngine;
using System.Collections;


public class playMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer mesh;
    private bool isActivate;

    // Use this for initialization
    void Start()
    {
        // Lokal
        audioSource = GetComponents<AudioSource>()[0];
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
            mesh.material = Resources.Load("spherePlay") as Material;


            /* if (name == "Sound00")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound10")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound20")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound30")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }
             if (name == "Sound40")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound50")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound60")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }
             if (name == "Sound01")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound11")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound21")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound31")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }
             if (name == "Sound41")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound51")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }

             if (name == "Sound61")
             {
                 mesh.material = Resources.Load("spherePlay") as Material;
             }*/

            audioSource.Play();

        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            // circle 1
            if (name == "Sound00")
            {
                mesh.material = Resources.Load("1lila") as Material;
            }
            else if (name == "Sound10")
            {
                mesh.material = Resources.Load("1rot") as Material;
            }
            else if (name == "Sound20")
            {
                mesh.material = Resources.Load("1rosa") as Material;
            }
            else if (name == "Sound30")
            {
                mesh.material = Resources.Load("1pink") as Material;
            }
            else if (name == "Sound40")
            {
                mesh.material = Resources.Load("1orangegelb") as Material;
            }
            else if (name == "Sound50")
            {
                mesh.material = Resources.Load("1orange") as Material;
            }
            else if (name == "Sound60")
            {
                mesh.material = Resources.Load("1lilapink") as Material;
            }

            // circle 2
            if (name == "Sound01")
            {
                mesh.material = Resources.Load("2blau") as Material;
            }
            else if (name == "Sound11")
            {
                mesh.material = Resources.Load("2türkies") as Material;
            }
            else if (name == "Sound21")
            {
                mesh.material = Resources.Load("2hellgelb") as Material;
            }
            else if (name == "Sound31")
            {
                mesh.material = Resources.Load("2hellblau") as Material;
            }
            else if (name == "Sound41")
            {
                mesh.material = Resources.Load("2grün") as Material;
            }
            else if (name == "Sound51")
            {
                mesh.material = Resources.Load("2gelbgrün") as Material;
            }
            else if (name == "Sound61")
            {
                mesh.material = Resources.Load("2gelb") as Material;
            }

        }
    }
    

}