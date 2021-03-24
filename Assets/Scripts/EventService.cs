using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventService : MonoBehaviour
{
    private float timeRemaining = 4;
    public bool timerIsRunning = false;
    public Sprite Three;
    public Sprite Two;
    public Sprite One;
    public Sprite StartGame;
    public Sprite Out;
    public Sprite Player1Win;
    public Sprite Player2Win;

    private object startPositionPlayer1;
    private object startPositionPlayer2;

    [SerializeField] private Player player1;
    [SerializeField] private Player player2;

    private int player1Life = 2;
    private int player2Life = 2;
    private Image _image;

    // Start is called before the first frame update
    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _image.enabled = true;
        _image.sprite = Three;
        // Starts the timer automatically
        StartCoroutine(Fade(4));
        timerIsRunning = true;
        
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
                    _image.sprite = Three;
                } else if (timeRemaining < 3 && timeRemaining > 2)
                {
                    _image.sprite = Two;
                }
                else if (timeRemaining < 2 && timeRemaining > 1)
                {
                    _image.sprite = One;
                }
                else if (timeRemaining < 1 && timeRemaining > 0)
                {
                    timerIsRunning = false;
                    _image.sprite = StartGame;
                }
                timeRemaining -= Time.deltaTime;
            }
        }
    }
    
    void eventDuringTheMatch()
    {
        startPositionPlayer1 = player1.startPosition;
        startPositionPlayer2 = player2.startPosition;

        if (player1.transform.position.y <= -3)
        {
            if (player1Life > 0)
            {
                _image.enabled = true;
                _image.sprite = Out;
                StartCoroutine(Fade(1));
                
                player1.transform.position = (Vector3) startPositionPlayer1;
                
                player1Life--;
            } 
            else 
            {
                gameObject.GetComponent<Image>().sprite = Player2Win;
                GetComponent<Image>().enabled = true;
            }
        }
        
        else if (player2.transform.position.y <= -3)
        {
            if (player2Life > 0)
            {
                _image.enabled = true;
                _image.sprite = Out;
                StartCoroutine(Fade(1));
                
                player2.transform.position = (Vector3) startPositionPlayer2;
                
                player2Life--;
            } 
            else 
            {
                _image.sprite = Player1Win;
                _image.enabled = true;
            }
        }
        
        endGame();
    }
    
    IEnumerator Fade(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _image.enabled = false;
    }

    void endGame()
    {
        if (player1.transform.position.y <= -20 || player2.transform.position.y <= -20)
        {
            if (player1Life == 0 || player2Life == 0)
            {
                Debug.Log("Game ended");
                SceneManager.LoadScene("EndGame", LoadSceneMode.Additive);
                LoadingSystem.loadAmountPlayer1 = 0;
                LoadingSystem.loadAmountPlayer2 = 0;
            }
        }
    }
}
