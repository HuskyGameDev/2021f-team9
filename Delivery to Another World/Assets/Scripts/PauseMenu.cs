using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject map;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf && !map.activeSelf)
            {
                pauseMenu.SetActive(true);
            }
            else if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
