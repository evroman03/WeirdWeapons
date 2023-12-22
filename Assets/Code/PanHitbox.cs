using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private PanLogic panLogic;
    private GameObject pan;


    private void Start()
    {
        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (panLogic.headedDown && other.GameObject().tag.Equals("Enemy"))
        {
            PepperEnemyScript p = other.gameObject.GetComponent<PepperEnemyScript>();
            p.HP -= panLogic.panShaken * Time.deltaTime;
            Debug.Log("Hit for: " + panLogic.panShaken * Time.deltaTime + " ======================================================");
        }
    }

}
