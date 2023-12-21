using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookingMeter : MonoBehaviour
{
    [SerializeField] private float decayRate = 5;
    [SerializeField] private GameObject HPTEXT;
    [SerializeField] private int HP = 10;
    GameObject pan = null;
    PanLogic panLogic = null;
    float translate = 0;

    Stopwatch hurtTimer = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        pan = GameObject.FindGameObjectWithTag("Pan");
        panLogic = pan.GetComponent<PanLogic>();
        hurtTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Increment meter if within desired range. 
        if (this.gameObject.transform.position.y > -28)
        {
            translate -= decayRate * Time.deltaTime;
        }

        if (this.gameObject.transform.position.y < 28) {
            translate += panLogic.panShaken / 100;
        }
        
        if ((Mathf.Abs(this.gameObject.transform.position.y) > 28) && (hurtTimer.ElapsedMilliseconds >= 1000))
        {
            hurtTimer.Restart();
            HP--;
            HPTEXT.GetComponent<TextMeshProUGUI>().text = "HP: " + HP;
        }

        if (HP == 0)
        {
            SceneManager.LoadSceneAsync("DeathScene");
        }

        //Transform shrimp. 
        this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, translate, this.gameObject.transform.position.z);
    }
}
