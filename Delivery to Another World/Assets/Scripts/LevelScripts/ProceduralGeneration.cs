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
    public bool inTreasureRoom;
    
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
    private bool lastRoomReached;
    private int spawn;
    private int algorithmX;
    private int algorithmY;
    private int algorithmZ;

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
        numberOfDifferentRooms = prefabs.Length;
        coordinatesVisited = new roomCoordinate[difficulty + 1];
        transitionSquare = FindObjectOfType<Transition>();
        prefabAlgorithm = 0;
        roomsSpawned = 0;
        lastRoomReached = false;
        algorithmX = Random.Range(1, 10);
        algorithmY = Random.Range(1, 10);
        algorithmZ = Random.Range(1, 10);
        inTreasureRoom = false;

        spawn = Random.Range(0, 3);
        if (spawn == 0)
        {
            currentRoom.x = Random.Range(0, difficulty);
            currentRoom.y = 0;
            currentRoom.y -= 1;
            moveNorth();
        }
        else if (spawn == 1)
        {
            currentRoom.x = 0;
            currentRoom.y = Random.Range(0, difficulty);
            currentRoom.x -= 1;
            moveEast();
        }
        else if (spawn == 2)
        {
            currentRoom.x = Random.Range(0, difficulty);
            currentRoom.y = difficulty - 1;
            currentRoom.y += 1;
            moveSouth();
        }
        else
        {
            currentRoom.x = difficulty - 1;
            currentRoom.y = Random.Range(0, difficulty);
            currentRoom.x += 1;
            moveWest();
        }
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
            index = 9;
            //SceneManager.LoadScene("Hub");
            lastRoomReached = true;
            inTreasureRoom = true;
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
            int[] temp = new int[3];
            temp[0] = currentRoom.x;
            temp[1] = currentRoom.y;
            temp[2] = index;
            Debug.Log(FindObjectOfType<WorldMap>().name);
            FindObjectOfType<WorldMap>().SendMessage("updateSquare", temp);
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
        int tempY = (newCoords.y + 1) * algorithmX;
        int tempX = (newCoords.x + 1) * algorithmY;
        int answer = Mathf.Abs(((tempX - tempY) * (tempY - tempX) * tempY / (tempX + algorithmZ)) ^ Mathf.Abs(tempY + tempX - algorithmZ));
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
                player.transform.position = new Vector3(door.position.x, door.position.y - 0.4f, door.position.z);
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

        if (currentRoom.y >= difficulty - 1)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= difficulty - 1)
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

        if (lastRoomReached)
        {
            northDoor.SetActive(false);
            eastDoor.SetActive(false);
            southDoor.SetActive(false);
            westDoor.SetActive(false);
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
                player.transform.position = new Vector3(door.position.x, door.position.y - 0.4f, door.position.z);
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

        if (currentRoom.y >= difficulty - 1)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= difficulty - 1)
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

        if (lastRoomReached)
        {
            northDoor.SetActive(false);
            eastDoor.SetActive(false);
            southDoor.SetActive(false);
            westDoor.SetActive(false);
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
                player.transform.position = new Vector3(door.position.x, door.position.y - 0.4f, door.position.z);
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

        if (currentRoom.y >= difficulty - 1)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= difficulty - 1)
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

        if (lastRoomReached)
        {
            northDoor.SetActive(false);
            eastDoor.SetActive(false);
            southDoor.SetActive(false);
            westDoor.SetActive(false);
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
                player.transform.position = new Vector3(door.position.x, door.position.y - 0.4f, door.position.z);
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

        if (currentRoom.y >= difficulty - 1)
        {
            northDoor.SetActive(false);
            Debug.Log("North door deactivated!");
        }
        if (currentRoom.x >= difficulty - 1)
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

        if (lastRoomReached)
        {
            northDoor.SetActive(false);
            eastDoor.SetActive(false);
            southDoor.SetActive(false);
            westDoor.SetActive(false);
        }
    }
}