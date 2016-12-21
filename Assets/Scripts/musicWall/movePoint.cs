using UnityEngine;
using System.Collections;

public class movePoint : MonoBehaviour {

    public float speed;

    private Vector3 targetPos;
    private Vector3 startPos;

    // Use this for initialization
    void Start ()
    {
        // Global
        speed = 1f;


        // Lokal
        targetPos = GameObject.FindGameObjectWithTag("Target").transform.position;
        startPos = GameObject.FindGameObjectWithTag("Trigger").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position == targetPos)
        {
            transform.position = startPos;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
	}
}
