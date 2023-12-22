using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Flames : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;

    Stopwatch fireTimer = new Stopwatch();

    int currentFrame = 0;

    public int flameDensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer.ElapsedMilliseconds > 300)
        {
            fireTimer.Restart();
            currentFrame++;
            if (currentFrame > 11)
                currentFrame = 0;
            this.gameObject.GetComponent<Image>().sprite = sprites[currentFrame];
            this.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }
}
