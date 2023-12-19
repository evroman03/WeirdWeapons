using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private float movementAD;
    private float moveSpeed;

    Rigidbody rb;
    private PlayerControls controls;


    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.ShrimpActionMap.Move.performed += ctx => movementAD = ctx.ReadValue<float>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(movementAD, 0, 0);
    }
}
