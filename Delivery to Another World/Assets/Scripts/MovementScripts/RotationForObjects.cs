using System.Collections;
using UnityEngine;

public class RotationForObjects : MonoBehaviour
{
    public bool dimensionActive;
    private bool canTurn;
    private RotationGravity rotGrav;

    //private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;
        canTurn = true;
        transform.rotation = FindObjectOfType<RotationGravity>().transform.rotation;
        rotGrav = FindObjectOfType<RotationGravity>();
        //body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Swaps orientation
        if (Input.GetKey(KeyCode.R) && canTurn && rotGrav.enabled)
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
                transform.Rotate(Vector3.up, 90f * Time.fixedDeltaTime / 0.5f);
            }
            else
            {
                transform.Rotate(Vector3.up, -90f * Time.fixedDeltaTime / 0.5f);
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
        yield return new WaitForSeconds(0.5f);
        canTurn = true;
        //this.GetComponent<PlayerMovement>().enabled = true;
        //body.constraints = RigidbodyConstraints.None;
    }
}
