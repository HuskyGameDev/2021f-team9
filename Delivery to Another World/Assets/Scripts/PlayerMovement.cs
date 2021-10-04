using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed;

    private bool dimension;
    Rotation rotation;
    float y;
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
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move;

        //Fixes the keys to move the players in the correct dimension based on how they are turned
        dimension = rotation.dimensionActive;
        if (dimension)
        {
            move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            y = -90;
        }
        else
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            y = 0;
        }
        
        //Move the player
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
