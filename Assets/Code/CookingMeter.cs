using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingMeter : MonoBehaviour
{
    [SerializeField] private float decayRate = 5;
    GameObject pan = null;
    PanLogic panLogic = null;

    [SerializeField] private GameObject HPBAR = null;
    [SerializeField] int HP = 10; 

    float translate = 0;

    Stopwatch Stopwatch = new Stopwatch();


    public int heat = 0;

    // Start is called before the first frame update
    void Start()
    {
        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();

        Stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Increment meter if within desired range. 
        if (this.gameObject.transform.position.y < 28)
            translate += panLogic.panShaken / 100;

        //Passive meter lowering. 
        if (this.gameObject.transform.position.y > -28)
            translate -= decayRate * Time.deltaTime;

        //Heat Management 
        if ((this.gameObject.transform.position.y < 28 && heat > 0) || (this.gameObject.transform.position.y > -28 && heat < 0))
            translate += heat * Time.deltaTime;

        if (Mathf.Abs(this.gameObject.transform.position.y) >= 28 && Stopwatch.ElapsedMilliseconds > 500)
        {
            Stopwatch.Restart();
            HP--;
            HPBAR.GetComponent<TextMeshProUGUI>().text = "HP: " + HP;
        }

        if (HP == 0)
        {
            SceneManager.LoadScene("DeathRobbie");
        }


        //Transform shrimp. 
        this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, translate, this.gameObject.transform.position.z);
    }
}
