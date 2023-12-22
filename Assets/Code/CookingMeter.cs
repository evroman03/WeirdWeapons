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


    //IceSprite
    [SerializeField] private GameObject iceSprite;
    [SerializeField] private GameObject fireSprite;

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

        //Adjusts temp effect
        ApplyTempEffect();

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

    private void ApplyTempEffect()
    { 
        if (this.gameObject.transform.position.y > -5)
            iceSprite.GetComponent<IceCreep>().setIce(9);
        if (this.gameObject.transform.position.y < -10)
            iceSprite.GetComponent<IceCreep>().setIce(0);
        if (this.gameObject.transform.position.y < -13)
            iceSprite.GetComponent<IceCreep>().setIce(1);
        if (this.gameObject.transform.position.y < -15)
            iceSprite.GetComponent<IceCreep>().setIce(2);
        if (this.gameObject.transform.position.y < -17)
            iceSprite.GetComponent<IceCreep>().setIce(3);
        if (this.gameObject.transform.position.y < -21)
            iceSprite.GetComponent<IceCreep>().setIce(4);
        if (this.gameObject.transform.position.y < -23)
            iceSprite.GetComponent<IceCreep>().setIce(5);
        if (this.gameObject.transform.position.y < -25)
            iceSprite.GetComponent<IceCreep>().setIce(6);
        if (this.gameObject.transform.position.y == -28)
            iceSprite.GetComponent<IceCreep>().setIce(7);

        if (this.gameObject.transform.position.y < 5)
            fireSprite.GetComponent<CanvasRenderer>().SetAlpha(0);
        if (this.gameObject.transform.position.y > 5)
            fireSprite.GetComponent<CanvasRenderer>().SetAlpha(this.gameObject.transform.position.y / 28);


    }

}
