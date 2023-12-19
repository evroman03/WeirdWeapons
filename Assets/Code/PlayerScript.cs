using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] private float moveSpeed = 100f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Start()

    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        moveDirection = new Vector3(direction.x*moveSpeed, 0, 0);
        rb.AddForce(moveDirection);
        print(moveAction.ReadValue<Vector2>());
    }
}
