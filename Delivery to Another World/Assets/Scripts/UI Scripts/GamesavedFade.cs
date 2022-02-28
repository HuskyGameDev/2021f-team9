using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesavedFade : MonoBehaviour
{
    public bool wait;

    private GameObject[] interactables;
    private GameObject player;
    private bool tooFar;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
        interactables = GameObject.FindGameObjectsWithTag("Interactables");
        tooFar = true;
        wait = false;
        hideSign();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            if ((Vector3.Distance(player.transform.position, interactables[i].transform.position) < 1f) && interactables[i].name == "Save_NPC")
            {
                tooFar = false;
                
            }
        }


        if (tooFar && !wait)
        {
            hideSign();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                showSign();
            }
            tooFar = true;
        }
    }

    public void showSign()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            GetComponent<Image>().color = new Vector4(255f, 255f, 255f, i);
            
        }
    }

    public void hideSign()
    {
        // loop over 1 second backwards
        /*for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            GetComponent<Image>().color = new Vector4(255f, 255f, 255f, i);
        }*/
        GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 0f);
    }
}
