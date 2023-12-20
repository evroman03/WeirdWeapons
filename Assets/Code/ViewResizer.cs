using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewResizer : MonoBehaviour
{
    [SerializeField] private List<RawImage> textures = new List<RawImage>();
    [SerializeField] private List<RenderTexture> RTs = new List<RenderTexture>();
    RectTransform rectT;
    RectTransform imageRect;
    int heightResize = 0;

    // Start is called before the first frame update
    void Start()
    {
        rectT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {   
        //UPDATE INGAME SIZE
        foreach (var tex in textures)
        {
            heightResize = 0;
            imageRect = tex.GetComponent<RectTransform>();

            while ((float)(heightResize / rectT.sizeDelta.x) < (float)(9f / 16f))
            {
                heightResize++;
            }
            Debug.Log((heightResize + " / " + rectT.sizeDelta.x) + "Ratio");

            //Sets the size of the RawImage's RectTransform to match the Canvas
            imageRect.sizeDelta = new Vector2(rectT.sizeDelta.x, heightResize);


        }
    }
}
