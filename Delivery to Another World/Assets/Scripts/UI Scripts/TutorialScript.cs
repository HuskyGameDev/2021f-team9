using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public Dialogue dialogue;
    private bool ranTutorial;

    // Start is called before the first frame update
    void Start()
    {
        ranTutorial = false;
    }

    private void Update()
    {
        if(ranTutorial == false)
        {
            TriggerDialogue();
            ranTutorial = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, false);
    }
}
