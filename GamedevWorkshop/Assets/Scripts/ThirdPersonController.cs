//John Bowditch 2023.09.26 - Third Person Controller based on Rigid Bodies

//Using denotes Libraries that we're referencing
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{

    //Variable Declarations

    // Input Variables
    private Vector2 move_input;

    //Camera Variables
    public Transform camera;

    // Player Variables 
    public Rigidbody rigidbody;
    public Transform player;
    public Transform player_model;
    public Transform orientation;
    public float move_force; //Force applied to player
    public float rotation_speed; //How fast model rotates
    private Vector3 direction;
    public float jumpForce = 5f;
    private float ray_length = 1.1f;






    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * ray_length, Color.blue);
        RotatePlayerModel();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    public void GetMovementInput(InputAction.CallbackContext context)
    {

        move_input = context.ReadValue<Vector2>();

    }

    public void GetJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Jump();
        }
    }

    public void RotatePlayerModel()
    {
        //What direction to face

        var cam_position = new Vector3(camera.position.x, camera.position.y, camera.position.z);
        Vector3 view_direction = player.position - cam_position;

        orientation.forward = view_direction;

        //Set the direction
        direction = orientation.right * move_input.x + orientation.forward * move_input.y;
        direction = direction.normalized;

        //Keyboard Input

        if(move_input != Vector2.zero)
        {
            Quaternion new_rotation = Quaternion.LookRotation(direction, Vector3.up);

            player_model.rotation = Quaternion.Slerp(player_model.rotation, new_rotation, rotation_speed*Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (isGrounded())
        {
            Debug.Log("Jump");
            rigidbody.AddForce(Vector3.up * jumpForce*10);

        }
    }

    public void MovePlayer()
    {
        Debug.Log("move");
        rigidbody.AddForce(direction * move_force, ForceMode.VelocityChange);
    }

    private bool isGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, ray_length);
    }
}
