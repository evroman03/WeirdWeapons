using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private PanLogic panLogic;
    private GameObject pan;
    Collider o = null;

    bool eligibleToHit = false;


    private void Start()
    {
        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();
    }


    private void Update()
    {
        //If the pan is headed downwards and would hit an enemy, applies damage based on the magnitude of the downward motion of the pan.
        if ((panLogic.headedDown && o != null) && o.GameObject().tag.Equals("Enemy"))
        {
            PepperEnemyScript p = o.gameObject.GetComponent<PepperEnemyScript>();
            p.HP -= panLogic.panShaken * Time.deltaTime;
            Debug.Log(o.gameObject.name + " hit for: " + panLogic.panShaken * Time.deltaTime);
        }
    }


    //Methods for deciding if player is looking at enemy.
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag.Equals("Enemy"))
        {
            o = other;
        }
        eligibleToHit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            o = null;
        }
        eligibleToHit = false;
    }
}
