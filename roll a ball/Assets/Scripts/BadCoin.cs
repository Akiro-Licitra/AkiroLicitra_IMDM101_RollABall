using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCoin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -999) * Time.deltaTime);
    }
}
