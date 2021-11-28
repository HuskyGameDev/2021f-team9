using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobbingApple : MonoBehaviour
{

    private bool direction;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        direction = false;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float t = (Time.time - startTime) / 1f;

        if (direction)
        {
            transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(0.5f, 1f, t), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(1f, 0.5f, t), transform.position.z);
        }

        if(transform.position.y == 1f)
        {
            direction = false;
            startTime = Time.time;
        }
        else if(transform.position.y == 0.5f)
        {
            direction = true;
            startTime = Time.time;
        }
    }

    // When the player enters the apple
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GoHome());
    }

    // Sends the player back to the hub with the apple.
    IEnumerator GoHome()
    {
        FindObjectOfType<PlayerMovementGravity>().enabled = false;
        FindObjectOfType<PlayerMovementGravity>().gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        yield return new WaitForSeconds(3f);
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        SceneManager.LoadScene("Hub");
    }
}
