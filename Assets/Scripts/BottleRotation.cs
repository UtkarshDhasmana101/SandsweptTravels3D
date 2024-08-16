using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRotation : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(-71f, Time.time * 120f, 0);

    }
}
