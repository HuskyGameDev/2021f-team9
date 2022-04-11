using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pauseMenu.activeSelf)
                    pauseMenu.SetActive(true);
                else
                    pauseMenu.SetActive(false);
            }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
