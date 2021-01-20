using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetect : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.transform.position.y <= -5 || player2.transform.position.y <= -5)
        {
            Debug.Log("Game ended");
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            LoadingSystem.loadAmount = 0;
        }
    }
}
