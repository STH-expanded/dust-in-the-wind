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
        Debug.Log("Item collected");

        player = other.gameObject.transform.parent.gameObject;
        if (
            (LoadingSystem.loadAmountPlayer1 + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmountPlayer1 < LoadingSystem.maximumLoadAmount) ||
            (LoadingSystem.loadAmountPlayer2 + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmountPlayer2 < LoadingSystem.maximumLoadAmount)
        )
        {
            collectSound.Play();
            LoadAmount(INCREASE, player, batteryPower);
            Destroy(gameObject);
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
}
