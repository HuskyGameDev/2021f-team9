using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* To set up player movement
 * 1. Make sure the player rotation is 0, 0, 0
 * 2. Put two sprites in the image list
 * 3. Tag the object as Player
 */
public class PlayerMovement : MonoBehaviour
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
            gameObject.GetComponent<SpriteRenderer>().sprite = imageList[0];
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = imageList[1];
        }
        
        groundedPlayer = controller.isGrounded;
        playerVelocity = this.GetComponent<Rigidbody>().velocity; // might have modified your code a little to get gravity working
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
        }
        else
        {
            move = new Vector3(Input.GetAxis("Horizontal"), this.GetComponent<Rigidbody>().velocity.y, Input.GetAxis("Vertical"));
        }
        
        //Move the player
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
