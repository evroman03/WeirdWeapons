using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpRotate : MonoBehaviour
{
    float rotation = 0;
    [SerializeField] private float rotateSpeed = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += rotateSpeed * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f + rotation, 0f);
    }
}
