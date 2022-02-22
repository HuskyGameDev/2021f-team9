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
    private bool rotate = false;

    public Text myText;
    public string script;
    public Dialogue dialogue;
    public bool questNPC;

    private StreamReader reader;
    private StreamReader alternate;
    private PlayerMovement pm;
    private Rotation r;
    private bool move;
    private bool test;

    // Start is called before the first frame updates
    void Start()
    {
        move = true;
        //reader = new StreamReader("Assets/Dialogue/" + script + ".txt");
        //alternate = new StreamReader("Assets/Dialogue/AlternateDimension.txt");
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        r = GameObject.FindGameObjectWithTag("Player").GetComponent<Rotation>();
        test = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (test)
                {
                    test = false;
                    string line;
                    /**
                    pm.enabled = false;
                    r.enabled = false;
                    **/


                    FindObjectOfType<PlayerMovementGravity>().enabled = false;
                    FindObjectOfType<RotationGravity>().enabled = false;
                    //this.enabled = false;

                    TriggerDialogue();
                }
                else
                {
                    FindObjectOfType<DialogueManager>().DisplayNextScentence();
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

        if (FindObjectOfType<RotationGravity>().dimensionActive)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            alternate = new StreamReader("Assets/Dialogue/AlternateDimension.txt");
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, questNPC);
    }


}
