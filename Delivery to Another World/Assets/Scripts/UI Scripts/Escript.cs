using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escript : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, interactables[i].transform.position) < 1f && FindObjectOfType<PlayerMovementGravity>().enabled)
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
            showSign();
            tooFar = true;
        }
    }

    public void showSign()
    {
        GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 255f);
    }

    public void hideSign()
    {
        GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 0f);
    }
}
