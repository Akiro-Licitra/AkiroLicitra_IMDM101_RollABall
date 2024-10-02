using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRotatorPirate : MonoBehaviour
{
    float time = 0;
    int r;
    float interval;

    void Start()
    {
        interval = Random.Range(7 / 3f, 19 / 3f);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -999) * Time.deltaTime);

        if (time >= interval)
        {
            time -= interval;
            interval = Random.Range(7 / 3f, 19 / 3f);
            r = Random.Range(0, 9);
            switch (r)
            {
                case 0:
                case 1:
                    transform.position = new Vector3(35.5f, -1.94f, 492.3f);
                    break;
                case 2:
                case 3:
                    transform.position = new Vector3(75.3f, -1.94f, 477.6f);
                    break;
                case 4:
                case 5:
                    transform.position = new Vector3(-24.9f, -1.94f, 271.3f);
                    break;
                case 6:
                case 7:
                    transform.position = new Vector3(-60.5f, -1.94f, 284.6f);
                    break;
                case 8:
                    transform.position = new Vector3(9f, -1.94f, 384.1f);
                    break;
            } // end switch
        }
    }
}

