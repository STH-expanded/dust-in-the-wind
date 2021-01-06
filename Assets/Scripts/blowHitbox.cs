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

    [SerializeField]
    private Rigidbody player;

    private List <Collider> collisionsList = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        //hitbox = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.O)) {
            isActive = true;
            blowCount++;
        
            if (blowCount <= blowPowerMax * 4) {
                blowPower += 0.25f;
            }

            if (blowCount > 300 && blowPower > 0) {
                blowPower -= 0.125f;
            }

            if (Input.GetKey(KeyCode.P)) {
                blowDirection = true;  
            } else if (Input.GetKey(KeyCode.O)) {
                blowDirection = false;
            }
            
            collisionsList.ForEach(delegate(Collider collider) {
                    Vector3 playerVector = ((collider.transform.position - player.transform.position) * blowPower * (blowDirection ? 1 : -1));
                    Rigidbody pushedBody = collider.GetComponent<Rigidbody>();
                    pushedBody.AddForce(playerVector);
            });
        } else {
            isActive = false;
            blowCount = 0;

            if (blowPower > 0) {
                blowPower-= 0.25f;
            }
        }

        Debug.Log(blowPower);
        Debug.Log(blowCount);
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
}
