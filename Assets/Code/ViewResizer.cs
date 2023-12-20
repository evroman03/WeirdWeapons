using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewResizer : MonoBehaviour
{
    [SerializeField] private List<RawImage> textures = new List<RawImage>();
    [SerializeField] private List<RenderTexture> RTs = new List<RenderTexture>();
    RectTransform rectT;

    // Start is called before the first frame update
    void Start()
    {
        rectT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
