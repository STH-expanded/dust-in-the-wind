using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private float batteryPowerIncrement = 5.0f;
    [SerializeField] private float batteryPower = 50.0f;

    public GameObject player;
    private const string INCREASE = "increase";
    private const string DECREASE = "decrease";

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && gameObject.GetComponent<Renderer>().enabled) {
            player = other.gameObject.transform.parent.gameObject;
            if (
                (LoadingSystem.loadAmountPlayer1 + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmountPlayer1 < LoadingSystem.maximumLoadAmount) ||
                (LoadingSystem.loadAmountPlayer2 + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmountPlayer2 < LoadingSystem.maximumLoadAmount)
            )
            {
                collectSound.Play();
                LoadAmount(INCREASE, player, batteryPower);
                StartCoroutine(spawnCooldown(3));
            }
        }  
    }

    private void LoadAmount(string method, GameObject player, float increment)
    {
        switch (method)
        {
            case INCREASE:
                Increase(player, increment);
                break;
            case DECREASE:
                Decrease(player, increment);
                break;
        }
    }

    private void Increase(GameObject player, float increment)
    {
        switch (player.name)
        {
            case "Player1":
                LoadingSystem.loadAmountPlayer1 += increment;
                break;
            case "Player2":
                LoadingSystem.loadAmountPlayer2 += increment;
                break;
        }
    }

    private void Decrease(GameObject player, float increment)
    {
        switch (player.name)
        {
            case "Player1":
                LoadingSystem.loadAmountPlayer1 -= increment;
                break;
            case "Player2":
                LoadingSystem.loadAmountPlayer2 -= increment;
                break;
        }
    }

    IEnumerator spawnCooldown(int waitTime )
    {
        Debug.Log("Enter coroutine");
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("set to true");    
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
