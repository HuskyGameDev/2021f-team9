using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footsteps;
    public float timetodelay;

    private bool canStart;
    // Start is called before the first frame update
    void Start()
    {
        footsteps = GetComponent<AudioSource>();
        canStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Vertical"));
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && canStart)
        {
            Debug.Log("HI");
            footsteps.Play();
            canStart = false;
        }
        else if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f && !canStart)
        {
            footsteps.Stop();
            canStart = true;
        }
       
    }
}
