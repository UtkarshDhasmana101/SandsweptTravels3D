using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRespawn : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime*speed);
        
    }
}
