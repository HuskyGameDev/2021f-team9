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
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else if (!pauseMenu.activeSelf)
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
        // Players (like me) will think this is for exiting the pause menu, not exiting the game.
        //Application.Quit();
        pauseMenu.SetActive(false);
        EnablePlayer();
    }

    public void DisablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = false;
        player.GetComponent<RotationGravity>().enabled = false;
        // Need to disable enemies too
        if (SceneManager.GetActiveScene().name == "Forest" || SceneManager.GetActiveScene().name == "Desert" || SceneManager.GetActiveScene().name == "Castle")
        {
            foreach (EnemyMovement enemy in FindObjectsOfType<EnemyMovement>())
            {
                enemy.enabled = false;
            }
        }
    }

    public void EnablePlayer()
    {
        player.GetComponent<PlayerMovementGravity>().enabled = true;
        player.GetComponent<RotationGravity>().enabled = true;
        // Need to enable enemies too
        if (SceneManager.GetActiveScene().name == "Forest" || SceneManager.GetActiveScene().name == "Desert" || SceneManager.GetActiveScene().name == "Castle")
        {
            foreach (EnemyMovement enemy in FindObjectsOfType<EnemyMovement>())
            {
                enemy.enabled = true;
            }
        }
    }
}
