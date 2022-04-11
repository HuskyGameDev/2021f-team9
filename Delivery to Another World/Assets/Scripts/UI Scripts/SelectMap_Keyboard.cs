using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

//If possible move all of this into quest manager
//The if-else in start can be taken out (put back everything that was in the else statement)
//That is literally so things don't really change
//The FindObjectOfType, will be able to be turned into "this"
//If possible I want a better way to start the quest, if each quest is a different method this will become unweildy fast
//You can keep using buttons, whatever is used it just needs to be tagged as Quest, and have an Image component
//DO NOT UPDATE THIS CODE BRANDON OR ETHAN THIS IS A PLACEHOLDER SO I DIDN'T ACCIDENTALLY BREAK THE GAME
public class SelectMap_Keyboard : MonoBehaviour 
{
    public bool run;

    private GameObject[] buttonBackground;
    private int index = 0;

    private void Start()
    {
        if (!run)
        {
            this.enabled = false;
        }
        else 
        {
            buttonBackground = GameObject.FindGameObjectsWithTag("MapButton");
            // Sets the first button to be selected
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 255, 255);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Player wants to traverse down through the list
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            // Set previously selected button to default color and move index to next location
            buttonBackground[index++].GetComponent<Image>().color = new Color32(255, 0, 94, 255);

            // If the end of the list is reached, send pointer back to the start of the list
            if (index >= buttonBackground.Length)
            {
                index = 0;
            }

            // Skip over non-enabled buttons
            for(int i = 0; i < buttonBackground.Length; i++)
            {
                if (buttonBackground[index].GetComponent<Button>().enabled)
                {
                    break;
                }

                index++;

                if (index >= buttonBackground.Length)
                {
                    index = 0;
                }
            }

            // Set newly selected button to blue
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 255, 255);
        }

        //Player wants to traverse up through the list
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
        {
            // Set previously selected button to default color and move index to next location
            buttonBackground[index--].GetComponent<Image>().color = new Color32(255, 0, 94, 255);

            // If the start of the list is reached, send pointer to the back of the list
            if (index < 0)
            {
                index = buttonBackground.Length - 1;
            }

            // Skip over non-enabled buttons
            for (int i = 0; i < buttonBackground.Length; i++)
            {
                if (buttonBackground[index].GetComponent<Button>().enabled)
                {
                    break;
                }

                index--;

                if (index < 0)
                {
                    index = buttonBackground.Length - 1;
                }
            }

            // Set newly selected button to blue
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 255, 255);
        }

        // Load the scene of the selected world
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (buttonBackground[index].name == "Forest Button")
            {
                FindObjectOfType<LevelLoader>().LoadForest();
            }
            else if (buttonBackground[index].name == "Desert Button")
            {
                FindObjectOfType<LevelLoader>().LoadDesert();
            }
            else if (buttonBackground[index].name == "Cave Button")
            {
                FindObjectOfType<LevelLoader>().LoadCave();
            }
            else if (buttonBackground[index].name == "Castle Button")
            {
                FindObjectOfType<LevelLoader>().LoadCastle();
            }
            else if (buttonBackground[index].name == "Exit Button")
            {
                FindObjectOfType<HubDoor>().ExitMap();
            }
        }
    }
}
