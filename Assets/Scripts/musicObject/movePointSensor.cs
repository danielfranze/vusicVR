using UnityEngine;
using System.Collections;

namespace movePointSensorNamespace
{
    public class movePointSensor : MonoBehaviour
    {
        public static float speed;
        Vector3 targetPos;
        Vector3 start;
        Vector3 spawn;
        // Use this for initialization
        void Start()
        {
            speed = 0;
            targetPos = GameObject.FindGameObjectWithTag("Target").transform.position;
            start = GameObject.FindGameObjectWithTag("Start").transform.position;
            spawn.x = 1.2f;
            spawn.y = 0;
            spawn.z = 0;

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            /*if (transform.position == targetPos)
                {
                    transform.position = start + spawn;
                }
                else
                {
                    Debug.Log("speed: " + speed);
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                if (transform.position == start)
                {
                    Debug.Log("target1Pos !!!!!!!!!!!");
                    transform.position = targetPos - spawn;
                }
            }*/

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Target")
            {
                Debug.Log("col target");
                transform.position = start - spawn;
            }
            if (col.gameObject.tag == "Start")
            {
                Debug.Log("col start");
                transform.position = targetPos + spawn;
            }
        }
    }
}