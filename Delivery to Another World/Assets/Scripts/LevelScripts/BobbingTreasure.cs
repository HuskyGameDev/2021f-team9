using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobbingTreasure : MonoBehaviour
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

    // When the player touches the treasure
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GoHome(other.tag));
    }

    // Sends the player back to the hub with the treasure.
    IEnumerator GoHome(string treasureName)
    {
        FindObjectOfType<PlayerMovementGravity>().enabled = false;
        FindObjectOfType<PlayerMovementGravity>().gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        FindObjectOfType<Success>().SendMessage("youWin");

        // Set the power ups from collecting treasures
        if (PlayerPrefs.GetString("treasureName") == "Apple")
        {
            PlayerPrefs.SetFloat("maxStamina", 200f);
            Debug.Log("Stamina increased");
            FindObjectOfType<QuestManager>().CompleteQuest1();
        }
        else if(PlayerPrefs.GetString("treasureName") == "FinalCactus")
        {
            // Lower cooldown time for rotating
            FindObjectOfType<QuestManager>().CompleteQuest2();
        }

        yield return new WaitForSeconds(5f);
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        SceneManager.LoadScene("Hub");
    }
}
