using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator firstTransition;
    public AudioSource ads;
    public void StrtGame()
    {
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {

        firstTransition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("startvideo");
    }
}
