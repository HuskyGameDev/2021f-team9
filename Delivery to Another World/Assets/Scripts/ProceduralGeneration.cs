using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralGeneration : MonoBehaviour
{

    public int[] roomCoordinate;
    public int numberOfDifferentRooms;
    public GameObject player;
    private Transition transitionSquare;

    public GameObject[] prefabs;
    public int difficulty;
    private int spawn;
    private int prefabAlgorithm;
    private GameObject currentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawn = difficulty;
        roomCoordinate = new int[2];
        roomCoordinate[0] = Random.Range(0, numberOfDifferentRooms);
        roomCoordinate[1] = Random.Range(0, numberOfDifferentRooms);
        transitionSquare = FindObjectOfType<Transition>();
        prefabAlgorithm = 0;

        spawnPrefab(algorithm(roomCoordinate));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Swans in a specific prefab
    // input: index = which prefab to spawn in
    GameObject spawnPrefab(int index)
    {
        FindObjectOfType<Rigidbody>().useGravity = false;
        currentPrefab = prefabs[index];
        GameObject newRoom = Instantiate(currentPrefab, transform.position, transform.rotation);
        FindObjectOfType<Rigidbody>().useGravity = true;
        return newRoom;
    }

    // Does the math for determining which prefab to spawn in
    // input: newCoords = the coordinates of the room you want to spawn in
    // returns: the index of the prefab to be spawned in
    int algorithm(int[] newCoords)
    {
        //do math
        int answer = newCoords[0] ^ newCoords[1];
        answer %= numberOfDifferentRooms;
        return answer;
    }

    // activates when player moves through north door
    public void moveNorth()
    {
        transitionSquare.transition();
        roomCoordinate[1] += 1;
        prefabAlgorithm = algorithm(roomCoordinate);
        GameObject newRoom = spawnPrefab(prefabAlgorithm);
        Transform[] doors = newRoom.GetComponentsInChildren<Transform>();
        player.GetComponent<CharacterController>().enabled = false;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("SouthDoor"))
            {
                Transform door = doors[i];
                player.GetComponent<Transform>().transform.position = door.position;
                break;
            }
        }
        player.GetComponent<CharacterController>().enabled = true;
    }

    // activates when player moves through east door
    public void moveEast()
    {
        transitionSquare.transition();
        roomCoordinate[0] += 1;
        prefabAlgorithm = algorithm(roomCoordinate);
        GameObject newRoom = spawnPrefab(prefabAlgorithm);
        Transform[] doors = newRoom.GetComponentsInChildren<Transform>();
        player.GetComponent<CharacterController>().enabled = false;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("WestDoor"))
            {
                Transform door = doors[i];
                player.GetComponent<Transform>().transform.position = door.position;
                break;
            }
        }
        player.GetComponent<CharacterController>().enabled = true;
    }

    // activates when player moves through south door
    public void moveSouth()
    {
        transitionSquare.transition();
        roomCoordinate[1] -= 1;
        prefabAlgorithm = algorithm(roomCoordinate);
        GameObject newRoom = spawnPrefab(prefabAlgorithm);
        Transform[] doors = newRoom.GetComponentsInChildren<Transform>();
        player.GetComponent<CharacterController>().enabled = false;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("NorthDoor"))
            {
                Transform door = doors[i];
                player.GetComponent<Transform>().transform.position = door.position;
                break;
            }
        }
        player.GetComponent<CharacterController>().enabled = true;
    }

    // activates when player moves through west door
    public void moveWest()
    {
        transitionSquare.transition();
        roomCoordinate[0] -= 1;
        prefabAlgorithm = algorithm(roomCoordinate);
        GameObject newRoom = spawnPrefab(prefabAlgorithm);
        Transform[] doors = newRoom.GetComponentsInChildren<Transform>();
        player.GetComponent<CharacterController>().enabled = false;
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("EastDoor"))
            {
                Transform door = doors[i];
                player.GetComponent<Transform>().transform.position = door.position;
                break;
            }
        }
        player.GetComponent<CharacterController>().enabled = true;
    }
}