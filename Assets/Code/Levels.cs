using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] string sendToLevel;
    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(sendToLevel);
    }
}
