using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubDoor : MonoBehaviour
{
    GameObject map;
    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        map.SetActive(false);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 3.0f)
        {
            if (!map.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                map.SetActive(true);
            }

            if (map.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                map.SetActive(false);
            }
        }
    }

}
