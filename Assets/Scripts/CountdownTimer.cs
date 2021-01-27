using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float timeRemaining = 4;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Starts the timer automatically
        StartCoroutine(Fade(3));
        timerIsRunning = true;
    }

    void Update()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        if (timerIsRunning)
        {
            if (timeRemaining > 0) 
            {
                timeRemaining -= Time.deltaTime;
                int timeToInt = (int) timeRemaining;
                GetComponent<TextMesh>().text = timeToInt.ToString();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GetComponent<TextMesh>().text = "";
            }
        }
    }
    
    IEnumerator Fade(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Renderer>().enabled = false;
        
    }
}
