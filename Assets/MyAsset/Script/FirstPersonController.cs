using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FirstPersonController : NetworkBehaviour
{
    public float mouseSensitivity = 2.0f;
    private float verticalRotation = 0;
    public float movementSpeed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    public float jumpForce = 5.0f;
    public float gravity = 9.8f;
    Camera mainCam;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            transform.Rotate(0, mouseX, 0);

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
            mainCam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
            float vertical = Input.GetAxis("Vertical") * movementSpeed;


            if (characterController.isGrounded)

            {
                moveDirection = new Vector3(horizontal, 0, vertical);
                moveDirection = transform.TransformDirection(moveDirection);
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }

    }
}
