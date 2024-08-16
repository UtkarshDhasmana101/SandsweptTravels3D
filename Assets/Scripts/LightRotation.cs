using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    [SerializeField] float theta = 0.1f;
  
    void Update()
    {
        this.transform.RotateAround(Vector3.right, theta);
    }
}
