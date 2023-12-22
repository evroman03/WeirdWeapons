using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CorpseFizzleOut : MonoBehaviour
{
    Stopwatch sw = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (sw.ElapsedMilliseconds > 5000)
        {
            Destroy(gameObject);
        }
        //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(this.gameObject.GetComponent<MeshRenderer>().material.color.r, this.gameObject.GetComponent<MeshRenderer>().material.color.g, this.gameObject.GetComponent<MeshRenderer>().material.color.b, 100);
    }
}
