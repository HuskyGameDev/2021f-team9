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

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1f && Input.GetKeyDown(KeyCode.E))
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
            }
            else
            {
                dialogueManager.DisplayNextScentence();

                if (dialogueAudio.Count > 0)
                {
                    playDialogue();
                }
            }
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
