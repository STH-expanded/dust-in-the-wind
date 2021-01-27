using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSystem : MonoBehaviour
{
    [SerializeField] public Slider loadingSlider;
    [SerializeField] public static int reloadTime = 500; // in ms
    [SerializeField] public static float maximumLoadAmount = 100.0f;
    public static float loadAmount;
    

    void Update()
    {
        loadingSlider.value = loadAmount / maximumLoadAmount;
        if (loadingSlider.value == 1)
        {
            // Debug.Log("Max power");
        }
    }

}
