using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class HiddenNPC : MonoBehaviour
{

    public Dialogue sentences;
    [TextArea(3, 10)]
    public string[] goodSentences;
    [TextArea(3, 10)]
    public string[] badSentences;
    public GameObject dialogueBox;
    public DialogueManager dialogueManager;
    public List<AudioClip> dialogueAudio;
    public AudioSource source;

    private GameObject player;
    private bool dialogueStarted;
    private int NPCsDiscovered = 0;
    private int dialogueCount;
    private bool good;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueStarted = false;
        dialogueCount = 0;
        good = false;

        if (PlayerPrefs.GetInt("forestGremlin") == 1)
        {
            NPCsDiscovered++;
        }
        if (PlayerPrefs.GetInt("desertGremlin") == 1)
        {
            NPCsDiscovered++;
        }
        if (PlayerPrefs.GetInt("castleGremlin") == 1)
        {
            NPCsDiscovered++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(transform.localPosition, player.transform.position));
        Dialogue castleSentences;

        // Every other line besides the first line of dialogue
        if (dialogueStarted && Input.GetKeyDown(KeyCode.E))
        {
            if (SceneManager.GetActiveScene().name == "Castle")
            {
                // Re-initialize the dialogue with the good dialogue
                if (dialogueCount == 3 && good)
                {
                    castleSentences = sentences;
                    castleSentences.scentences = goodSentences;
                    dialogueManager.StartDialogue(castleSentences, false);
                }
                // Re-initialize the dialogue with the bad dialogue
                else if (dialogueCount == 3 && !good)
                {
                    castleSentences = sentences;
                    Debug.Log(badSentences);
                    castleSentences.scentences = badSentences;
                    dialogueManager.StartDialogue(castleSentences, false);
                }

                if (dialogueCount != 3)
                {
                    dialogueManager.DisplayNextScentence();
                }

                if (dialogueCount >= 3 && dialogueAudio.Count > 0 && dialogueCount < 8 && good)
                {
                    playGoodDialogue();
                }
                else if (dialogueCount >= 3 && dialogueAudio.Count > 0 && dialogueCount < 8 && !good)
                {
                    playBadDialogue();
                }
                else if (dialogueAudio.Count > 0)
                {
                    playDialogue();
                }
            }
            // if it is not the castle world
            else
            {
                dialogueManager.DisplayNextScentence();

                if (dialogueAudio.Count > 0)
                {
                    playDialogue();
                }
            }

            dialogueCount++;
            //Debug.Log(dialogueCount);
        }
        
        // When initially talking to the NPC
        if (Vector3.Distance(transform.position, player.transform.position) < 2f && Input.GetKeyDown(KeyCode.E) && !dialogueStarted)
        {
            if (dialogueManager.IsDialogueCompleted())
            {
                dialogueCount = 0;
                dialogueBox.SetActive(true);

                dialogueManager.StartDialogue(sentences, false);

                player.GetComponent<PlayerMovementGravity>().enabled = false;
                player.GetComponent<RotationGravity>().enabled = false;

                // plays the first line of dialogue
                if (dialogueAudio.Count > 0)
                {
                    playDialogue();
                }

                dialogueCount++;
                dialogueStarted = true;
            }
            Debug.Log(NPCsDiscovered);
            // Lets the game know when a player talks to a specific hiddenNPC
            if (SceneManager.GetActiveScene().name == "Forest")
            {
                if (PlayerPrefs.GetInt("forestGremlin") == 0)
                {
                    PlayerPrefs.SetInt("forestGremlin", 1);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Desert")
            {
                if (PlayerPrefs.GetInt("desertGremlin") == 0)
                {
                    PlayerPrefs.SetInt("desertGremlin", 1);
                }
            }
            else if (SceneManager.GetActiveScene().name == "Castle")
            {
                if (PlayerPrefs.GetInt("castleGremlin") == 0)
                {
                    PlayerPrefs.SetInt("castleGremlin", 1);
                    NPCsDiscovered++;
                }

                if (NPCsDiscovered == 3)
                {
                    // Allow J to be used
                    good = true;
                    PlayerPrefs.SetInt("enableJ", 1);
                }
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            FindObjectOfType<Escript>().SendMessage("showSign");
        }

    }

    public void playDialogue()
    {
        // Play dialogue audio
        if (SceneManager.GetActiveScene().name == "Castle")
        {
            if (dialogueAudio.Count > 4)
            {
                source.clip = dialogueAudio[0];
                source.Play();
                dialogueAudio.RemoveAt(0);
            }
        }
        else
        {
            source.clip = dialogueAudio[0];
            source.Play();
            dialogueAudio.RemoveAt(0);
        }
    }

    // Only used in castle world
    public void playGoodDialogue()
    {
        if (dialogueAudio.Count > 4)
        {
            source.clip = dialogueAudio[0];
            source.Play();
            dialogueAudio.RemoveAt(0);
        }
    }

    // Only used in castle world
    public void playBadDialogue()
    {
        if (dialogueAudio.Count > 4)
        {
            source.clip = dialogueAudio[4];
            source.Play();
            dialogueAudio.RemoveAt(4);
        }
    }
}
