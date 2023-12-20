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

    private float acceleration = 0; 

    void Start()
    {

    }

    void Update()
    {
        NewMove();

    }

    private void NewMove()
    {
        if (Input.mousePosition.y - xLastFrame > 0)
        {
            acceleration += 1f;
        }

        if (Input.mousePosition.y - xLastFrame < 0)
        {
            acceleration -= 1f;
        }

        if (Input.mousePosition.y - xLastFrame == 0)
        {
            if (acceleration > 0)
            {
                acceleration -= 0.5f;
            }
            else if (acceleration < 0)
            {
                acceleration += 0.5f;
            }
        }

        xRotation += acceleration;

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

    private void OldMove()
    {
        if (Input.mousePosition.y - xLastFrame > 0)
        {
            acceleration += 1f;
        }

        if (Input.mousePosition.y - xLastFrame < 0)
        {
            acceleration -= 1f;
        }

        if (Input.mousePosition.y - xLastFrame == 0)
        {
            if (acceleration > 0)
            {
                acceleration -= 0.1f;
            }
            else if (acceleration < 0)
            {
                acceleration += 0.1f;
            }
        }

        xRotation += (Input.mousePosition.y - xLastFrame + acceleration) / 5;

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
