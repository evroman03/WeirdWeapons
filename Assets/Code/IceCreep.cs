using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreep : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIce(int level)
    {
        if (level == 9)
        {
            this.gameObject.GetComponent<Image>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Image>().enabled = true;
            this.gameObject.GetComponent<Image>().sprite = sprites[level];
        }
    }
}
