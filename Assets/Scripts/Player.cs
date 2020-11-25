using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private float jumpforce = 150f;

    private bool isGrounded = true;

    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of Player
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    //Refresh at each frame
    void Update()
    {
        // Get Inputs
        inputVector = new Vector3(Input.GetAxis("Horizontal")*2, playerBody.velocity.y, Input.GetAxis("Vertical")*2);

        // Face the cube to the looking direction
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        };
    }

    // Refresh at 60 fps
    void FixedUpdate() {
        // Assign inputs to Player
        playerBody.velocity = inputVector;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder")
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        playerBody.AddForce(jumpforce * Vector3.up);
    }
            // Vector3 bottom = capcoll
}
