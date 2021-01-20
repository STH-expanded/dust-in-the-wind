using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetect : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -5)
        {
            // Console.Log("Game ended");
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            LoadingSystem.loadAmount = 0;
        }
    }
}
