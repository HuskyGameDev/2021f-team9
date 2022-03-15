using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{

    public GameObject questList;
    public GameObject questListText;

    private int questCount;
    private List<string> activeQuests;
    private string finalText;
    private static QuestList UI;

    private void Start()
    {
        if (FindObjectsOfType<QuestList>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            questCount = 0;
            finalText = "No Quests Accepted";
            activeQuests = new List<string>();
            DontDestroyOnLoad(gameObject);
        }

        /*if (UI == null)
        {
            UI = this;
            questCount = 0;
            finalText = "No Quests Accepted";
            activeQuests = new List<string>();
        }    
        else
        {
            finalText = UI.finalText;
            activeQuests = UI.activeQuests;
            Destroy(UI.gameObject);
            UI = this;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questList.SetActive(!questList.activeSelf);
        }

        questListText.GetComponent<Text>().text = finalText;
        
    }

    public void addQuest(string objective)
    {
        finalText = "";
        activeQuests.Add("- " + objective + ": 0/1\n");
        
        foreach (string name in activeQuests)
        {
            finalText += name;
        }

        questCount++;
    }

    public void completeQuest(string objective)
    {
        finalText = "";
        int index = activeQuests.IndexOf("- " + objective + ": 0/1\n");
        activeQuests[index] = "[Completed] " + objective + "\n";

        foreach (string name in activeQuests)
        {
            finalText += name;
        }
    }

    public void removeQuest(string questName)
    {
        finalText = "";
        activeQuests.Remove(questName + "\n");

        questCount--;

        if (questCount == 0)
        {
            finalText = "No Quests Accepted";
        }
        else
        {
            foreach (string name in activeQuests)
            {
                finalText += name;
            }
        }
    }
}
