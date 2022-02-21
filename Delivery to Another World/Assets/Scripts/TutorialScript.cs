using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TutorialNPCInteractionScript : MonoBehaviour
{
    private bool rotate = false;

    public Text myText;
    public string script;

    private StreamReader reader;
    private StreamReader alternate;
    private PlayerMovement pm;
    private Rotation r;
    private bool move;

    private bool intro = true;

    // Start is called before the first frame updates
    void Start()
    {
        //move = true;
        //reader = new StreamReader("Assets/Dialogue/" + script + ".txt");
        //alternate = new StreamReader("Assets/Dialogue/AlternateDimension.txt");
        //pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //r = GameObject.FindGameObjectWithTag("Player").GetComponent<Rotation>();

        
    }
    


    // Update is called once per frame
    void Update()
    {
        if (intro)
        {
            TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Hey welcome to the game. Press continue so I can keep talking", "Now, use WASD to walk over to me" }));
            intro = false;
        }

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!rotate)
                {
                    TriggerDialogue(new Dialogue("Sneaky Thief", new string[] { "Nice job walking over to me", "You're gonna be great at this" }));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && move)
        {
            StartCoroutine(disappear());
        }

    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, false);
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