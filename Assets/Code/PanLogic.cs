using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PanLogic : MonoBehaviour
{

    private float xLastFrame = 0;
    private float xRotation = 0;
    [SerializeField] private float max = 45;
    [SerializeField] private float min = -10;
    private float rBand = 0; 

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        OldMove();
    }

    private void OldMove()
    {
        //Adds 1/5 the difference of where the mouse was last framw to where it is now to the rotation of the pan. 
        xRotation += (Input.mousePosition.y - xLastFrame) / 5;

        //If it wants to rotate the pan beyond the allowed range, corrects it to fall within range.
        if (xRotation > max)
        {
            xRotation = max;
        }
        else if (xRotation < min)
        {
            xRotation = min;
        }

        //Updates the Pan's rotation. 
        this.gameObject.transform.rotation = Quaternion.Euler(xRotation, -180, -90);

        //Saves the current mouse's position for next frame.
        xLastFrame = Input.mousePosition.y;
    }
    
}
