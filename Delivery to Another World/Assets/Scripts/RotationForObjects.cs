using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForObjects : MonoBehaviour
{
    public bool dimensionActive;
    private bool canTurn;
    //private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = false;
        canTurn = true;
        //body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Swaps orientation
        if (Input.GetKey(KeyCode.R) && canTurn)
        {
            // uncomment these 2 lines of code only if you have a rigidbody attached to your player object
            //body.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(Flip());
        }
    }

    void FixedUpdate()
    {
        if (canTurn == false)
        {
            if (dimensionActive)
            {
                transform.Rotate(Vector3.up, 90f * Time.fixedDeltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, -90f * Time.fixedDeltaTime);
            }
        }
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
        canTurn = false;
        //this.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        canTurn = true;
        //this.GetComponent<PlayerMovement>().enabled = true;
        //body.constraints = RigidbodyConstraints.None;
    }
}
