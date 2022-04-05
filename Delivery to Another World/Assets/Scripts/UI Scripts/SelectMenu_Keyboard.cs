using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu_Keyboard : MonoBehaviour
{
    private GameObject[] buttons;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    private GameObject[] arrows = { null, null, null };

    private int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("MenuButton");
        arrows[0] = arrow1;
        arrows[1] = arrow2;
        arrows[2] = arrow3;

        arrows[0].GetComponent<Image>().enabled = false;
        arrows[1].GetComponent<Image>().enabled = true;
        arrows[2].GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
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
                //New Game
                FindObjectOfType<NewGameSaveOverite>().TaskOnClick();
                SceneManager.LoadScene("Tutorial");
            }
            else if (index == 1)
            {
                //Load Game
                FindObjectOfType<Load>().LoadSave();
                SceneManager.LoadScene("Hub");
            }
            else if (index == 2)
            {
                //Quit
                Application.Quit();
            }
        }
    }
}
