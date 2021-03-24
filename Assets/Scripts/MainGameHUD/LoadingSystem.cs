using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSystem : MonoBehaviour
{
    [SerializeField] public Slider loadingSliderPlayer1;
    [SerializeField] public Slider loadingSliderPlayer2;
    [SerializeField] public static int reloadTime = 500; // in ms
    [SerializeField] public static float startingLoadAmount = 20.0f;
    [SerializeField] public static float maximumLoadAmount = 100.0f;

    public static float loadAmountPlayer1;
    public static float loadAmountPlayer2;

    void Start()
    {
        setStartingPower(startingLoadAmount);
    }

    void Update()
    {

        loadingSliderPlayer1.value = loadAmountPlayer1 / maximumLoadAmount;
        loadingSliderPlayer2.value = loadAmountPlayer2 / maximumLoadAmount;

        if (loadingSliderPlayer1.value == 1)
        {
            Debug.Log("Player 1 - Max power");
        }

        if (loadingSliderPlayer2.value == 1)
        {
            Debug.Log("Player 2 - Max power");
        }
    }

    private void setStartingPower(float amount)
    {
        loadingSliderPlayer1.value = amount / maximumLoadAmount;
        loadingSliderPlayer2.value = amount / maximumLoadAmount;
    }

}
