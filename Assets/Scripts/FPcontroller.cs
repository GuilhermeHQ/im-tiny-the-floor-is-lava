using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPcontroller : MonoBehaviour
{
    public Transform mainCamera;
    float angle = 0;
    public float cameraSpeedX = 10;
    public float cameraSpeedY = -10;
    public float playerSpeed = 3;
    public float playerJump = 5;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // makes cursor disappear
        Cursor.lockState = CursorLockMode.Locked;

        //access player Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate camera in the X angle
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * cameraSpeedX);

        //rotate camera in the Y angle
        angle = Mathf.Clamp(Input.GetAxis("Mouse Y") * cameraSpeedY + angle, -60, 60);
        mainCamera.localRotation = Quaternion.Euler(new Vector3(angle, 0, 0));

        //Movement
        Vector3 velocity = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * playerSpeed;
        velocity.y = Input.GetKeyDown(KeyCode.Space) ? playerJump : playerRigidbody.velocity.y;
        playerRigidbody.velocity = velocity;
    }
}
