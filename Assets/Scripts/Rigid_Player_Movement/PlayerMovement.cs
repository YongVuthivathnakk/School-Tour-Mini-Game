using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;

    private float xRotation;

    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float Jumpforce = 7f;
    [SerializeField] private float Sensitivity = 2f;


    void Start()
    {
                Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(moveVector.x, PlayerBody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
    }

    // Placeholder for future camera control
    private void MovePlayerCamera()
    {
        xRotation -= playerMouseInput.y * Sensitivity;
        transform.Rotate(0f, playerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
