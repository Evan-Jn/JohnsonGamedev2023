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
    private float predictedHeight;
    private Vector3 moveVector;

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
        Look();
    }
    private void FixedUpdate()
    {
        MovePlayer();

    }

    public void MovePlayer()
    {
        float influence;

        if (!grounded || playerVelocity.y > 0f)
        {
            playerVelocity.y += gravity * Time.deltaTime;
            influence = 0.03f;
        } else
        {

            playerVelocity.y = -2.5f;
            influence = 0.3f;
        }

        Vector3 desiredDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        moveVector = Vector3.Lerp(moveVector, desiredDirection, influence);

        characterController.Move((moveVector*speed + playerVelocity) * Time.deltaTime);

    }

    public void Look()
    {
        float xAmmount;
        float yAmmount;
        xAmmount = mouseMovement.x * sensitivity * 0.1f;
        yAmmount = mouseMovement.y * sensitivity * 0.1f;
        transform.Rotate(Vector3.up * xAmmount);
        cam_x_rotation -= yAmmount;
        cam_x_rotation = Mathf.Clamp(cam_x_rotation, -80f, 80f);
        Camera.main.transform.localEulerAngles = new Vector3(cam_x_rotation, 0f, 0f);
    }

    public void OnMove(InputAction.CallbackContext context) 
    { 
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log("MoveInput: " + moveInput.ToString());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseMovement = context.ReadValue<Vector2>();
        //Debug.Log("MouseMovement Raw: " + mouseMovement.ToString());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Jump();
        }
        
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = jumpForce;
        }
    }
}
