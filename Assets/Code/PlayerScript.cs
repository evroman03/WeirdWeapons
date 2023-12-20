using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private bool isCrouching = false;

    private PlayerControls playerControls;


    private Rigidbody rb;
    private Vector3 moveDirection;
    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerControls = new PlayerControls();
        playerControls.ShrimpActionMap.Enable();

        playerControls.ShrimpActionMap.Crouch.performed += ctx => Crouch();
        playerControls.ShrimpActionMap.Jump.performed += ctx => Jump();
        playerControls.ShrimpActionMap.Interact.performed += ctx => Interact();

        moveAction = playerInput.actions.FindAction("Move");

    }
    private void Crouch()
    {
        if(!isCrouching)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y,transform.localScale.y/2, 1), transform.localScale.z);
            isCrouching=true;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(transform.localScale.y, transform.localScale.y * 2, 1), transform.localScale.z);
            isCrouching =false;
        }
    }
    private void Jump()
    {
        print("HELLO2");
    }
    private void Interact()
    {
        print("HELLO3");
    }

    void MovePlayer()
    {
        moveDirection = new Vector3
            (Mathf.Clamp((moveAction.ReadValue<Vector2>().x * moveSpeed), int.MinValue, moveSpeed), 
            0, 
            (Mathf.Clamp((moveAction.ReadValue<Vector2>().y * moveSpeed), int.MinValue, moveSpeed)));
        rb.AddForce(moveDirection);
    }
    private void FixedUpdate()
    {
        MovePlayer();
        //if (stirAction.ReadValue<bool>() { print("HELLO"); }
    }
}
