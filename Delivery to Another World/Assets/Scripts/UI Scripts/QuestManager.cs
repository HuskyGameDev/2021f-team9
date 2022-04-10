using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public GameObject questBox;
    public Text button1Text;
    public Text button2Text;
    public GameObject newQuest1;
    public GameObject newQuest2;
    public bool questActive;
    public GameObject questNPC;
    public List<Quest> quests;
    public Sprite exclamationMark;
    public Sprite questionMark;

    private Queue<Quest> incompleteQuests;
    private Quest activeQuest1;
    private Quest activeQuest2;
    private DialogueManager dialogueManager;
    private static QuestManager questManager;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (questManager == null)
        {
            questManager = this;

            incompleteQuests = new Queue<Quest>();
            questActive = false;

            foreach (Quest quest in quests)
            {
                quest.dialogue.name = questNPC.GetComponentInParent<NPCInteraction>().dialogue.name;
                quest.completionDialogue.name = quest.dialogue.name;
                incompleteQuests.Enqueue(quest);
            }
        }
        else
        {
            quests = questManager.quests;
            incompleteQuests = questManager.incompleteQuests;
            activeQuest1 = questManager.activeQuest1;
            activeQuest2 = questManager.activeQuest2;
            Destroy(questManager.gameObject);
            questManager = this;
        }

    }

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        questBox.SetActive(false);
        UpdateButtonText();

        if (PlayerPrefs.GetInt("apple") == 1)
        {
            quests[0].CompleteQuest();
        }

        if (PlayerPrefs.GetInt("appleClaimed") == 1)
        {
            quests[0].ClaimQuestReward();
            quests[0].isNewQuest = false;
    
        }

        if (PlayerPrefs.GetInt("finalcactus") == 1)
        {
            quests[1].CompleteQuest();
        }

        if (PlayerPrefs.GetInt("finalcactusClaimed") == 1)
        {
            quests[1].ClaimQuestReward();
            quests[1].isNewQuest = false;
        }

        if (PlayerPrefs.GetInt("epictome") == 1)
        {
            quests[2].CompleteQuest();
        }

        if (PlayerPrefs.GetInt("epictomeClaimed") == 1)
        {
            quests[2].ClaimQuestReward();
            quests[2].isNewQuest = false;
        }

        if (PlayerPrefs.GetInt("specialskull") == 1)
        {
            quests[3].CompleteQuest();
        }

        if (PlayerPrefs.GetInt("specialskullClaimed") == 1)
        {
            quests[3].ClaimQuestReward();
            quests[3].isNewQuest = false;
        }

        if (PlayerPrefs.GetInt("didYouWin") == 1)
        {
            quests[4].CompleteQuest();
        }

        if (PlayerPrefs.GetInt("didYouWinClaimed") == 1)
        {
            quests[4].ClaimQuestReward();
            quests[4].isNewQuest = false;
        }

        UpdateButtonText();
    }

    public void UpdateButtonText()
    {
        if (activeQuest1 == null || activeQuest1.isQuestClaimed())
        {
            if(incompleteQuests.Count > 0)
                activeQuest1 = incompleteQuests.Dequeue();
        }

        if (activeQuest2 == null || activeQuest2.isQuestClaimed())
        {
            if (incompleteQuests.Count > 0)
                activeQuest2 = incompleteQuests.Dequeue();
        }

        button1Text.text = activeQuest1.questName;
        button2Text.text = activeQuest2.questName;

        if (activeQuest1.isNewQuest || activeQuest1.isQuestComplete())
            newQuest1.SetActive(true);
        else
            newQuest1.SetActive(false);

        if (activeQuest2.isNewQuest || activeQuest2.isQuestComplete())
            newQuest2.SetActive(true);
        else
            newQuest2.SetActive(false);

        if (activeQuest1.isQuestComplete())
        {
            newQuest1.GetComponent<UnityEngine.UI.Image>().sprite = questionMark;
            FindObjectOfType<QuestIndicator>().SendMessage("questCompleted");
        }
        else
            newQuest1.GetComponent<UnityEngine.UI.Image>().sprite = exclamationMark;

        if (activeQuest2.isQuestComplete())
        {
            newQuest2.GetComponent<UnityEngine.UI.Image>().sprite = questionMark;
            FindObjectOfType<QuestIndicator>().SendMessage("questCompleted");
        }
        else
            newQuest2.GetComponent<UnityEngine.UI.Image>().sprite = exclamationMark;

        if (!activeQuest1.isQuestComplete() && !activeQuest2.isQuestComplete())
            FindObjectOfType<QuestIndicator>().SendMessage("questAvailable");

        if (newQuest1.activeSelf || newQuest2.activeSelf)
            FindObjectOfType<QuestIndicator>().SendMessage("showIndicator");
        else
            FindObjectOfType<QuestIndicator>().SendMessage("hideIndicator");
    }

    public void ShowQuests()
    {
        UpdateButtonText();
        questBox.SetActive(true);
        FindObjectOfType<PlayerMovementGravity>().enabled = false;
        FindObjectOfType<RotationGravity>().enabled = false;
        FindObjectOfType<NPCInteraction>().enabled = false;
    }

    public void HideQuests()
    {
        UpdateButtonText();
        questBox.SetActive(false);
        FindObjectOfType<NPCInteraction>().enabled = true;
    }

    public void QuestButtonOne()
    {
        if (activeQuest1.isQuestComplete() && !activeQuest1.isQuestClaimed()) // when you complete the quest and turn it in
        {
            activeQuest1.ClaimQuestReward();

            FindObjectOfType<NPCInteraction>().dialogueAudio.AddRange(activeQuest1.completionAudio);
            dialogueManager.StartDialogue(activeQuest1.completionDialogue, false);

            FindObjectOfType<QuestList>().SendMessage("removeQuest", activeQuest1.objective);

            activeQuest1 = null;
            if (activeQuest2 == null)
                questActive = false;
        }
        else // when it is a new quest
        {
            FindObjectOfType<NPCInteraction>().dialogueAudio.AddRange(activeQuest1.dialogueAudio);
            dialogueManager.StartDialogue(activeQuest1.dialogue, false); // Set to false so quest screen doesn't show up again
            questActive = true;

            if (activeQuest1.isNewQuest)
            {
                FindObjectOfType<QuestList>().SendMessage("addQuest", activeQuest1.objective);
            }

            activeQuest1.isNewQuest = false;

            if (activeQuest1.questArea == "Forest")
            {
                PlayerPrefs.SetString("forestTreasureName", activeQuest1.treasure);
            }
            else if (activeQuest1.questArea == "Desert")
            {
                PlayerPrefs.SetString("desertTreasureName", activeQuest1.treasure);
            }
            else
            {
                PlayerPrefs.SetString("castleTreasureName", activeQuest1.treasure);
            }
        }

        FindObjectOfType<NPCInteraction>().SendMessage("playDialogue");
        HideQuests();
    }

    public void QuestButtonTwo()
    {
        if (activeQuest2.isQuestComplete() && !activeQuest2.isQuestClaimed()) // when you complete the quest and turn it in
        {
            activeQuest2.ClaimQuestReward();

            FindObjectOfType<NPCInteraction>().dialogueAudio.AddRange(activeQuest2.completionAudio);
            dialogueManager.StartDialogue(activeQuest2.completionDialogue, false);

            FindObjectOfType<QuestList>().SendMessage("removeQuest", activeQuest2.objective);

            activeQuest2 = null;
            if (activeQuest1 == null)
                questActive = false;
        } 
        else // when it is a new quest
        {
            FindObjectOfType<NPCInteraction>().dialogueAudio.AddRange(activeQuest2.dialogueAudio);
            dialogueManager.StartDialogue(activeQuest2.dialogue, false); // Set to false so quest screen doesn't show up again
            questActive = true;

            if (activeQuest2.isNewQuest)
            {
                FindObjectOfType<QuestList>().SendMessage("addQuest", activeQuest2.objective);
            }

            activeQuest2.isNewQuest = false;

            if (activeQuest2.questArea == "Forest")
            {
                PlayerPrefs.SetString("forestTreasureName", activeQuest2.treasure);
            }
            else if (activeQuest2.questArea == "Desert")
            {
                PlayerPrefs.SetString("desertTreasureName", activeQuest2.treasure);
            }
            else
            {
                PlayerPrefs.SetString("castleTreasureName", activeQuest2.treasure);
            }
        }

        FindObjectOfType<NPCInteraction>().SendMessage("playDialogue");
        HideQuests();
    }

    public void ExitQuestScreen()
    {
        HideQuests();
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        FindObjectOfType<RotationGravity>().enabled = true;
    }

    public Quest GetQuest1()
    {
        return activeQuest1;
    }

    public Quest GetQuest2()
    {
        return activeQuest2;
    }

    public void CompleteQuest1()
    {
        activeQuest1.CompleteQuest();
        FindObjectOfType<QuestList>().SendMessage("completeQuest", activeQuest1.objective);
    }

    public void CompleteQuest2()
    {
        activeQuest2.CompleteQuest();
        FindObjectOfType<QuestList>().SendMessage("completeQuest", activeQuest2.objective);
    }
}
