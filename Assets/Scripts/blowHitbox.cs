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
    private float blowPowerMax = 20;
    private float blowCount = 0;
    [SerializeField] private float pushActionCost = 0.05f; // Can't go over 1
    [SerializeField] private float pullActionCost = 0.05f; // Can't go over 1

    [SerializeField] private KeyCode blowKey;
    [SerializeField] private KeyCode attractKey;

    [SerializeField] private Rigidbody player;

    private List <Collider> collisionsList = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        //hitbox = GetComponent<Rigidbody>();
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
                blowPower += 0.25f;
            }

            if (blowCount > 300 && blowPower > 0)
            {
                blowPower -= 0.125f;
            }

            if (Input.GetKey(blowKey))
            {
                blowDirection = true;  
            } else if (Input.GetKey(attractKey))
            {
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
                blowPower-= 0.25f;
            }
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Cube-To-Push"))
        {
            collisionsList.Add(collider);
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Cube-To-Push"))
        {
            collisionsList.Remove(collider);
        }
    }

    void blowAction(Collider collider) {
        Vector3 playerVector = ((collider.transform.position - player.transform.position) * blowPower * (blowDirection ? 1 : -1));
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
                    LoadingSystem.loadAmountPlayer1 -= pushActionCost * LoadingSystem.maximumLoadAmount;
                    blowAction(collider);
                }
                else if (!blowDirection && LoadingSystem.loadAmountPlayer1 >= pullActionCost)
                {
                    LoadingSystem.loadAmountPlayer1 -= pullActionCost * LoadingSystem.maximumLoadAmount;
                    blowAction(collider);
                }
                break;
            case "Player2":
                if (blowDirection && LoadingSystem.loadAmountPlayer2 >= pushActionCost)
                {
                    LoadingSystem.loadAmountPlayer2 -= pushActionCost * LoadingSystem.maximumLoadAmount;
                    blowAction(collider);
                }
                else if (!blowDirection && LoadingSystem.loadAmountPlayer2 >= pullActionCost)
                {
                    LoadingSystem.loadAmountPlayer2 -= pullActionCost * LoadingSystem.maximumLoadAmount;
                    blowAction(collider);
                }
                break;
        }
    }

}
