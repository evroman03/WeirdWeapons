using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonToToggle;
    private Image sprite;
    private Button button;

    public void Start()
    {
        sprite = buttonToToggle.GetComponent<Image>();
        button = buttonToToggle.GetComponent<Button>();
        button.enabled = false;
        sprite.enabled = false;
    }

    public void ToggleTheButton()
    {
        if (button.enabled == true)
        {
            button.enabled = false;
            sprite.enabled = false;
            return;
        }
        button.enabled = true;
        sprite.enabled = true;
    }

}
