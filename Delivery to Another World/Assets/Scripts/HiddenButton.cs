using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenButton : MonoBehaviour
{
    public GameObject wall;

    private bool activated;
    private bool stopDuplicates;

    private void Start()
    {
        activated = false;
        stopDuplicates = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Escript>().wait = true;
        FindObjectOfType<Escript>().SendMessage("showSign");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !activated && !stopDuplicates && other.CompareTag("Player"))
        {
            wall.GetComponent<HiddenWall>().SendMessage("OpenWall");
            activated = true;
            stopDuplicates = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && activated && !stopDuplicates && other.CompareTag("Player"))
        {
            wall.GetComponent<HiddenWall>().SendMessage("CloseWall");
            activated = false;
            stopDuplicates = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<Escript>().wait = false;
        FindObjectOfType<Escript>().SendMessage("hideSign");
        stopDuplicates = false;
    }
}
