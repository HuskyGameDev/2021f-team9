using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    private GameObject player;
    private bool canRaycast;
    private RaycastHit hit;
    private bool isSprinting;
    private EnemyMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        canRaycast = false;
        movement = FindObjectOfType<EnemyMovement>();
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        float xDistToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        float zDistToPlayer = Mathf.Abs(player.transform.position.z - transform.position.z);
        isSprinting = FindObjectOfType<PlayerMovementGravity>().isSprinting;

        if (xDistToPlayer < 5f && zDistToPlayer < 5f)
        {
            canRaycast = true;
        }
        else
        {
            canRaycast = false;
        }

        if (canRaycast)
        {
            if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 10f, layerMask))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Did Hit!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            else
            {
                if (isSprinting)
                {
                    transform.LookAt(player.transform);
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    Debug.Log("Did Hit!");
                    // send message that you lost and send back to hub
                    movement.enabled = false;
                }
                else
                {
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                    movement.enabled = true;
                }
            }
        }
        else if (!movement.enabled)
        {
            movement.enabled = true;
        }
    }
}
