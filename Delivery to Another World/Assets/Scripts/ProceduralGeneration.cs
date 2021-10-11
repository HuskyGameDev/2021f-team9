using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{

    public GameObject[] prefabs;
    public int difficulty;
    private int spawn;
    private float position;

    // Start is called before the first frame update
    void Start()
    {
        spawn = difficulty;
        position = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        while(spawn > 0)
        {
            spawnRandomPrefab();
            spawn--;
        }
    }

    void spawnRandomPrefab()
    {
        GameObject currentPrefab = prefabs[Random.Range(0, prefabs.Length)];
        Vector3 trans = new Vector3(position, transform.position.y, transform.position.z);
        Instantiate(currentPrefab, trans, transform.rotation);
        position += 20f;
    }
}