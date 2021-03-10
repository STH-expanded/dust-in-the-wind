using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowHitbox : MonoBehaviour
{
    // private Rigidbody hitbox;
    private bool isActive;
    private bool blowDirection;

    private float blowPower = 0;
    private float blowPowerMax = 40;
    private float blowCount = 0;

    [SerializeField] private int blowMultiplier = 1;
    [SerializeField] private float pushActionCost = 0.001f; // Can't go over 1
    [SerializeField] private float pullActionCost = 0.001f; // Can't go over 1

    [SerializeField] private KeyCode blowKey;
    [SerializeField] private KeyCode attractKey;

    [SerializeField] private Rigidbody player;

    private List <Collider> collisionsList = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(blowKey) || Input.GetKey(attractKey))
        {
            isActive = true;
            blowCount++;
        
            if (blowCount <= blowPowerMax * 4)
            {
                blowPower += (0.35f * blowMultiplier);
            }

            if (blowCount > 300 && blowPower > 0)
            {
                blowPower -= (0.125f * blowMultiplier);
            }

            if (Input.GetKey(blowKey))
            {
                if (player.name == "Player1")
                {
                    LoadingSystem.loadAmountPlayer1 -= pushActionCost * LoadingSystem.maximumLoadAmount;
                } else if (player.name == "Player2")
                {
                    LoadingSystem.loadAmountPlayer2 -= pushActionCost * LoadingSystem.maximumLoadAmount;
                }
                
                blowDirection = true;  
            } else if (Input.GetKey(attractKey))
            {
                if (player.name == "Player1")
                {
                    LoadingSystem.loadAmountPlayer1 -= pullActionCost * LoadingSystem.maximumLoadAmount;
                } else if (player.name == "Player2")
                {
                    LoadingSystem.loadAmountPlayer2 -= pullActionCost * LoadingSystem.maximumLoadAmount;
                }
                blowDirection = false;
            }

            collisionsList.ForEach(delegate(Collider collider) {
                LoadAction(collider);
            });
        } else {
            isActive = false;
            blowCount = 0;

            if (blowPower > 0)
            {
                blowPower-= (0.25f * blowMultiplier);
            }
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (!collider.CompareTag("Terrain") && !collider.CompareTag("BlowHitBox"))
        {
            collisionsList.Add(collider);
        }

    }

    void OnTriggerExit(Collider collider) {
        if (!collider.CompareTag("Terrain") && !collider.CompareTag("BlowHitBox"))
        {
            collisionsList.Remove(collider);
        }

    }

    void blowAction(Collider collider) {
        Vector3 playerVector = ((collider.transform.position - player.transform.position) * blowPower) + new Vector3(0, 1, 0) * (blowDirection ? 1 : -1);
        Rigidbody pushedBody = collider.GetComponent<Rigidbody>();
        pushedBody.AddForce(playerVector);
    }

    private void LoadAction(Collider collider)
    {
        switch (player.name)
        {
            case "Player1":
                if (blowDirection && LoadingSystem.loadAmountPlayer1 >= pushActionCost)
                {
                    blowAction(collider);
                }
                else if (!blowDirection && LoadingSystem.loadAmountPlayer1 >= pullActionCost)
                {
                    blowAction(collider);
                }
                break;
            case "Player2":
                if (blowDirection && LoadingSystem.loadAmountPlayer2 >= pushActionCost)
                {
                    blowAction(collider);
                }
                else if (!blowDirection && LoadingSystem.loadAmountPlayer2 >= pullActionCost)
                {
                    blowAction(collider);
                }
                break;
        }
    }

}
