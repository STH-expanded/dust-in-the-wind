using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private Collider distanceToTheGround;

    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of Player
        playerBody = GetComponent<Rigidbody>();
        distanceToTheGround = GetComponent<Collider>();
    }

    // Update is called once per frame

    //Refresh at each frame
    void Update()
    {
        // Get Inputs
        inputVector = new Vector3(Input.GetAxis("Horizontal")*2, playerBody.velocity.y, Input.GetAxis("Vertical")*2);

        // Face the cube to the looking direction
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
        if (Input.GetButtonDown("Jump")) {
            Jump();
        };
    }

    // Refresh at 60 fps
    void FixedUpdate() {
        // Assign inputs to Player
        playerBody.velocity = inputVector;
    }

    private void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanceToTheGround.bounds.extents.y + 0.1f)) {
            inputVector = new Vector3(Input.GetAxis("Horizontal")*2, 2, Input.GetAxis("Vertical")*2);
        }
    }

    private void OnCollisionStay(Collision col) {
        foreach(ContactPoint p in col.contacts) {
        }
    }
            // Vector3 bottom = capcoll
}
