using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string loadLevel;

    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(loadLevel);
    }
}
