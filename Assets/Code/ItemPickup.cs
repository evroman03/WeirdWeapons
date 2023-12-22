using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private AudioSource pickupSFX;
    [SerializeField] private GameObject eToPickUp;

    bool canBePickedUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If player falls within desired range of object and presses E, it can be picked up. 
        if (canBePickedUp && Input.GetKeyDown(KeyCode.E))
        {
            //If item picked up is a rice bag.
            if (this.gameObject.tag.Equals("RiceBag"))
            {
                GameObject.FindGameObjectWithTag("ShrimpMeter").GetComponent<CookingMeter>().HP += 5;
            }
            pickupSFX.Play();

            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }


    //For detecting when the player is in valid range of the object.
    private void OnTriggerEnter(Collider other)
    {
        canBePickedUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canBePickedUp = false;
    }
}
