using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public GameObject player;

    private bool canRaycast;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        canRaycast = false;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        if(player.transform.position.x - transform.position.x < 5f && player.transform.position.z - transform.position.z < 5f)
        {
            canRaycast = true;
        }
        else
        {
            canRaycast = false;
        }

        if (canRaycast)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 10f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);
                Debug.Log("Did Hit!");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
            }
        }
    }
}
