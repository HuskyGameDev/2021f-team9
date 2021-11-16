using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWallCode : MonoBehaviour
{

    public bool isReverse;

    private bool dimensionActive;

    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;
    }

    // Update is called once per frame
    void Update()
    {
        if(dimensionActive && isReverse)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshCollider>().enabled = true;
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else if(!dimensionActive && !isReverse)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<MeshCollider>().enabled = true;
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
