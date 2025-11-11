using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
public float mouseSensitivity = 300f;

    float xRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f; 


    // Start is called before the first frame update
    void Start()
    {
        // Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the x axis (Look up and down)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotation around the y axis (Look left and right)


        // Apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
