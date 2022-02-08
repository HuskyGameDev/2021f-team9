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

    public List<Quest> quests;

    private Queue<Quest> incompleteQuests;
    private Quest activeQuest1;
    private Quest activeQuest2;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questBox.SetActive(false);

        foreach (Quest quest in quests) 
        {
            incompleteQuests.Enqueue(quest);
        }
    }

    public void ShowQuests()
    {
        questBox.SetActive(true);
    }

    public void QuestButtonOne()
    {
        if(activeQuest1.isQuestComplete())
        {
            activeQuest1.ClaimQuestReward();
            if(incompleteQuests.Count > 0)
                activeQuest1 = incompleteQuests.Dequeue();
        }
    }

    public void QuestButtonTwo()
    {

    }
}
