using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubDoor : MonoBehaviour
{
    GameObject map;
    public GameObject pressE;
    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        map.SetActive(false);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.0f)
        {
            pressE.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 255f);
            if (!map.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                map.SetActive(true);
            }

            if (map.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            {
                map.SetActive(false);
            }
        }
        else
        {
            pressE.GetComponent<Image>().color = new Vector4(255f, 255f, 255f, 0f);
        }
    }

}
