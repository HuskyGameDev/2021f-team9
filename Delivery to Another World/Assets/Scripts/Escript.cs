using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escript : MonoBehaviour
{

    private GameObject[] interactables;
    private GameObject player;
    private bool tooFar;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
        interactables = GameObject.FindGameObjectsWithTag("Interactables");
        tooFar = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, interactables[i].transform.position) < 1f)
            {
                tooFar = false;
            }
        }

        if (tooFar)
        {
            GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 0f);
        }
        else
        {
            GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 255f);
            tooFar = true;
        }
    }
}
