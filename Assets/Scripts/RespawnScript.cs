using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> prefabToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacle")
        {
            Destroy(other.gameObject,100f);


            int index = Random.Range(0, prefabToSpawn.Count - 1);
            GameObject spawner= prefabToSpawn[index];
            Instantiate(spawner, spawnPoint.transform.position, Quaternion.identity);

        }
        
    }

}
