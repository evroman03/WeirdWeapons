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
        if ((panLogic.headedDown && o != null) && o.GameObject().tag.Equals("Enemy"))
        {
            PepperEnemyScript p = o.gameObject.GetComponent<PepperEnemyScript>();
            p.HP -= panLogic.panShaken * Time.deltaTime;
            Debug.Log("Hit for: " + panLogic.panShaken * Time.deltaTime + " ======================================================");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("==========================INPING============================");
        o = other;
        eligibleToHit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("==========================INPING============================");
        o = null;
        eligibleToHit = false;
    }


    public void changeTemp(int temp)
    {
        Invoke(nameof(resetTemp), 1000);

    }

    private void resetTemp()
    {
        
    }

}
