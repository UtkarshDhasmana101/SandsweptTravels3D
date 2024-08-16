using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartVideo : MonoBehaviour
{
    public GameObject transition2;

    void Start()
    {
        Invoke("TransitionScnn", 3f);
        Invoke("NxtScnn", 4f);
    }


    public void TransitionScnn()
    {
        transition2.SetActive(true);
    }
    public void NxtScnn()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}

