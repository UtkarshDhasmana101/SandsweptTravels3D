using System.Collections;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{
    public float shieldDuration = 5f;
    ObstacleCollision obstacleScript;
    private GameObject[] cactus;
    public GameObject effectVfx;
    private bool isShieldActive = false;
    public AudioSource aud;

    public float duration = 8f;
    GameObject effectOnPlayer;

    private void Start()
    {
        obstacleScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleCollision>();
        effectOnPlayer = GameObject.FindGameObjectWithTag("Vfx");


        if (effectOnPlayer != null)
        {
            effectOnPlayer.SetActive(false);
        }
    }
    private void Update()
    {
        cactus = GameObject.FindGameObjectsWithTag("cactus");


        foreach (GameObject op in cactus)
        {
            if (isShieldActive)
                op.GetComponent<CapsuleCollider>().enabled = false;
            else
                op.GetComponent<CapsuleCollider>().enabled = true;
        }



    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, Time.time * 120f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aud.Play();
            ActivateShield();
            StartCoroutine(Pickup());
        }
    }

    private void ActivateShield()
    {
        Debug.Log(cactus);

        if (!isShieldActive)
        {
            isShieldActive = true;
            foreach (GameObject op in cactus)
            {
                op.GetComponent<CapsuleCollider>().enabled = false;
            }


            if (obstacleScript != null)
            {
                obstacleScript.enabled = false;
            }

            Invoke("DeactivateShield", shieldDuration);
        }
    }

    private void DeactivateShield()
    {

        isShieldActive = false;


        if (obstacleScript != null)
        {
            obstacleScript.enabled = true;
        }
    }

    private IEnumerator Pickup()
    {
        Instantiate(effectVfx, transform.position, transform.rotation);
        GetComponent<MeshRenderer>().enabled = false;

        if (effectOnPlayer != null)
        {
            effectOnPlayer.SetActive(true);
            yield return new WaitForSeconds(duration);
            effectOnPlayer.SetActive(false);
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Vfx' found in the scene.");
        }


    }
}