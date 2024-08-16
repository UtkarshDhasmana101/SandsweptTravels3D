using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacleToSpawn;
    public float spawnInterval = 3f;
    public float spawnDuration = 4f;
    public int maxObstacles = 19;
    public float maxSpawnHeightAboveTerrain = 5f;

    private float timeElapsed = 0f;
    private int obstaclesSpawned = 0;

    void Update()
    {
        if (timeElapsed < spawnDuration && obstaclesSpawned < maxObstacles)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= spawnInterval)
            {
                SpawnObstacles();
                timeElapsed = 0f;
            }
        }
    }

    void SpawnObstacles()
    {
        if (obstaclesSpawned < maxObstacles)
        {
            GameObject objectToSpawn = obstacleToSpawn[Random.Range(0, obstacleToSpawn.Length)];
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

            obstaclesSpawned++;
        }
    }
}
