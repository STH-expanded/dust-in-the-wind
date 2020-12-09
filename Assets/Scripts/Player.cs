using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private float jumpforce = 150f;

    private bool isGrounded = true;

    [SerializeField]
    private int playerSpeed = 2;
    
    [SerializeField]
    private float pushRadius = 90000f;
    
    [SerializeField]
    private float pushAmount = 2000;

    [SerializeField] 
    private float attractAmount = 2000;
    
    [SerializeField] 
    private float attractSpeed = 2;


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
        inputVector = new Vector3(Input.GetAxis("Horizontal") * playerSpeed, playerBody.velocity.y, Input.GetAxis("Vertical") * playerSpeed);

        // Face the cube to the looking direction
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        
        // if (Input.GetButtonDown("Jump") && isGrounded) {
        //     Jump();
        // };
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder")
        {
            isGrounded = true;
        }
    }

    void OnTriggerStay(Collider collider) {
        if (collider.CompareTag("Cube-To-Push"))
        {
            if (Input.GetKeyDown(KeyCode.P)) {
                DoPush(collider);
            }

            if (Input.GetKeyDown(KeyCode.O)) {
                DoAttract(collider);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "mesh_map_placeholder")
        {
            isGrounded = false;
        }
    }

    // Refresh at 60 fps
    void FixedUpdate() {
        // Assign inputs to Player
        playerBody.velocity = inputVector;
    }

    private void Jump()
    {
        playerBody.AddForce(jumpforce * Vector3.up);
    }
            // Vector3 bottom = capcoll


    private void DoPush(Collider collider)
    {
        Rigidbody pushedBody = collider.GetComponent<Rigidbody>();
        pushedBody.AddExplosionForce(pushAmount, Vector3.up, pushRadius);
    }

    private void DoAttract(Collider collider)
    {
        collider.transform.position = Vector3.MoveTowards(collider.transform.position, playerBody.position, attractSpeed * Time.deltaTime);
    }
}
