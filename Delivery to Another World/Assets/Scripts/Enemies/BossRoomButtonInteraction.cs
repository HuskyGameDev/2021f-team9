using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomButtonInteraction : MonoBehaviour
{

    private GameObject player;
    public BossRoomButtons bossManager;
    public bool isRotated;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                bossManager.pressedNextButton();
                Destroy(gameObject); //Disabling the sprite renderer didn't work? Destroying does, idk
            }
        }
        if (isRotated)
        {
            if (!FindObjectOfType<RotationGravity>().dimensionActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (FindObjectOfType<RotationGravity>().dimensionActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            if (!FindObjectOfType<RotationGravity>().dimensionActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (FindObjectOfType<RotationGravity>().dimensionActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
