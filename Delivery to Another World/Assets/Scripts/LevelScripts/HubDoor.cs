using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubDoor : MonoBehaviour
{
    GameObject map;

    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        map.SetActive(false);
        FindObjectOfType<Transition>().SendMessage("transition");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            if (!map.activeSelf && Input.GetKeyDown(KeyCode.E) && FindObjectOfType<QuestManager>().questActive)
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
