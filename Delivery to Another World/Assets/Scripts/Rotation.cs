using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool dimensionActive;
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
            StartCoroutine(flip());
        }

        
    }

    private IEnumerator flip()
    {
        if (dimensionActive)
        {
            transform.Rotate(0, 90, 0);
            dimensionActive = false;
        }
        else
        {
            transform.Rotate(0, -90, 0);
            dimensionActive = true;
        }
        canTurn = false;
        yield return new WaitForSeconds(1f);
        canTurn = true;
    }
}
