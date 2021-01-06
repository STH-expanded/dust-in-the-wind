using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private float jumpforce = 150f;

    private bool isGrounded = true;

    [SerializeField]
    private int playerSpeed = 3;
    
    [SerializeField]
    private float pushRadius = 90000f;
    
    [SerializeField]
    private float pushAmount = 2000;

    [SerializeField] 
    private float attractAmount = 2000;
    
    [SerializeField] 
    private float attractSpeed = 2;


    private Vector3 inputVector;

    private const String pushAction = "pushAction";
    private float pushActionCost = 0.2f; // Can't go over 1
    private const String pullAction = "pullAction";
    private float pullActionCost = 0.2f; // Can't go over 1

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        inputVector = new Vector3(horizontalInput * playerSpeed, playerBody.velocity.y, verticalInput * playerSpeed);

        // Face the cube to the looking direction
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        // if (Input.GetButtonDown("Jump") && isGrounded) {
        //     Jump();
        // };

        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadAction(pushAction)
        }

        if (Input.GetKey(KeyCode.O))
        {
            DoAttract();
        }
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

    private void Jump()
    {
        playerBody.AddForce(jumpforce * Vector3.up);
    }

    private void LoadAction(String action)
    {
        switch (action)
        {
            case pushAction:
                if (LoadingSystem.loadAmount >= pushActionCost)
                {
                    LoadingSystem.loadAmount -= pushActionCost * LoadingSystem.maximumLoadAmount;
                    DoPush();
                }
                break;
            case pullAction:
                if (LoadingSystem.loadAmount >= pushActionCost)
                {
                    LoadingSystem.loadAmount -= pullActionCost * LoadingSystem.maximumLoadAmount;
                    // DoPull();
                }
                break;
        }
    }

    private void DoPush()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cube-To-Push"))
            {
                Rigidbody pushedBody = collider.GetComponent<Rigidbody>();
                pushedBody.AddExplosionForce(pushAmount, Vector3.up, pushRadius);
            }
        }

    }

    private void DoAttract()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Cube-To-Push"))
            {
                collider.transform.position = Vector3.MoveTowards(collider.transform.position, playerBody.position,
                    attractSpeed * Time.deltaTime);
            }
        }
    }
}
