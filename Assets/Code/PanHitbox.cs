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
        pan = GameObject.FindGameObjectWithTag("PanHitbox");
        panLogic = pan.GetComponent<PanLogic>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (panLogic.headedDown && other.GameObject().tag.Equals("Enemy"))
        {
            other.gameObject.GetComponent<PepperEnemyScript>().HP -= panLogic.panShaken;
        }
    }

}
