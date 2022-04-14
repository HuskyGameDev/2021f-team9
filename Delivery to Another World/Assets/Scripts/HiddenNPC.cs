using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenNPC : MonoBehaviour
{

    public Dialogue sentences;
    public GameObject dialogueBox;
    public DialogueManager dialogueManager;
    public List<AudioClip> dialogueAudio;
    public AudioSource source;

    private GameObject player;
    private bool dialogueStarted;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.localPosition, player.transform.position));

        if (dialogueStarted && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextScentence();

            if (dialogueAudio.Count > 0)
            {
                playDialogue();
            }
        }

        if (Vector3.Distance(transform.localPosition, player.transform.position) < 1f && Input.GetKeyDown(KeyCode.E) && !dialogueStarted)
        {
            if (dialogueManager.IsDialogueCompleted())
            {
                dialogueBox.SetActive(true);
                dialogueManager.StartDialogue(sentences, false);
                player.GetComponent<PlayerMovementGravity>().enabled = false;
                player.GetComponent<RotationGravity>().enabled = false;

                if (dialogueAudio.Count > 0)
                {
                    playDialogue();
                }

                dialogueStarted = true;
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            FindObjectOfType<Escript>().SendMessage("showSign");
        }
        else
        {
            FindObjectOfType<Escript>().SendMessage("hideSign");
        }
    }

    public void playDialogue()
    {
        // Play dialogue audio
        source.clip = dialogueAudio[0];
        source.Play();
        dialogueAudio.RemoveAt(0);
    }
}
