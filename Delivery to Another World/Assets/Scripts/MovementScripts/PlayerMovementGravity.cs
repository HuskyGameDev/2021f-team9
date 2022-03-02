using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementGravity : MonoBehaviour
{
    public float maxStamina;
    public float exhaustionRate;
    public GameObject staminaUI;
    public GameObject staminaBar;
    public bool isSprinting;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed;
    private bool canSprint;
    private float stamina;
    private bool canRegenerate;
    private Slider staminaSlider;
    private bool dimension;
    private RotationGravity rotation;
    private bool direction;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            PlayerPrefs.SetFloat("maxStamina", maxStamina);
            PlayerPrefs.SetFloat("exhaustionRate", exhaustionRate);
        }

        if(PlayerPrefs.GetFloat("maxStamina") > maxStamina)
        {
            maxStamina = PlayerPrefs.GetFloat("maxStamina");
        }
        if(PlayerPrefs.GetFloat("exhaustionRate") > exhaustionRate)
        {
            exhaustionRate = PlayerPrefs.GetFloat("exhaustionRate");
        }

        controller = this.GetComponent<CharacterController>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rotation = player.GetComponent<RotationGravity>();
        stamina = maxStamina;
        canSprint = true;
        canRegenerate = true;
        staminaSlider = staminaUI.GetComponent<Slider>();
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
        isSprinting = false;
        direction = true;
    }

    // Controls stamina
    private void FixedUpdate()
    {
        if(stamina <= 0f && canRegenerate)
        {
            canSprint = false;
            staminaBar.GetComponent<Image>().color = Color.red;
            StartCoroutine(waitToRegenerate(1f));
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && canSprint && canRegenerate)
        {
            canRegenerate = false;
            StartCoroutine(waitToRegenerate(0.5f));
        }
        
        if(Input.GetKey(KeyCode.LeftShift) && (Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f) && stamina > 0f && canSprint)
        {
            staminaBar.GetComponent<Image>().enabled = true;
            stamina -= exhaustionRate * Time.deltaTime;
            isSprinting = true;
        }
        else if (stamina < maxStamina && canRegenerate)
        {
            stamina += exhaustionRate * Time.deltaTime/2;
        }

        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }

        if (stamina == maxStamina)
        {
            canSprint = true;
            staminaBar.GetComponent<Image>().color = Color.green;
            staminaBar.GetComponent<Image>().enabled = false;
        }

        staminaSlider.value = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        //Change the speed of the player
        if (Input.GetKey(KeyCode.LeftShift) && canSprint)
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
            isSprinting = false;
        }

        //Change the direction of the player sprite
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            direction = false;
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            direction = true;
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

        // Activate/deactivate player animations
        if(Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            GetComponent<Animator>().SetBool("direction", direction);
            GetComponent<Animator>().SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift) && canSprint)
            {
                GetComponent<Animator>().SetBool("isRunning", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("isRunning", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
            GetComponent<Animator>().SetBool("isWalking", false);
        }
    }

    IEnumerator waitToRegenerate(float wait)
    {
        canRegenerate = false;
        yield return new WaitForSeconds(wait);
        canRegenerate = true;
        stamina = Mathf.Abs(stamina);
    }
}
