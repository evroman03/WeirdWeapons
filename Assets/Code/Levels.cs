using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    private static int currentLevel = 0;
    public void nextLevel()
    {
        currentLevel++;
        SceneManager.LoadSceneAsync(currentLevel);
    }
}
