using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollectibleCoin : MonoBehaviour
{
    public AudioSource oncoincollect;
    int score = 10;
    public TextMeshProUGUI scoreText;
    public GameObject charModel;
    public GameObject transitionSource;

    void Start()
    {
        StartCoroutine(DecreaseScoreRoutine());
    }

    void OnTriggerEnter(Collider money)
    {
        if (money.gameObject.CompareTag("coin"))
        {
            money.gameObject.SetActive(false);
            oncoincollect.Play();
            score++;
            scoreText.text = "Water: " + score.ToString();
        }
    }

    IEnumerator DecreaseScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (score > 0)
            {
                score--;
                scoreText.text = "Water: " + score.ToString();
            }

            if (score < 1)
            {
                charModel.GetComponent<Animator>().Play("Sweep Fall");
                Invoke("TransitionScene",0.3f);
                Invoke("LoadNextScene",0.6f);
                yield break; 
            }
        }
    }

    void LoadNextScene()
    {  
        SceneManager.LoadScene("End");
    }
    public void TransitionScene()
    {
        transitionSource.SetActive(true);
    }
}
