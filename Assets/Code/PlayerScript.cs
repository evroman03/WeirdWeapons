using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] //this script will NOT run without it (it looks for the controller below so otherwise null ref exception)

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private InputManager inputManager; // reference to our input manager script
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance; //Storing the instance so we dont have to call it everytime (a reference)
    }

    void Update()
    {
        //If the player is on the ground and not moving down, set y to 0 just in case
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f; 
        }


        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }



















        /*
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
        }
        */
    }
