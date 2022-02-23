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
            buttonBackground = GameObject.FindGameObjectsWithTag("Quest");
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 251, 255);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Player wants to traverse down through the list
        if(Input.GetKeyDown(KeyCode.S) && index+1 < buttonBackground.Length){
            buttonBackground[index++].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 251, 255);
        }
        //Player wants to traverse up through the list
        if (Input.GetKeyDown(KeyCode.W) && index - 1 >= 0)
        {
            buttonBackground[index--].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            buttonBackground[index].GetComponent<Image>().color = new Color32(131, 255, 251, 255);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(index == 0)
            {
                FindObjectOfType<QuestManager>().QuestButtonOne();
            }
            if (index == 1)
            {
                FindObjectOfType<QuestManager>().QuestButtonTwo();
            }
        }
    }
}
