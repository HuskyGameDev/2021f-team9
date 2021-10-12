using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGravity : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed;

    private bool dimension;
    Rotation rotation;
    public Sprite[] imageList;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rotation = player.GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change the speed of the player
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 10.0f;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            playerSpeed = 200.0f;
        }
        else
        {
            playerSpeed = 2.0f;
        }

        //Change the direction of the player sprite
        if (Input.GetKeyDown(KeyCode.D))
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = imageList[0];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = imageList[1];
        }

        groundedPlayer = controller.isGrounded;
        playerVelocity = this.GetComponent<Rigidbody>().velocity; // might have modified your code a little to get gravity working
        // uncomment these commented lines of code only if your player object has a rigidbody attached to it!!!!!
        if (groundedPlayer && playerVelocity.y < 0)
        {
            //playerVelocity.y = 0f;
            this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, 0f, this.GetComponent<Rigidbody>().velocity.z);
        }

        Vector3 move;

        //Fixes the keys to move the players in the correct dimension based on how they are turned
        dimension = rotation.dimensionActive;
        if (dimension)
        {
            move = new Vector3(Input.GetAxis("Vertical"), this.GetComponent<Rigidbody>().velocity.y, -Input.GetAxis("Horizontal"));
            //move = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
        }
        else
        {
            move = new Vector3(Input.GetAxis("Horizontal"), this.GetComponent<Rigidbody>().velocity.y, Input.GetAxis("Vertical"));
            //move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }

        //Move the player
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
