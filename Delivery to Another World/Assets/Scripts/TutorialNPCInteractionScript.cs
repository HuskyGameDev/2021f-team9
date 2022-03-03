using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialNPCInteractionScript : MonoBehaviour
{
    private bool rotate;

    public Text myText;
    public string script;

    private GameObject pm;
    private bool talking = false;
    private bool intro = true;
    private bool walkedOver = false;
    private bool hasTurned = false;
    private bool hasTurnedBack = false;
    private bool done = false;
    private int[] iWillFightUnity = { 2, 3, 3, 3, 4};

    // Start is called before the first frame updates
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player");
        rotate = pm.GetComponent<RotationGravity>().dimensionActive;
    }



    // Update is called once per frame
    void Update()
    {
        rotate = pm.GetComponent<RotationGravity>().dimensionActive;

        if (rotate)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }

        if (intro)
        {
            if (!talking)
            {
                talking = true;
                TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Hey welcome to the game. Press E so I can keep talking", "Now, use WASD to walk over to me" }));
                //intro = false;
                iWillFightUnity[0]--;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueManager>().DisplayNextScentence();
                if (iWillFightUnity[0] <= 1)
                {
                    intro = false;
                    talking = false;
                }
                iWillFightUnity[0]--;
            }
        }

        if (Vector3.Distance(transform.position, pm.transform.position) < 1.0f)
        {
            FindObjectOfType<DialoguePressE>().showE();
            if (Input.GetKeyDown(KeyCode.E) && !walkedOver && !hasTurned && !hasTurnedBack)
            {
                if (!rotate)
                {
                    if (!talking)
                    {
                        talking = true;
                        TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Nice job walking over to me", "You're gonna be great at this", "How about you try pressing R?" }));
                        iWillFightUnity[1]--;
                    }
                    else
                    {
                        FindObjectOfType<DialogueManager>().DisplayNextScentence();
                        if (iWillFightUnity[1] <= 1)
                        {
                            walkedOver = true;
                            talking = false;
                            FindObjectOfType<DialoguePressE>().changeToR();
                        }
                        iWillFightUnity[1]--;
                    }
                }
            }
        }
        else if (Vector3.Distance(transform.position, pm.transform.position) >= 1.0f && !intro && !walkedOver && !hasTurned && !hasTurnedBack)
        {
            FindObjectOfType<DialoguePressE>().hideE();
        }

        if (!intro && !hasTurned && walkedOver)
        {
            if (!talking && rotate) //Input.GetKeyDown(KeyCode.R))
            {
                FindObjectOfType<DialoguePressE>().changeToE();
                talking = true;
                TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Whoa, that wasn't supposed to happen", "Ethan, did you die? Where are you?", "You were supposed to be the chosen one..." }));
                iWillFightUnity[2]--;
            }
            else if (Input.GetKeyDown(KeyCode.E) && talking)
            {
                FindObjectOfType<DialogueManager>().DisplayNextScentence();
                if (iWillFightUnity[2] <= 1)
                {
                    walkedOver = false;
                    hasTurned = true;
                    talking = false;
                    FindObjectOfType<DialoguePressE>().changeToR();
                }
                iWillFightUnity[2]--;
            }
        }
        if (hasTurned && !walkedOver && !hasTurnedBack)
        {
            if (!talking && !rotate)//Input.GetKeyDown(KeyCode.R))
            {
                FindObjectOfType<DialoguePressE>().changeToE();
                talking = true;
                TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Oh!", "You're back!", "Want to try sprinting? Press shift and move around" }));
                iWillFightUnity[3]--;
            }
            else if (Input.GetKeyDown(KeyCode.E) && talking)
            {
                FindObjectOfType<DialogueManager>().DisplayNextScentence();

                if (iWillFightUnity[3] <= 1)
                {
                    hasTurned = false;
                    hasTurnedBack = true;
                    talking = false;
                    FindObjectOfType<DialoguePressE>().changeToShift();
                }
                iWillFightUnity[3]--;
            }
        }

        if (hasTurnedBack && !done)
        {
            if (!talking && FindObjectOfType<PlayerMovementGravity>().isSprinting)
            {
                talking = true;
                TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Nice Job Running!", "I bet when you ... turn invisible...? You'd be able to sprint past people and they would never know!", "Well that's all I can teach you.", "Have fun at the thieves guild!" }));
                iWillFightUnity[4]--;
                FindObjectOfType<DialoguePressE>().changeToE();
            }
            else if (talking && Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueManager>().DisplayNextScentence();
                if (iWillFightUnity[4] <= 0)
                {
                    hasTurnedBack = false;
                    done = true;
                    talking = false;
                }
                iWillFightUnity[4]--;
            }
        }

        if(done)
        {
            //What happens when the tutorial is complete
            SceneManager.LoadScene("Hub");
        }
        

    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, false);
    }

}