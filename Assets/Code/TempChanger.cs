using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TempChanger : MonoBehaviour
{

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

    void OnTriggerStay(Collider other)
    {
        if (timer.ElapsedMilliseconds > 500)
        {
            cookingMeter.heat = 15;
            Invoke(nameof(resetTemp), 1000);
        }

    }

    void resetTemp()
    {
        cookingMeter.heat = 0;
    }
}
