using UnityEngine;
using System.Collections;

public class movePointSensor : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    Vector3 startPos;
    // Use this for initialization
    void Start()
    {
        speed = 1f;
        targetPos = GameObject.FindGameObjectWithTag("Target").transform.position;
        startPos = GameObject.FindGameObjectWithTag("Trigger").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
