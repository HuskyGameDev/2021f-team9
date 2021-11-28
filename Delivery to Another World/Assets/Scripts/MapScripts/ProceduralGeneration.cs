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
    private GameObject northDoor;
    private GameObject eastDoor;
    private GameObject southDoor;
    private GameObject westDoor;

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
        coordinatesVisited = new roomCoordinate[difficulty + 1];
        currentRoom.x = Random.Range(0, numberOfDifferentRooms);
        currentRoom.y = Random.Range(0, numberOfDifferentRooms);
        transitionSquare = FindObjectOfType<Transition>();
        prefabAlgorithm = 0;
        roomsSpawned = 0;

        currentRoom.x -= 1;
        moveEast();
        //roomsSpawned = 1;
        //coordinatesVisited[roomsSpawned] = new roomCoordinate(currentRoom.x, currentRoom.y);
        //roomsSpawned++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns in a specific prefab
    // input: index = which prefab to spawn in
    GameObject spawnPrefab(int index)
    {
        FindObjectOfType<Rigidbody>().useGravity = false;
        if (roomsSpawned == difficulty)
        {
            // Spawn the treasure room then go back to the hub
            currentPrefab = lastRoomPrefab;
            //SceneManager.LoadScene("Hub");
        }
        else
        {
            currentPrefab = prefabs[index];
        }
        GameObject newRoom = Instantiate(currentPrefab, transform.position, transform.rotation);
        FindObjectOfType<Rigidbody>().useGravity = true;
        Debug.Log(currentRoom.x);
        Debug.Log(currentRoom.y);

        roomExists = false;
        for(int i = 0; i < roomsSpawned; i++)
        {
            if (currentRoom.Equals(coordinatesVisited[i]))
            {
                roomExists = true;
                Debug.Log("Room Visited");
                break;
            }
        }

        if (!roomExists)
        {
            coordinatesVisited[roomsSpawned] = new roomCoordinate(currentRoom.x, currentRoom.y);
            roomsSpawned++;
            Debug.Log("Room NOT Visited");
        }
        Debug.Log(roomsSpawned);

        return newRoom;
    }

    // Does the math for determining which prefab to spawn in
    // input: newCoords = the coordinates of the room you want to spawn in
    // returns: the index of the prefab to be spawned in
    int algorithm(roomCoordinate newCoords)
    {
        //do math
        int tempY = newCoords.y * 3;
        int tempX = newCoords.x * 2;
        int answer = Mathf.Abs(((tempX - tempY) * (tempY - tempX) * tempY * tempX) ^ Mathf.Abs(tempY));
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

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("NorthDoor"))
            {
                northDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("EastDoor"))
            {
                eastDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("SouthDoor"))
            {
                southDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("WestDoor"))
            {
                westDoor = doors[i].gameObject;
            }
        }

        if (currentRoom.y >= numberOfDifferentRooms)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= numberOfDifferentRooms)
        {
            eastDoor.SetActive(false);
            Debug.Log("East door deactivated!");
        }
        if (currentRoom.y <= 0)
        {
            southDoor.SetActive(false);
            Debug.Log("South door deactivated!");
        }
        if (currentRoom.x <= 0)
        {
            westDoor.SetActive(false);
            Debug.Log("West door deactivated!");
        }
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

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("NorthDoor"))
            {
                northDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("EastDoor"))
            {
                eastDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("SouthDoor"))
            {
                southDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("WestDoor"))
            {
                westDoor = doors[i].gameObject;
            }
        }

        if (currentRoom.y >= numberOfDifferentRooms)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= numberOfDifferentRooms)
        {
            eastDoor.SetActive(false);
            Debug.Log("East door deactivated!");
        }
        if (currentRoom.y <= 0)
        {
            southDoor.SetActive(false);
            Debug.Log("South door deactivated!");
        }
        if (currentRoom.x <= 0)
        {
            westDoor.SetActive(false);
            Debug.Log("West door deactivated!");
        }
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

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("NorthDoor"))
            {
                northDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("EastDoor"))
            {
                eastDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("SouthDoor"))
            {
                southDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("WestDoor"))
            {
                westDoor = doors[i].gameObject;
            }
        }

        if (currentRoom.y >= numberOfDifferentRooms)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= numberOfDifferentRooms)
        {
            eastDoor.SetActive(false);
            Debug.Log("East door deactivated!");
        }
        if (currentRoom.y <= 0)
        {
            southDoor.SetActive(false);
            Debug.Log("South door deactivated!");
        }
        if (currentRoom.x <= 0)
        {
            westDoor.SetActive(false);
            Debug.Log("West door deactivated!");
        }
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

        for(int i = 0; i < doors.Length; i++)
        {
            if (doors[i].gameObject.CompareTag("NorthDoor"))
            {
                northDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("EastDoor"))
            {
                eastDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("SouthDoor"))
            {
                southDoor = doors[i].gameObject;
            }
            else if (doors[i].gameObject.CompareTag("WestDoor"))
            {
                westDoor = doors[i].gameObject;
            }
        }

        if (currentRoom.y >= numberOfDifferentRooms)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= numberOfDifferentRooms)
        {
            eastDoor.SetActive(false);
            Debug.Log("East door deactivated!");
        }
        if (currentRoom.y <= 0)
        {
            southDoor.SetActive(false);
            Debug.Log("South door deactivated!");
        }
        if (currentRoom.x <= 0)
        {
            westDoor.SetActive(false);
            Debug.Log("West door deactivated!");
        }
    }
}