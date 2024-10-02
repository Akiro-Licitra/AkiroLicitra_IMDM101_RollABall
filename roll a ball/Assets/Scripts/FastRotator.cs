using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRotator : MonoBehaviour
{
    float time = 0;
    int r;
    float interval;
   
    void Start()
    {
        interval = Random.Range(2 / 3f, 10 / 3f);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -999) * Time.deltaTime);
   
        if (time >= interval)
        {
            time -= interval;
            interval = Random.Range(2 / 3f, 10 / 3f);
            r = Random.Range(0,8);
            switch (r)
            {
                case 0:
                    transform.position = new Vector3(-20, 5.5f, 34.4f);
                    break;
                case 1:
                    transform.position = new Vector3(20, 5.5f, 34.4f);
                    break;
                case 2:
                    transform.position = new Vector3(-38, 5.5f, 16.6f);
                    break;
                case 3:
                    transform.position = new Vector3(38, 5.5f, 16.6f);
                    break;
                case 4:
                    transform.position = new Vector3(-38, 5.5f, -23);
                    break;
                case 5:
                    transform.position = new Vector3(38, 5.5f, -23);
                    break;
                case 6:
                    transform.position = new Vector3(-20, 5.5f, -40.5f);
                    break;
                case 7:
                    transform.position = new Vector3(20, 5.5f, -40.5f);
                    break;
            } // end switch
        }
    }
}
