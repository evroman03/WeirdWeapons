using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    [SerializeField] GameObject toMakeVisible;

    private Image image;
    private Button button;

    private void Start()
    {
        //Disable button and ability to see button on startup
        image = toMakeVisible.GetComponent<Image>();
        image.enabled = false;

        button = toMakeVisible.GetComponent<Button>();
        button.enabled = false;
    }

    public void toggleButton()
    {
        //Toggle button on / off
        if (image.enabled == false)
        {
            image.enabled = true;
            button.enabled = true;
        }
        else
        {
            image.enabled = false;
            button.enabled = false;
        }
    }
}
