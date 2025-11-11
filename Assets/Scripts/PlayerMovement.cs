using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 6f;          // Normal walking speed
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    // bool isMoving;
    private Vector3 lastPosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset vertical velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate base speed
        float currentSpeed = speed;

        // If Shift is held, double the speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= 2.5f;
        }

        // Calculate movement direction
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply horizontal movement
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement (jump/fall)
        controller.Move(velocity * Time.deltaTime);

        // Detect movement
        // if (lastPosition != transform.position && isGrounded)
        //     isMoving = true;
        // else
        //     isMoving = false;

        // lastPosition = transform.position;
    }
}
