
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{


    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;

    private float xRotation;

    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float Jumpforce = 7f;
    [SerializeField] private float Sensitivity = 2f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundMask;
    [HideInInspector] public bool menuOpen = false;

    [HideInInspector] private float minVerticalAngle = -90f; // look down limit
    [HideInInspector] private float maxVerticalAngle = 90f;  // look up limit


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Speed = PlayerPrefs.GetFloat("PlayerSpeed", Speed);
        Sensitivity = PlayerPrefs.GetFloat("CursorSensitivity", Sensitivity);
    }
    void Update()
    {
        if(!menuOpen)
    {
      
        Speed = PlayerPrefs.GetFloat("PlayerSpeed", Speed);
        Sensitivity = PlayerPrefs.GetFloat("CursorSensitivity", Sensitivity);
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    }


    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(moveVector.x, PlayerBody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(GroundCheck.position, 0.1f, GroundMask))
            {
                PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            }
        }
    }

    // Placeholder for future camera control
    private void MovePlayerCamera()
    {
        xRotation -= playerMouseInput.y * Sensitivity;

        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        transform.Rotate(0f, playerMouseInput.x * Sensitivity, 0f);

        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
