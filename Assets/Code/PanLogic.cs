using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PanLogic : MonoBehaviour
{

    private float xLastFrame = 0;
    private float xRotation = 0;
    [SerializeField] private float max = 45;
    [SerializeField] private float min = -10;
    private bool headedUp = false;
    private bool headedDown = false;

    private float acceleration = 0; 

    void Start()
    {

    }

    void Update()
    {
        if (Input.mousePosition.y - xLastFrame > 0 && headedUp == true)
        {
            acceleration += 0.1f;
        }
        else if (Input.mousePosition.y - xLastFrame > 0 && headedUp == false)
        {
            acceleration = 0f;
            headedUp = true;
            headedDown = false;
        }

        if (Input.mousePosition.y - xLastFrame < 0 && headedDown == true)
        {
            acceleration += 0.1f;
        }
        else if (Input.mousePosition.y - xLastFrame < 0 && headedDown == false)
        {
            acceleration = 0f;
            headedUp = false;
            headedDown = true;
        }

        xRotation += (Input.mousePosition.y - xLastFrame) / 5; 

        if (xRotation > max)
        {
            xRotation = max;
        }
        else if (xRotation < min)
        {
            xRotation = min;
        }

        this.gameObject.transform.rotation = Quaternion.Euler(xRotation, -180, -90);
        xLastFrame = Input.mousePosition.y;

    }

    
}
