using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    private bool isGrounded = true;

    [SerializeField]
    private int playerSpeed = 3;
    
    private Vector3 inputVector;

    [SerializeField]
    private String horizontalAxis;

    [SerializeField]
    private String verticalAxis;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component of Player
        playerBody = GetComponent<Rigidbody>();
    }

    //Refresh at each frame
    void Update()
    {
        // Get Inputs
        inputVector = new Vector3(Input.GetAxis(horizontalAxis) * playerSpeed, playerBody.velocity.y, Input.GetAxis(verticalAxis) * playerSpeed);

        // Face the cube to the looking direction
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder") isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder") isGrounded = false;
    }

    // Refresh at 60 fps
    void FixedUpdate() {
        // Assign inputs to Player
        playerBody.velocity = inputVector;
    }
}
