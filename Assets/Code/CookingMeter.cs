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
    public float HP = 10;
    private float maxHP;

    float translate = 0;

    Stopwatch Stopwatch = new Stopwatch();

    Stopwatch cooldownTimer = new Stopwatch();


    public int heat = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;

        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();

        Stopwatch.Start();
        cooldownTimer.Start();
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

        //If temp gague too high or low, damages player. 
        if (Mathf.Abs(this.gameObject.transform.position.y) >= 28 && Stopwatch.ElapsedMilliseconds > 500)
        {
            Stopwatch.Restart();
            HP--;
        }

        //Adjusts rice meter accordingly.
        HPBAR.GetComponent<RectTransform>().sizeDelta = new Vector2(HPBAR.GetComponent<RectTransform>().sizeDelta.x, 100 * (HP / maxHP));

        //If player health <= 0, kills player. 
        if (HP == 0)
        {
            SceneManager.LoadScene("DeathRobbie");
        }

        //Transform shrimp. 
        this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, translate, this.gameObject.transform.position.z);
    }

    //Method accessible to outsiders to modify the rate at which the shrimp heats / cools
    public void ApplyHeat(int temp)
    {
        if (cooldownTimer.ElapsedMilliseconds > 500)
        {
            cooldownTimer.Restart();
            heat = temp;
            Invoke(nameof(ResetTemp), 1);
        }
    }

    private void ResetTemp()
    {
        heat = 0;
    }

}
