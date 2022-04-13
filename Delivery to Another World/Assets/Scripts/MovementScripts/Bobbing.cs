using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{

    public float maxY;
    public float minY;
    public float delay;
    public float speed;

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
        float t = (Time.time - startTime) / speed;

        if (direction)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(minY, maxY, t), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(maxY, minY, t), transform.localPosition.z);
        }

        if (transform.localPosition.y == maxY)
        {
            direction = false;
            startTime = Time.time;
        }
        else if (transform.localPosition.y == minY)
        {
            direction = true;
            startTime = Time.time;
        }
    }
}
