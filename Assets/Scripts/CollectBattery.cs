using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private float batteryPowerIncrement = 5.0f;
    [SerializeField] private float batteryPower = 50.0f;
    private float elapsed = 0f;
    private int timer = 200;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && gameObject.GetComponent<Renderer>().enabled == true) {
            if (LoadingSystem.loadAmount + batteryPower <= LoadingSystem.maximumLoadAmount || LoadingSystem.loadAmount < LoadingSystem.maximumLoadAmount)
            {
                collectSound.Play();
                IncreaseLoadAmount(batteryPower);
                // Destroy(gameObject);
                StartCoroutine(spawnCooldown(3));
            }
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

    IEnumerator spawnCooldown(int waitTime )
    {
        Debug.Log("Enter coroutine");
        gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        Debug.Log("set to true");    
        gameObject.GetComponent<Renderer>().enabled = true;
    }
}
