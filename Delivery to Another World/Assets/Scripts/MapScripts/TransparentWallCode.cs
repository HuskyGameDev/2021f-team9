using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWallCode : MonoBehaviour
{

    public bool isReverse;
    public float alphaValue;

    private bool dimensionActive;
    private GameObject player;
    private GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
        playerCamera = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;
        MeshRenderer[] backsides = GetComponentsInChildren<MeshRenderer>();
        MeshRenderer backside = GetComponentInChildren<MeshRenderer>();

        // If in the other dimension and this wall is a part of that dimension, make it visible (unless you need the camera to see through it
        if (dimensionActive && isReverse)
        {
            GetComponent<MeshCollider>().enabled = true;

            if (transform.position.x < player.transform.position.x && transform.position.x > playerCamera.transform.position.x && transform.eulerAngles.y == 90f)
            {
                backside.enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
                for (int i = 0; i < backsides.Length; i++)
                {
                    backsides[i].enabled = true;
                }
            }
        }
        // If in the standard dimension and this wall is a part of that dimension, make it visible (unless you need the camera to see through it
        else if(!dimensionActive && !isReverse)
        {
            GetComponent<MeshCollider>().enabled = true;

            if (transform.position.z < player.transform.position.z && transform.position.z > playerCamera.transform.position.z && transform.eulerAngles.y == 0f)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
                for (int i = 0; i < backsides.Length; i++)
                {
                    backsides[i].enabled = true;
                }
            }
        }
        // Otherwise make the wall invisible with no collision
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            for (int i = 0; i < backsides.Length; i++)
            {
                backsides[i].enabled = false;
            }
        }
    }
}
