using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuestManager : MonoBehaviour
{
    public GameObject questBox;
    public Button button1;
    public Button button2;
    public GameObject newQuest1;
    public GameObject newQuest2;
    public bool questActive;

    public List<Quest> quests;

    private Queue<Quest> incompleteQuests;
    private Quest activeQuest1;
    private Quest activeQuest2;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questBox.SetActive(false);
        incompleteQuests = new Queue<Quest>();
        questActive = false;

        foreach (Quest quest in quests) 
        {
            quest.dialogue.name = this.GetComponentInParent<NPCInteraction>().dialogue.name;
            incompleteQuests.Enqueue(quest);
        }

        if (activeQuest1 == null || activeQuest1.isNewQuest)
            newQuest1.SetActive(true);

        if (activeQuest2 == null || activeQuest2.isNewQuest)
            newQuest2.SetActive(true);
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
        if (activeQuest1 == null)
            activeQuest1 = incompleteQuests.Dequeue();

        if (activeQuest1.isQuestComplete())
        {
            activeQuest1.ClaimQuestReward();
            activeQuest1 = null;
            if (activeQuest2 == null)
                questActive = false;
        }
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;

        questActive = true; // This will overrite the questActive = false in the if statement above - Brandon
        HideQuests();
        newQuest1.SetActive(false);
        dialogueManager.StartDialogue(activeQuest1.dialogue, true);

        // If the forest world is selected set the treasure to apple
        /*
        PlayerPrefs.SetString("treasureName", "Apple");
        questActive = true;
        */
        HideQuests();
    }

    public void QuestButtonTwo()
    {
        if (activeQuest2 == null)
            activeQuest2 = incompleteQuests.Dequeue();

        if (activeQuest2.isQuestComplete())
        {
            activeQuest2.ClaimQuestReward();
            activeQuest2 = null;
            if (activeQuest1 == null)
                questActive = false;
        }
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;

        questActive = true; // This will overrite the questActive = false in the if statement above - Brandon
        HideQuests();
        newQuest2.SetActive(false);
        dialogueManager.StartDialogue(activeQuest2.dialogue, true);

        // If the forest world is selected set the treasure to epic tome
        /*
        PlayerPrefs.SetString("treasureName", "EpicTome");
        questActive = true;
        */
        HideQuests();
    }

    public void ExitQuestScreen()
    {
        HideQuests();
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;
    }

    public string GetQuest1()
    {
        if (activeQuest1 != null)
            return activeQuest1.questArea;
        return "";
    }

    public string GetQuest2()
    {
        if (activeQuest2 != null)
            return activeQuest2.questArea;
        return "";
    }
}
