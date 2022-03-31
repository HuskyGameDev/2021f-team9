using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> script;
    private bool isQuestNPC;
    private bool isComplete;

    private void Start()
    {
        dialogueBox.SetActive(false);
        script = new Queue<string>();
        isComplete = true;
    }

    public void StartDialogue(Dialogue dialogue, bool questNPC)
    {
        isQuestNPC = questNPC;
        isComplete = false;

        dialogueBox.SetActive(true);

        nameText.text = dialogue.name + ":";

        script.Clear();

        foreach (string scentence in dialogue.scentences)
        {
            script.Enqueue(scentence);
        }

        DisplayNextScentence();
    }

    public void DisplayNextScentence()
    {
        if (script.Count == 0)
        {
            EndDialogue();

            if (isQuestNPC)
                ShowQuests();
            else
            {
                FindObjectOfType<PlayerMovementGravity>().enabled = true;
                FindObjectOfType<RotationGravity>().enabled = true;
            }
        }
        else
        {
            string scentence = script.Dequeue();
            dialogueText.text = scentence;
        }
        
    }

    public void EndDialogue()
    {
        isComplete = true;
        dialogueBox.SetActive(false);
    }

    public void ShowQuests()
    {
        FindObjectOfType<QuestManager>().ShowQuests();
    }

    public bool IsDialogueCompleted()
    {
        return isComplete;
    }
}
