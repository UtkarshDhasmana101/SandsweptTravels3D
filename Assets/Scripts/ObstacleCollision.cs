using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject transitionSource;
    public float NextScn = 2f;
    public GameObject charModel;
    public AudioSource aud;
    void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.tag == "cactus")
        {
            aud.Play();
           charModel.GetComponent<Animator>().Play("Sweep Fall");
            Invoke("TransitionScene", 0);
            Invoke("NextsScene", NextScn);
        }
    }

    public void TransitionScene()
    {
        transitionSource.SetActive(true);
    }
        public void NextsScene()
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

}


    