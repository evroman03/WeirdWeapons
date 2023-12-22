using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    [SerializeField] private GameObject eToPickUp;

    bool canBePickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canBePickedUp && Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.tag.Equals("RiceBag"))
            {
                GameObject.FindGameObjectWithTag("ShrimpMeter").GetComponent<CookingMeter>().HP += 5;
            }


            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        canBePickedUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canBePickedUp = false;
    }
}
