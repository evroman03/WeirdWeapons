using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed, gravityValue, jumpHeight, dragGround, dragAir, deadZone;
    [SerializeField] private bool isCrouching, isGrounded;

    private PlayerControls playerControls;
    private float yRotation;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 movement;


    private void Start()
    {
        Cursor.visible= false;
        moveSpeed = 10;
        gravityValue = -9.81f;
        jumpHeight = 5f;
        deadZone = 0;
        dragGround = 3.5f;
        dragAir = -0.25f;
        isCrouching = false;
        isGrounded = true;


        rb = GetComponent<Rigidbody>();

        playerControls = new PlayerControls();
        playerControls.ShrimpActionMap.Enable();

        playerControls.ShrimpActionMap.Crouch.performed += ctx => Crouch();
        playerControls.ShrimpActionMap.Jump.performed += ctx => Jump();
        playerControls.ShrimpActionMap.Interact.performed += ctx => Interact();

        playerControls.ShrimpActionMap.Move.performed += ctx => movement =ctx.ReadValue<Vector2>();
        playerControls.ShrimpActionMap.Move.canceled += ctx => movement = Vector3.zero;

        playerControls.ShrimpActionMap.Look.performed += ctx => yRotation += ctx.ReadValue<Vector2>().x;
    }
    private void Crouch()
    {
        
    }
    
    private void Jump()
    {
        if (isGrounded) 
        { 
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //Make sure the jump is the same every time
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse); //Use forcemode impulse because its a one-time addition of force
        }
    }
    private void Interact()
    {
        print("HELLO3");
    }
    private void SpeedLimit()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized* moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
    void MovePlayer()
    {
        /*
        moveDirection = new Vector3
            (Mathf.Clamp((movement.x * moveSpeed), int.MinValue, moveSpeed), 
            moveDirection.y, 
            (Mathf.Clamp((movement.y * moveSpeed), int.MinValue, moveSpeed)));
        */
        moveDirection = transform.forward * movement.y + transform.right* movement.x;

        if (isGrounded) { rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force); }
        else { rb.AddForce(moveDirection.normalized, ForceMode.Force); } //Take this line out if you dont want to be able to move in midair
    }
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, ((transform.localScale.y * .5f) + 0.25f));


        if (isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0f;
        }
        else
        {
            moveDirection.y += gravityValue * Time.deltaTime;
        }
        if(yRotation > deadZone || yRotation < -deadZone)
        {
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            print(yRotation);
        }
       
        MovePlayer();
        SpeedLimit();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
            rb.drag = dragGround;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            isGrounded = false;
            rb.drag = dragAir;
        }
    }
}
