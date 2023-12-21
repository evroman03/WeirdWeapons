using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform cameraPos;
    private void Start()
    {
        if(cameraPos==null)
        {
            cameraPos = GameObject.FindGameObjectWithTag("HeadForCamera").transform;
        }
    }
    void Update()
    {
        transform.position = cameraPos.position;
        transform.rotation = cameraPos.rotation;
    }
}
