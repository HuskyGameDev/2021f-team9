using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGravity : MonoBehaviour
{
    public bool dimensionActive;
    public bool canTurn;

    private bool stopTURNING;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = false;
        canTurn = true;
        stopTURNING = true;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Swaps orientation
        if (Input.GetKey(KeyCode.R) && canTurn)
        {
            // uncomment these 2 lines of code only if you have a rigidbody attached to your player object
            body.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(Flip());
            StartCoroutine(Cooldown());
        }

        if (stopTURNING == false)
        {
            if (dimensionActive)
            {
                transform.Rotate(Vector3.up, 90f * Time.fixedDeltaTime / 0.5f);
            }
            else
            {
                transform.Rotate(Vector3.up, -90f * Time.fixedDeltaTime / 0.5f);
            }
        }
    }

    private IEnumerator Cooldown()
    {
        canTurn = false;
        yield return new WaitForSeconds(2f);
        canTurn = true;
    }

    private IEnumerator Flip()
    {
        if (dimensionActive)
        {
            dimensionActive = false;
        }
        else
        {
            dimensionActive = true;
        }
        FindObjectOfType<LightingCode>().SendMessage("DimensionEffect");
        this.GetComponent<PlayerMovementGravity>().enabled = false;
        stopTURNING = false;
        yield return new WaitForSeconds(0.5f);
        stopTURNING = true;
        // Check to see if rotation is correct
        if (dimensionActive && transform.eulerAngles.y != 90f)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (!dimensionActive && transform.eulerAngles.y != 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        this.GetComponent<PlayerMovementGravity>().enabled = true;
        body.constraints = RigidbodyConstraints.None;
    }
}
