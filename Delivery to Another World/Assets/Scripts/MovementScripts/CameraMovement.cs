using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float movespeed;

    private bool isTouching;
    private Vector3 startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        isTouching = false;
        startingPoint = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching) //&& Mathf.Abs(Input.GetAxis("Vertical")) > 0f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + movespeed);
        }
        else if (!isTouching && transform.localPosition.z > startingPoint.z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - movespeed);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            isTouching = false;
        }
    }


}
