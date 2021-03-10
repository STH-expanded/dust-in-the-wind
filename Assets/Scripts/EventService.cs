using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventService : MonoBehaviour
{
    private float timeRemaining = 4;
    public bool timerIsRunning = false;
    public Sprite Three;
    public Sprite Two;
    public Sprite One;
    public Sprite StartGame;
    public Sprite ZeroToDeath;
    public Sprite Out;
    public Sprite Perfect; // For what ?
    public Sprite Player1Win;
    public Sprite Player2Win;

    // Start is called before the first frame update
    private void Start()
    {
        // Starts the timer automatically
        StartCoroutine(Fade(4));
        timerIsRunning = true;
        gameObject.GetComponent<Image>().sprite = Three;
    }

    void Update()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        Timer();
        eventDuringTheMatch();
    }

    void Timer()
    {
        if (timerIsRunning)
        {
            if (timerIsRunning)
            {
                if (timeRemaining < 4 && timeRemaining > 3) 
                {
                    gameObject.GetComponent<Image>().sprite = Three;
                } else if (timeRemaining < 3 && timeRemaining > 2)
                {
                    gameObject.GetComponent<Image>().sprite = Two;
                }
                else if (timeRemaining < 2 && timeRemaining > 1)
                {
                    gameObject.GetComponent<Image>().sprite = One;
                }
                else if (timeRemaining < 1 && timeRemaining > 0)
                {
                    timerIsRunning = false;
                    gameObject.GetComponent<Image>().sprite = StartGame;
                }
                timeRemaining -= Time.deltaTime;
            }
        }
    }

    // TODO: Change this method later to fit the 3 stock of the players (with the sprite Out)
    void eventDuringTheMatch()
    {
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
        if (player1.transform.position.y <= -3)
        {
            GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = Player2Win;
        }
        else if (player2.transform.position.y <= -3)
        {
            GetComponent<Image>().enabled = true;
            gameObject.GetComponent<Image>().sprite = Player1Win;
        }
    }
    
    IEnumerator Fade(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<Image>().enabled = false;
    }
}
