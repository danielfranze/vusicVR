using UnityEngine;
using System.Collections;
using System.Linq;

namespace movePointSensorNamespace
{
    public class movePointSensor : MonoBehaviour
    {
        public static float speed;

        private Transform[] sensorPoints;
        private int currentPoint;

        // Use this for initialization
        void Start()
        {
            // Global
            speed = 0f;


            // Lokal
            sensorPoints = new Transform[16];
            foreach (int index in Enumerable.Range(0, 16))
            {
                sensorPoints[index] = GameObject.Find("Zylinder" + index).transform;
            }
            transform.position = sensorPoints[0].position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position == sensorPoints[currentPoint].position)
            {
                currentPoint++;
            }

            if (currentPoint >= sensorPoints.Length)
            {
                currentPoint = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, sensorPoints[currentPoint]
                                                     .position, speed * Time.deltaTime);
        }
    }
}