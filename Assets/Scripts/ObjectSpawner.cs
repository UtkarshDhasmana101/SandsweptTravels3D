using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnInterval = 3f;
    public float spawnDuration = 4f;
    public int maxCollectibles = 19;
    public float maxSpawnHeightAboveTerrain = 5f;

    private float timeElapsed = 0f;
    private int collectiblesSpawned = 0;

    void Update()
    {
        if (timeElapsed < spawnDuration && collectiblesSpawned < maxCollectibles)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= spawnInterval)
            {
                SpawnObjects();
                timeElapsed = 0f;
            }
        }
    }

    void SpawnObjects()
    {
        if (collectiblesSpawned < maxCollectibles)
        {
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            RaycastHit hit;
            Vector3 spawnPosition;

            do
            {
                spawnPosition = new Vector3(Random.Range(58f, 9f), Random.Range(29f, 33f), Random.Range(46f, 58f));
            } while (!Physics.Raycast(spawnPosition, Vector3.down, out hit));

            spawnPosition.y += Random.Range(0f, maxSpawnHeightAboveTerrain);

            GameObject spawnedObject = Instantiate(objectToSpawn, hit.point, Quaternion.identity);

            GameObject terrainObject = GameObject.FindGameObjectWithTag("Obstacle");
            if (terrainObject != null)
            {
                spawnedObject.transform.parent = terrainObject.transform;
            }
            else
            {
                Debug.Log("Terrain object not found");
            }

            collectiblesSpawned++;
        }
    }
}
