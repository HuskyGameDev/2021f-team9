using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool dimensionActive;
    private bool canTurn;

    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = false;
        canTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Swaps orientation
        if(Input.GetKey(KeyCode.R) && canTurn)
        {
            // uncomment these 2 lines of code only if you have a rigidbody attached to your player object
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(flip());
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

    private IEnumerator flip()
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
        this.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        canTurn = true;
        this.GetComponent<PlayerMovement>().enabled = true;
        //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
