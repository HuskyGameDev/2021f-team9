using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 3.0f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("I have triggered the dialogue");
            }
        }
    }
}
