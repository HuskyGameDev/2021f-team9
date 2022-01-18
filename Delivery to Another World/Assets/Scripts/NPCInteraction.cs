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

    private StreamReader reader;
    private StreamReader alternate;
    private PlayerMovement pm;
    private Rotation r;
    private bool move;

    // Start is called before the first frame updates
    void Start()
    {
        move = true;
        reader = new StreamReader("Assets/Dialogue/" + script + ".txt");
        alternate = new StreamReader("Assets/Dialogue/AlternateDimension.txt");
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        r = GameObject.FindGameObjectWithTag("Player").GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                string line;
                /**
                pm.enabled = false;
                r.enabled = false;
                move = false;
                **/
                if (!rotate)
                {
                    TriggerDialogue();
                    //line = reader.ReadLine();
                    //myText.text = line;
                }
                else
                {
                    //line = alternate.ReadLine();
                    //myText.text = line;
                }
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

        if (Input.GetKeyDown(KeyCode.R) && move)
        {
            StartCoroutine(disappear());
        }

    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    //This is to make it so that you can't see anyone when you flip dimensions, but this code will have to be fixed
    //based on the map and if we want people to be 2D or 3D
    IEnumerator disappear()
    {
        yield return null;
        if (!rotate)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            rotate = true;
        }
        else if (rotate)
        {
            alternate = new StreamReader("Assets/Dialogue/AlternateDimension.txt");
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            rotate = false;
        }
    }
}
