using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveIteraction : MonoBehaviour
{
    public GameObject saveDataObj;
    public GameObject playerObj;
    Save save;


    private void Awake()
    {
        save = new Save(saveDataObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, playerObj.transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                save.save();
            }
        }
    }
}