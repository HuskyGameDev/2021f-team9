using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIndicator : MonoBehaviour
{

    public GameObject questButton1;
    public GameObject questButton2;
    public Sprite exclamationMark;
    public Sprite questionMark;

    private bool direction;
    private float startTime;

    private void Start()
    {
        direction = false;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!questButton1.activeSelf && !questButton2.activeSelf)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        float t = (Time.time - startTime) / .8f;

        if (!direction)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(0.71f, 1f, t), transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.SmoothStep(1f, 0.71f, t), transform.localPosition.z);
        }

        if (transform.localPosition.y == 1f)
        {
            direction = true;
            startTime = Time.time;
        }
        else if (transform.localPosition.y == 0.71f)
        {
            direction = false;
            startTime = Time.time;
        }
    }

    public void questAvailable()
    {
        GetComponent<SpriteRenderer>().sprite = exclamationMark;
    }

    public void questCompleted()
    {
        GetComponent<SpriteRenderer>().sprite = questionMark;
    }
}
