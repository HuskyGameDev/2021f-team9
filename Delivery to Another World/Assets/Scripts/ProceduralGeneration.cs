using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{

    public int[] roomCoordinate;
    public int numberOfDifferentRooms;

    public GameObject[] prefabs;
    public int difficulty;
    private int spawn;
    private float position;
    private int prefabAlgorithm;
    private GameObject currentPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawn = difficulty;
        position = transform.position.x;
        roomCoordinate[0] = Random.Range(0, numberOfDifferentRooms);
        roomCoordinate[1] = Random.Range(0, numberOfDifferentRooms);
        prefabAlgorithm = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while(spawn > 0)
        {
            
            spawn--;
        }
        FindObjectOfType<Rigidbody>().useGravity = true;
    }

    void spawnRandomPrefab(int index)
    {
        currentPrefab = prefabs[index];
        Vector3 trans = new Vector3(position, transform.position.y, transform.position.z);
        Instantiate(currentPrefab, trans, transform.rotation);
        position += 20f;
    }

    void algorithm()
    {
        //do math
    }

    public void moveNorth()
    {
        roomCoordinate[1] += 1;
        spawnRandomPrefab(prefabAlgorithm);
    }

    public void moveEast()
    {
        roomCoordinate[0] += 1;
        spawnRandomPrefab(prefabAlgorithm);
    }

    public void moveSouth()
    {
        roomCoordinate[1] -= 1;
        spawnRandomPrefab(prefabAlgorithm);
    }

    public void moveWest()
    {
        roomCoordinate[0] -= 1;
        spawnRandomPrefab(prefabAlgorithm);
    }
}