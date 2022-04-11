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
public class SelectQuest_Keyboard : MonoBehaviour 
{

    private GameObject[] buttons;

    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    private GameObject[] arrows = { null, null, null };

    private GameObject[] buttonBackground;
    private int index = 1;

    private void Start()
    {
            buttons = GameObject.FindGameObjectsWithTag("Quest");
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
        //Player wants to traverse down through the list
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
            if(index == 0)
            {
                FindObjectOfType<QuestManager>().ExitQuestScreen();
            }
            else if(index == 1)
            {
                FindObjectOfType<QuestManager>().QuestButtonOne();
            }
            else if (index == 2)
            {
                FindObjectOfType<QuestManager>().QuestButtonTwo();
            }
        }
    }
}
