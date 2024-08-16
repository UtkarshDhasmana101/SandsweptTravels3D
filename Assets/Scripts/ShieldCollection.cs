using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollection : MonoBehaviour
{ 
    public GameObject[] shieldToSpawn;
    public float spwnInterval = 3f;
    public float spwnDuration = 4f;
    public int maxShield = 19;
    public float maxxSpawnHeightAboveTerrain = 5f;

    private float timeElapse = 0f;
    private int shieldSpawned = 0;

    void Update()
    {
        if (timeElapse < spwnDuration && shieldSpawned < maxShield)
        {
            timeElapse += Time.deltaTime;

            if (timeElapse >= spwnInterval)
            {
                SpawnObstacles();
                timeElapse = 0f;
            }
        }
    }

    void SpawnObstacles()
    {
        if (shieldSpawned < maxShield)
        {
            GameObject objectToSpawn = shieldToSpawn[Random.Range(0,shieldToSpawn.Length)];
            RaycastHit hit;
            Vector3 spawnPosition;

            do
            {
                spawnPosition = new Vector3(Random.Range(58f, 9f), Random.Range(28f, 32f), Random.Range(46f, 58f));
            } while (!Physics.Raycast(spawnPosition, Vector3.down, out hit));

            spawnPosition.y += Random.Range(0f, maxxSpawnHeightAboveTerrain);

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

            shieldSpawned++;
        }
    }
}


