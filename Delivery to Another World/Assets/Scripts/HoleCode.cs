using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCode : MonoBehaviour
{

    private bool dimensionActive;
    RotationGravity rotGrav;

    private void Start()
    {
        rotGrav = FindObjectOfType<RotationGravity>();
    }

    // Update is called once per frame
    void Update()
    {
        dimensionActive = rotGrav.dimensionActive;

        if (dimensionActive)
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rotGrav.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        rotGrav.enabled = true;
    }
}
