using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    public GameObject[] plane;

    public GameObject spawnPoint;

    GameObject randGame()
    {
        return plane[Random.Range(0, plane.Length)];
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(randGame(), spawnPoint.transform.position, Quaternion.identity);
        }
    }

}