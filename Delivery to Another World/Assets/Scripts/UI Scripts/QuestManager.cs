using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questBox;
    public UnityEngine.UIElements.Button button1;
    public UnityEngine.UIElements.Button button2;
    public Text button1Text;
    public Text button2Text;
    public GameObject newQuest1;
    public GameObject newQuest2;
    public bool questActive;
    public GameObject questNPC;

    public List<Quest> quests;

    private Queue<Quest> incompleteQuests;
    private Quest activeQuest1;
    private Quest activeQuest2;

    private DialogueManager dialogueManager;
    private static QuestManager questManager;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (questManager == null)
            questManager = this;
        else
        {
            quests = questManager.quests;
            Destroy(questManager.gameObject);
            questManager = this;
        }
    }

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questBox.SetActive(false);
        incompleteQuests = new Queue<Quest>();
        questActive = false;

        /*
        foreach (Quest quest in quests) 
        {
            quest.dialogue.name = this.GetComponentInParent<NPCInteraction>().dialogue.name;
            incompleteQuests.Enqueue(quest);
        }
        */

        //DELETE AFTER PLAYTESTING
        for (int i = 0; i < 2; i++)
        {
            Quest quest = quests[i];
            quest.dialogue.name = questNPC.GetComponentInParent<NPCInteraction>().dialogue.name;
            quest.completionDialogue.name = quest.dialogue.name;
            incompleteQuests.Enqueue(quest);
        }
        //STOP DELETE

        UpdateButtonText();

        if (activeQuest1.isNewQuest)
            newQuest1.SetActive(true);
        else
            newQuest1.SetActive(false);

        if (activeQuest2.isNewQuest)
            newQuest2.SetActive(true);
        else
            newQuest2.SetActive(false);
    }

    public void UpdateButtonText()
    {
        if (activeQuest1 == null)
        {
            if(incompleteQuests.Count > 0)
                activeQuest1 = incompleteQuests.Dequeue();
        }

        if (activeQuest2 == null)
        {
            if (incompleteQuests.Count > 0)
                activeQuest2 = incompleteQuests.Dequeue();
        }

        button1Text.text = activeQuest1.questName;
        button2Text.text = activeQuest2.questName;
    }

    public void ShowQuests()
    {
        UpdateButtonText();
        questBox.SetActive(true);
        FindObjectOfType<PlayerMovementGravity>().enabled = false;
        FindObjectOfType<RotationGravity>().enabled = false;
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

            dialogueManager.StartDialogue(activeQuest1.completionDialogue, false);

            //activeQuest1 = null;
            if (activeQuest2 == null)
                questActive = false; // this is the questActive I was referring to...
        }
        else
        {
            activeQuest1.isNewQuest = false;
            dialogueManager.StartDialogue(activeQuest1.dialogue, false); // Set to false so quest screen doesn't show up again
        }

        questActive = true; // This will overrite the questActive = false in the if statement above - Brandon
        newQuest1.SetActive(false);

        // If the forest world is selected set the treasure to apple
        PlayerPrefs.SetString("treasureName", "Apple");
        questActive = true;
        HideQuests();
    }

    public void QuestButtonTwo()
    {
        if (activeQuest2.isQuestComplete())
        {
            activeQuest2.ClaimQuestReward();

            dialogueManager.StartDialogue(activeQuest2.completionDialogue, false);

            //activeQuest2 = null;
            if (activeQuest1 == null)
                questActive = false;
        } 
        else
        {
            activeQuest2.isNewQuest = false;
            dialogueManager.StartDialogue(activeQuest2.dialogue, false); // Set to false so quest screen doesn't show up again
        }

        questActive = true; // This will overrite the questActive = false in the if statement above - Brandon
        newQuest2.SetActive(false);

        // If the desert world is selected set the treasure to final cactus
        PlayerPrefs.SetString("treasureName", "FinalCactus");
        questActive = true;
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

    public void CompleteQuest1()
    {
        activeQuest1.CompleteQuest();
    }

    public void CompleteQuest2()
    {
        activeQuest2.CompleteQuest();
    }
}
