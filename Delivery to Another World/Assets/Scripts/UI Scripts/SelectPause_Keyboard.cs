using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectPause_Keyboard : MonoBehaviour
{
    private GameObject[] buttons;

    public GameObject pauseMenuObject;
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    private GameObject[] arrows = { null, null, null, null };

    private int index = 0;

    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("PauseButton");
        arrows[0] = arrow1;
        arrows[1] = arrow2;
        arrows[2] = arrow3;
        arrows[3] = arrow4;

        arrows[0].GetComponent<Image>().enabled = true;
        arrows[1].GetComponent<Image>().enabled = false;
        arrows[2].GetComponent<Image>().enabled = false;
        arrows[3].GetComponent<Image>().enabled = false;

        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.S) && index + 1 < buttons.Length)
            {
                arrows[index++].GetComponent<Image>().enabled = false;
                arrows[index].GetComponent<Image>().enabled = true;

            }
            if (Input.GetKeyDown(KeyCode.W) && index - 1 >= 0)
            {
                arrows[index--].GetComponent<Image>().enabled = false;
                arrows[index].GetComponent<Image>().enabled = true;

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index == 0)
                {
                    //Resume Game
                    pauseMenu.Resume();
                }
                else if (index == 1)
                {
                    //Open Settings
                    pauseMenu.OpenSettings();
                }
                else if (index == 2)
                {
                    //Main Menu
                    pauseMenu.MainMenu();
                }
                else if (index == 3)
                {
                    //Exit Game
                    pauseMenu.QuitGame();
                }
            }
        }
    }
}
