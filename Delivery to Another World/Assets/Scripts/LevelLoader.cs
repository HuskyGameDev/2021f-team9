using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject light;
    public void LoadForest()
    {
        Debug.Log("Loading Forest");
        SceneManager.LoadScene("Forest");
    }

    public void LoadDesert()
    {
        Debug.Log("Loading Desert");
    }

    public void LoadCave()
    {
        Debug.Log("Loading Cave");
    }

    public void LoadCastle()
    {
        Debug.Log("Loading Castle");
    }
}
