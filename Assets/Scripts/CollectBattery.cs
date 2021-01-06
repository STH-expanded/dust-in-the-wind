using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private float batteryPowerIncrement = 5.0f;
    [SerializeField] private float batteryPower = 50.0f;
    private float elapsed = 0f;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item collected");
        if (LoadingSystem.loadAmount + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmount < LoadingSystem.maximumLoadAmount)
        {
            collectSound.Play();
            IncreaseLoadAmount(batteryPower);
            Destroy(gameObject);
        }
    }

    private void IncreaseLoadAmount(float increment)
    {
        LoadingSystem.loadAmount += increment;
    }

    private void DecreaseLoadAmount(float increment)
    {
        LoadingSystem.loadAmount += increment;
    }
}
