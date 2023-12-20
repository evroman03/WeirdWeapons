using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMeter : MonoBehaviour
{
    [SerializeField] private float decayRate = 5;
    GameObject pan = null;
    PanLogic panLogic = null;
    float translate = 0;



    // Start is called before the first frame update
    void Start()
    {
        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        //Increment meter if within desired range. 
        if (Mathf.Abs(this.gameObject.transform.position.y) < 28)
            translate += panLogic.panShaken / 100;

        //Passive meter lowering. 
        translate -= decayRate * Time.deltaTime;

        //Transform shrimp. 
        this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, translate, this.gameObject.transform.position.z);
    }
}
