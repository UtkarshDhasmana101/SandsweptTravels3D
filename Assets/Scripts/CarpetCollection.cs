using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetCollection : MonoBehaviour
{
    public GameObject[] carpetToSpawn;
    public float spawnnInterval = 3f;
    public float spawnnDuration = 4f;
    public int maxCarpets = 19;
    public float maxSpawnHeightAboveTerrain = 5f;

    private float timeElaped = 0f;
    private int obstaclessSpawned = 0;

    void Update()
    {
        if (timeElaped < spawnnDuration && obstaclessSpawned < maxCarpets)
        {
            timeElaped += Time.deltaTime;

            if (timeElaped >= spawnnDuration)
            {
                SpawnObsttacles();
                timeElaped = 0f;
            }
        }
    }

    void SpawnObsttacles()
    {
        if (obstaclessSpawned < maxCarpets)
        {
            GameObject objectToSpawn = carpetToSpawn[Random.Range(0, carpetToSpawn.Length)];
            RaycastHit hit;
            Vector3 spawnPosition;

            do
            {
                spawnPosition = new Vector3(Random.Range(58f, 9f), Random.Range(28f, 32f), Random.Range(46f, 58f));
            } while (!Physics.Raycast(spawnPosition, Vector3.down, out hit));

            spawnPosition.y += Random.Range(0f, maxSpawnHeightAboveTerrain);

            GameObject spawnedObject = Instantiate(objectToSpawn, hit.point, Quaternion.Euler(-90f, 90f, 0f));

            GameObject terrainObject = GameObject.FindGameObjectWithTag("Obstacle");
            if (terrainObject != null)
            {
                spawnedObject.transform.parent = terrainObject.transform;
            }
            else
            {
                Debug.LogError("Terrain object not found! Make sure you have a GameObject tagged as 'Obstacle'.");
            }

            obstaclessSpawned++;
        }
    }
}


