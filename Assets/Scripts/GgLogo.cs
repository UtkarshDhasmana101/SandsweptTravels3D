using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GgLogo : MonoBehaviour
{
    public GameObject transition1;

     void Start()
    {
        Invoke("TransitionScn", 2f);
        Invoke("NxtScn", 3.5f);
    }


    public void TransitionScn()
    {
        transition1.SetActive(true);
    }
    public void NxtScn()
    {
        SceneManager.LoadSceneAsync("ssname");
    }
}
