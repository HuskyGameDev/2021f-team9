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

    private void Start()
    {
        dialogueBox.SetActive(false);
        script = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, bool questNPC)
    {
        isQuestNPC = questNPC;

        dialogueBox.SetActive(true);

        Debug.Log("Starting conversation with " + dialogue.name);

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

            if (isQuestNPC) // This is being run after the dialogue after selecting a quest - Brandon
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
        Debug.Log("End of conversation");
        dialogueBox.SetActive(false);
    }

    public void ShowQuests()
    {
        FindObjectOfType<QuestManager>().ShowQuests();
    }
}
