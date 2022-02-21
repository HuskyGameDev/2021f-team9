using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    public GameObject questBox;
    public Button button1;
    public Button button2;
    public Image newQuest1;
    public Image newQuest2;
    public bool questActive;

    public List<Quest> quests;

    private Queue<Quest> incompleteQuests;
    private Quest activeQuest1;
    private Quest activeQuest2;

    int i = 0;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questBox.SetActive(false);

        /*foreach (Quest quest in quests) 
        {
            Debug.Log(quest.name);
            incompleteQuests.Enqueue(quest);
      
        }*/

        if (quests[0] != null)
        {
            activeQuest1 = quests[0];
        }

        questActive = false;
       
    }

    public void ShowQuests()
    {
        questBox.SetActive(true);
    }

    public void HideQuests()
    {
        questBox.SetActive(false);
    }

    public void QuestButtonOne()
    {

        if (activeQuest1.isQuestComplete())
        {
            activeQuest1.ClaimQuestReward();
            if (quests.Count > 0)
            {
                activeQuest1 = quests[0];
                quests.RemoveAt(0);
            }
        }
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;

        // If the forest world is selected set the treasure to apple
        PlayerPrefs.SetString("treasureName", "Apple");
        questActive = true;
        HideQuests();
    }

    public void QuestButtonTwo()
    {
        Debug.Log("UnderConstruction");
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;

        // If the forest world is selected set the treature to epic tome
        PlayerPrefs.SetString("treasureName", "EpicTome");
        questActive = true;
        HideQuests();
    }
}
