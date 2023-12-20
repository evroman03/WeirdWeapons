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
    float heightResize = 0;
    float widthResize = 0;

    // Start is called before the first frame update
    void Start()
    {
        rectT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Reset the render textures to avoid hall of mirrors effect. 
        foreach (var rt in RTs)
        {
            rt.Release(); // Release the current render texture
            rt.Create();
        }
        //UPDATE INGAME SIZE
        foreach (var tex in textures)
        {

            heightResize = rectT.sizeDelta.y;
            widthResize = rectT.sizeDelta.x;
            imageRect = tex.GetComponent<RectTransform>();

            //Sets the size of the RawImage's RectTransform to match the Canvas
            imageRect.sizeDelta = new Vector2(rectT.sizeDelta.x, heightResize);



        }
    }
}
