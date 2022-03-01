using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadForest()
    {
        Debug.Log("Loading Forest");
        //PlayerPrefs.SetString("treasureName", "epicTome");
        PlayerPrefs.SetString("world", "forest");
        SceneManager.LoadScene("Forest");
    }

    public void LoadDesert()
    {
        Debug.Log("Loading Desert");
        PlayerPrefs.SetString("world", "desert");
        SceneManager.LoadScene("Desert");
    }

    public void LoadCave()
    {
        Debug.Log("Loading Cave");
        PlayerPrefs.SetString("world", "cave");
        SceneManager.LoadScene("Cave");
    }

    public void LoadCastle()
    {
        Debug.Log("Loading Castle");
        PlayerPrefs.SetString("world", "castle");
        SceneManager.LoadScene("Castle");
    }

    public void LoadHub()
    {
        Debug.Log("Loading Hub");
        PlayerPrefs.SetString("world", "hub");
        SceneManager.LoadScene("Hub");
    }
}
