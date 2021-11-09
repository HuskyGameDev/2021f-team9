using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadForest()
    {
        Debug.Log("Loading Forest");
        SceneManager.LoadScene("Forest");
    }

    public void LoadDesert()
    {
        Debug.Log("Loading Desert");
        SceneManager.LoadScene("Desert");
    }

    public void LoadCave()
    {
        Debug.Log("Loading Cave");
        SceneManager.LoadScene("Cave");
    }

    public void LoadCastle()
    {
        Debug.Log("Loading Castle");
        SceneManager.LoadScene("Castle");
    }

    public void LoadHub()
    {
        Debug.Log("Loading Hub");
        SceneManager.LoadScene("Hub");
    }
}
