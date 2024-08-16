using System.Collections;
using UnityEngine;

public class CarpetPup : MonoBehaviour
{
    public GameObject carpetPrefab;
    public GameObject effectForCarpet;
    GameObject playerRef;
    public float durations = 10f;

   void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CarpetPickup());
        }
    }

   IEnumerator CarpetPickup()
    {
        playerRef.SetActive(false);
        Instantiate(effectForCarpet, transform.position, transform.rotation);
        Vector3 spawnPosition = playerRef.transform.position + new Vector3(0, 5f, 0);
        Quaternion spawnRotation = Quaternion.Euler(0, -90, 0);
        GameObject carpetInstance = Instantiate(carpetPrefab, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(durations);
        carpetInstance.SetActive(false);
        playerRef.SetActive(true);
        gameObject.SetActive(false);

    }
}
