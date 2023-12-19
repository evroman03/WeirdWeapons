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
    private InputAction moveAction;

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
        moveDirection = new Vector3(moveAction.ReadValue<Vector2>().x*moveSpeed, 0, moveAction.ReadValue<Vector2>().y * moveSpeed);
        rb.AddForce(moveDirection);
        print(moveAction.ReadValue<Vector2>());
    }
}
