using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenRoom : MonoBehaviour
{

    public bool hide;

    private bool open;

    // Update is called once per frame
    void Update()
    {
        open = FindObjectOfType<HiddenWall>().open;

        if (!open || hide)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
