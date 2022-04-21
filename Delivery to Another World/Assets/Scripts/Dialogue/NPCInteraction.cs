using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/* To use the NPC Interaction - because there's dialogue in here
 * 1. Create a new object (UI -> text)
 * 2. Add the text object to myText in the script
 * 3. Put the .txt dialogue you want in my dialogue folder
 * 4. Put the name of the .txt into script (without the file extension in the array)
 */
public class NPCInteraction : MonoBehaviour
{
    public Dialogue dialogue;
    public bool questNPC;
    public List<AudioClip> dialogueAudio;

    private GameObject player;
    private AudioSource source;

    // Start is called before the first frame updates
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (FindObjectOfType<DialogueManager>().IsDialogueCompleted())
                {
                    //string line;
                    /**
                    pm.enabled = false;
                    r.enabled = false;
                    **/

                    player.GetComponent<PlayerMovementGravity>().enabled = false;
                    player.GetComponent<RotationGravity>().enabled = false;
                    //this.enabled = false;

                    TriggerDialogue();

                    // Plays dialogue audio
                    if (dialogueAudio.Count > 0)
                    {
                        playDialogue();
                    }
                }
                else
                {
                    FindObjectOfType<DialogueManager>().DisplayNextScentence();

                    // Plays dialogue audio
                    if (dialogueAudio.Count > 0)
                    {
                        playDialogue();
                    }

                }
                
                //line = reader.ReadLine();
                //myText.text = line;

                /**
                if (line == null)
                {
                    pm.enabled = true;
                    r.enabled = true;
                    move = true;
                }
                **/
            }
        }

        if (player.GetComponent<RotationGravity>().dimensionActive)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, questNPC);
    }

    public void playDialogue()
    {
        // Play dialogue audio
        source.clip = dialogueAudio[0];
        source.Play();
        dialogueAudio.RemoveAt(0);
    }
}
