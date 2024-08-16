using UnityEngine;

public class SecondsTimer : MonoBehaviour
{
    public float timeInSeconds = 30f; 
    private bool timerIsActive = false;


    void Start()
    {
        
        {
            StartCountdown();
        }
    }
    void Update()
    {
        if (timerIsActive)
        {
            if (timeInSeconds > 0)
            {
             
                timeInSeconds -= Time.deltaTime;

                
            }
            else
            {
                Debug.Log("Countdown Finished!");
                timerIsActive = false;
                timeInSeconds = 0;
               
            }
        }
    }

    
    public void StartCountdown()
    {
        timerIsActive = true;
    }
}
