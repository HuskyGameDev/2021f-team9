using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footsteps;
    public float timetodelay;
    // Start is called before the first frame update
    void Start()
    {
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            footsteps.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            footsteps.Stop();
        }
       
    }
}
