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
