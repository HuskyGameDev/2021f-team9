using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProceduralGeneration : MonoBehaviour
{

    public int numberOfDifferentRooms;
    public GameObject player;
    public GameObject[] prefabs;
    public int difficulty;
    public GameObject lastRoomPrefab;
    
    private Transition transitionSquare;
    private int prefabAlgorithm;
    private GameObject currentPrefab;
    private int roomsSpawned;
    private roomCoordinate[] coordinatesVisited;
    private roomCoordinate currentRoom;
    private bool roomExists;

    struct roomCoordinate
    {
        public int x;
        public int y;

        public roomCoordinate(int newX, int newY)
        {
            this.x = newX;
            this.y = newY;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coordinatesVisited = new roomCoordinate[difficulty];
        currentRoom.x = Random.Range(0, numberOfDifferentRooms);
        currentRoom.y = Random.Range(0, numberOfDifferentRooms);
        transitionSquare = FindObjectOfType<Transition>();
        prefabAlgorithm = 0;
        roomsSpawned = 0;

        moveEast();
        roomsSpawned = 1;
        coordinatesVisited[roomsSpawned] = new roomCoordinate(currentRoom.x, currentRoom.y);
        roomsSpawned++;
    }

    // Update is called once per frame
    void Update()
    {
        if(roomsSpawned == difficulty)
        {
            // Spawn the treasure room then go back to the hub
            SceneManager.LoadScene("Hub");
        }
    }

    // Swans in a specific prefab
    // input: index = which prefab to spawn in
    GameObject spawnPrefab(int index)
    {
        FindObjectOfType<Rigidbody>().useGravity = false;
        currentPrefab = prefabs[index];
        GameObject newRoom = Instantiate(currentPrefab, transform.position, transform.rotation);
        FindObjectOfType<Rigidbody>().useGravity = true;

        roomExists = false;
        for(int i = 0; i < roomsSpawned; i++)
        {
            if (currentRoom.Equals(coordinatesVisited[i]))
            {
                roomExists = true;
                Debug.Log("It's working!");
                break;
            }
        }

        if (!roomExists)
        {
            coordinatesVisited[roomsSpawned] = new roomCoordinate(currentRoom.x, currentRoom.y);
            roomsSpawned++;
        }

        return newRoom;
    }

    // Does the math for determining which prefab to spawn in
    // input: newCoords = the coordinates of the room you want to spawn in
    // returns: the index of the prefab to be spawned in
    int algorithm(roomCoordinate newCoords)
    {
        //do math
        int answer = Mathf.Abs(newCoords.x) ^ Mathf.Abs(newCoords.y);
        answer %= numberOfDifferentRooms;
        return answer;
    }

    // activates when player moves through north door
    public void moveNorth()
    {
        transitionSquare.transition();
        currentRoom.y += 1;
        prefabAlgorithm = algorithm(currentRoom);
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
        currentRoom.x += 1;
        prefabAlgorithm = algorithm(currentRoom);
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
        currentRoom.y -= 1;
        prefabAlgorithm = algorithm(currentRoom);
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
        currentRoom.x -= 1;
        prefabAlgorithm = algorithm(currentRoom);
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