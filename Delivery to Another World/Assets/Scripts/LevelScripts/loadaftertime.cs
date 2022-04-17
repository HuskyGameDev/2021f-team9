using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class loadaftertime : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
