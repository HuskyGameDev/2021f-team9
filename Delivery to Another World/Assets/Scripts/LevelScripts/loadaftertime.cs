using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadaftertime : MonoBehaviour
{
    private float delay = 100f;
    public string NewLevel = "Tutorial";
    private float timeelapsed;

    void Update()
    {
        timeelapsed += Time.timeSinceLevelLoad;
        Debug.Log(timeelapsed);
        Debug.Log(delay);
        if (timeelapsed >= delay)
        {
            SceneManager.LoadScene(NewLevel);
        }
    }

}
