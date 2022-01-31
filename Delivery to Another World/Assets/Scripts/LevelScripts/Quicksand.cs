using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour
{
    /// <summary>
    /// The script will cause the player to slide towards the center of the quicksand
    /// and if they are directly in the center, they will drown in the quicksand.
    /// </summary>
    private GameObject player = FindObjectOfType<PlayerMovementGravity>().gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
