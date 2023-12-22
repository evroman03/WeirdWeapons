using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TempChanger : MonoBehaviour
{
    [SerializeField] int heatToBeApplied = 15;
    private Stopwatch timer = new Stopwatch();

    private GameObject shrimp;
    private CookingMeter cookingMeter;

    // Start is called before the first frame update
    void Start()
    {
        shrimp = GameObject.FindGameObjectWithTag("ShrimpMeter");
        cookingMeter = shrimp.GetComponent<CookingMeter>();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //While the player is within this trigger, applies this temperature to them. 
    void OnTriggerStay(Collider other)
    {
        cookingMeter.ApplyHeat(heatToBeApplied);
    }
}
