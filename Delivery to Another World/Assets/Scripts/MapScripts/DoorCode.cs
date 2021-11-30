using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    public string direction;

    private bool canDetect;

    private void Start()
    {
        StartCoroutine(LockDoors());
        canDetect = false;
    }

    // prevents player from leaving as soon as they enter the room
    private IEnumerator LockDoors()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<BoxCollider>().enabled = true;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (direction == "NORTH")
        {
            FindObjectOfType<ProceduralGeneration>().moveNorth();
            Destroy(transform.parent.gameObject);
        }
        else if (direction == "EAST")
        {
            FindObjectOfType<ProceduralGeneration>().moveEast();
            Destroy(transform.parent.gameObject);
        }
        else if (direction == "SOUTH")
        {
            FindObjectOfType<ProceduralGeneration>().moveSouth();
            Destroy(transform.parent.gameObject);
        }
        else if (direction == "WEST")
        {
            FindObjectOfType<ProceduralGeneration>().moveWest();
            Destroy(transform.parent.gameObject);
        }

    }*/

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Escript>().wait = true;
        FindObjectOfType<Escript>().SendMessage("showSign");
    }

    private void OnTriggerExit(Collider other)
    {
        FindObjectOfType<Escript>().wait = false;
        FindObjectOfType<Escript>().SendMessage("hideSign");
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (direction == "NORTH")
            {
                FindObjectOfType<ProceduralGeneration>().moveNorth();
                Destroy(transform.parent.gameObject);
            }
            else if (direction == "EAST")
            {
                FindObjectOfType<ProceduralGeneration>().moveEast();
                Destroy(transform.parent.gameObject);
            }
            else if (direction == "SOUTH")
            {
                FindObjectOfType<ProceduralGeneration>().moveSouth();
                Destroy(transform.parent.gameObject);
            }
            else if (direction == "WEST")
            {
                FindObjectOfType<ProceduralGeneration>().moveWest();
                Destroy(transform.parent.gameObject);
            }

            FindObjectOfType<Escript>().wait = false;
            FindObjectOfType<Escript>().SendMessage("hideSign");
        }
    }
}
