using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{

    public float delay;

    private bool direction;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        direction = false;
        startTime = Time.time - delay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t = (Time.time - startTime) / 1f;

        if (direction)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(0.6f, 1f, t), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(1f, 0.6f, t), transform.localPosition.z);
        }

        if (transform.localPosition.y == 1f)
        {
            direction = false;
            startTime = Time.time;
        }
        else if (transform.localPosition.y == 0.6f)
        {
            direction = true;
            startTime = Time.time;
        }
    }
}
