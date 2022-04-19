using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobbingTreasure : MonoBehaviour
{

    private bool direction;
    private float startTime;
    private bool wait;
    private string treasureName;

    // Start is called before the first frame update
    void Start()
    {
        direction = false;
        startTime = Time.time;
        wait = false;
        treasureName = PlayerPrefs.GetString("treasureName");
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
        if (!wait)
        {
            StartCoroutine(GoHome());
        }
    }

    // Sends the player back to the hub with the treasure.
    IEnumerator GoHome()
    {
        wait = true;
        FindObjectOfType<PlayerMovementGravity>().enabled = false;
        FindObjectOfType<PlayerMovementGravity>().gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        FindObjectOfType<Success>().SendMessage("youWin");

        // Set the power ups from collecting treasures
        if (treasureName == "Apple")
        {
            // Increase max stamina
            PlayerPrefs.SetFloat("maxStamina", 200f);
            Debug.Log("Stamina increased");
        }
        else if (treasureName == "EpicTome")
        {
            // Lower exhaustion rate
            PlayerPrefs.SetFloat("exhaustionRate", 50f);
            Debug.Log("Exhaustion rate decreased");
        }
        else if (treasureName == "FinalCactus")
        {
            // Lower cooldown time for rotating
            PlayerPrefs.SetFloat("rotationCooldown", 1f);
            Debug.Log("Rotation cooldown decreased");
        }
        else if (treasureName == "SpecialSkull")
        {
            PlayerPrefs.SetInt("walkingSpeed", 2);
            Debug.Log("Walking speed increased");
        }

        if (FindObjectOfType<QuestManager>().GetQuest1().treasure == treasureName)
        {
            FindObjectOfType<QuestManager>().CompleteQuest1();
            Debug.Log("Quest 1 completed");
        } 
        else if (FindObjectOfType<QuestManager>().GetQuest2().treasure == treasureName)
        {
            FindObjectOfType<QuestManager>().CompleteQuest2();
            Debug.Log("Quest 2 completed");
        }

        yield return new WaitForSeconds(5f);
        wait = false;
        FindObjectOfType<PlayerMovementGravity>().enabled = true;
        SceneManager.LoadScene("Hub");
    }
}
