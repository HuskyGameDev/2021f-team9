using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    public string direction;

    private void OnTriggerEnter(Collider other)
    {
        if (direction == "NORTH")
        {
            FindObjectOfType<ProceduralGeneration>().moveNorth();
        }
        if (direction == "EAST")
        {
            FindObjectOfType<ProceduralGeneration>().moveEast();
        }
        if (direction == "SOUTH")
        {
            FindObjectOfType<ProceduralGeneration>().moveSouth();
        }
        if (direction == "WEST")
        {
            FindObjectOfType<ProceduralGeneration>().moveWest();
        }

    }
}
