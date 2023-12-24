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
    private PlayerScript pS;

    private float xLastFrame = 0;
    private float xRotation = 0;
    [SerializeField] private float max = 45;
    [SerializeField] private float min = -10;

    //Publicly accessible values.
    public float panShaken = 0;
    public bool headedDown = false;

    void Start()
    {
        Cursor.visible = false;
        if(GameObject.FindGameObjectWithTag("Player")!=null)
        {
            pS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        }
    }

    void Update()
    {
        OldMove();
    }

    private void OldMove()
    {
        //Updates panShaken for the meter. 
        //panShaken = Mathf.Abs(Input.mousePosition.y - xLastFrame);
        panShaken = Mathf.Abs(pS.YMouse - xLastFrame);
        //Adds 1/5 the difference of where the mouse was last framw to where it is now to the rotation of the pan. 
        //xRotation += (Input.mousePosition.y - xLastFrame) / 5;
        xRotation += (pS.YMouse - xLastFrame) * .5f;



        if (pS.YMouse - xLastFrame < 0)
        {
            headedDown = true;
        }
        else
        {
            headedDown = false;
        }

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
        //xLastFrame = Input.mousePosition.y;
        xLastFrame = pS.YMouse;
    }
    
}
