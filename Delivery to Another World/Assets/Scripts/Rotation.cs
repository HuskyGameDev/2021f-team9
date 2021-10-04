using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool dimensionActive;
    private bool canTurn;
    private float angleToRotate = 90f;
    private float timeToRotate = 0.5f;
    private float stepAngle;
    // Start is called before the first frame update
    void Start()
    {
        dimensionActive = false;
        canTurn = true;
        stepAngle = angleToRotate / (timeToRotate / 100f);
    }

    // Update is called once per frame
    void Update()
    {
        // Swaps orientation
        if(Input.GetKey(KeyCode.R) && canTurn)
        {
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
        yield return new WaitForSeconds(1f);
        canTurn = true;
    }
}
