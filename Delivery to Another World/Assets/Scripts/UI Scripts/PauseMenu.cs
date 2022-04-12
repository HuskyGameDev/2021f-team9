using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    private GameObject player;

    private void Start()
    {
        pauseMenu.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                DisablePlayer();
            }
            else
            {
                pauseMenu.SetActive(false);
                EnablePlayer();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        EnablePlayer();
    }

    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
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

    public void DisablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = false;
        player.GetComponent<RotationGravity>().enabled = false;
    }

    public void EnablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = true;
        player.GetComponent<RotationGravity>().enabled = true;
    }
}
