using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveIteraction : MonoBehaviour
{
    Save save = new Save();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 20.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                save.save();
            }
        }
    }
}
