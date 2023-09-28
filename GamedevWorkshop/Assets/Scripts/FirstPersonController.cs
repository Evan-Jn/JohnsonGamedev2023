/***
John Bowditch 2023.09.12 
Script for basic first person character and camera controls

***/


//Libraries that we're using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{

    //Player Variables
    public float speed = 2.0f;
    public float gravity = -10.0f;
    public float jumpForce = 2.0f;

    //Movement and Looking Variables
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 playerVelocity;
    private bool grounded;
    private Vector2 mouseMovement;

    //Camera Variables
    public Camera cameraLive;
    public float sensitivity = 25.0f;
    private float cam_x_rotation;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }


        // Update is called once per frame
    void Update()
    {
        grounded = characterController.isGrounded;
        MovePlayer();
        Look();
    }

    public void MovePlayer()
    {
        Vector3 moveVector = transform.right * moveInput.x + transform.forward * moveInput.y;
        characterController.Move((moveVector*speed + playerVelocity)*Time.deltaTime);
        if (grounded)
        {
            playerVelocity.y += gravity * Time.deltaTime;
        } else
        {
            playerVelocity.y = -2.5f;
        }
    }

    public void Look()
    {
        float xAmmount;
        float yAmmount;
        xAmmount = mouseMovement.x * sensitivity;
        yAmmount = mouseMovement.y * sensitivity;
        transform.Rotate(Vector3.up * mouseMovement.x);
    }

    public void OnMove(InputAction.CallbackContext context) 
    { 
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log("MoveInput: " + moveInput.ToString());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseMovement = context.ReadValue<Vector2>();
        Debug.Log("MouseMovement Raw: " + mouseMovement.ToString());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = jumpForce;
        }
    }
}
