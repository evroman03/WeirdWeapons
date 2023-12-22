using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
