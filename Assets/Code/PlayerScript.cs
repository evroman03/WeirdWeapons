using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 100f;


    private Rigidbody rb;
    private Vector3 moveDirection;
    private PlayerInput playerInput;
    private InputAction moveAction, jumpAction, interactAction, crouchAction, stirAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        interactAction = playerInput.actions.FindAction("Interact");
        crouchAction = playerInput.actions.FindAction("Crouch");
        stirAction = playerInput.actions.FindAction("Stir");


    }
    private void FixedUpdate()
    {
        MovePlayer();
        if (stirAction.IsPressed()) { print("HELLO"); }
    }
    void MovePlayer()
    {
        moveDirection = new Vector3
            (Mathf.Clamp((moveAction.ReadValue<Vector2>().x * moveSpeed), int.MinValue, moveSpeed), 
            0, 
            (Mathf.Clamp((moveAction.ReadValue<Vector2>().y * moveSpeed), int.MinValue, moveSpeed)));
        rb.AddForce(moveDirection);
    }
}
