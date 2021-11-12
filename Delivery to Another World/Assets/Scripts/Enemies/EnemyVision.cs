using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    private GameObject player;
    private bool canRaycast;
    private RaycastHit[] hit = new RaycastHit[5];
    private bool isSprinting;
    private EnemyMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        canRaycast = false;
        movement = GetComponent<EnemyMovement>();
        player = FindObjectOfType<PlayerMovementGravity>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        int layerMask2 = 1 << 8;
        layerMask |= layerMask2;
        float xDistToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        float zDistToPlayer = Mathf.Abs(player.transform.position.z - transform.position.z);
        isSprinting = FindObjectOfType<PlayerMovementGravity>().isSprinting;

        float[] xDirectionRay = new float[5];
        float[] zDirectionRay = new float[5];

        xDirectionRay[1] = 1f / Mathf.Sqrt(Mathf.Pow(2f, 2f));
        zDirectionRay[1] = 5f / Mathf.Sqrt(Mathf.Pow(5f, 2f));
        xDirectionRay[2] = -1f / Mathf.Sqrt(Mathf.Pow(-2f, 2f));
        zDirectionRay[2] = 5f / Mathf.Sqrt(Mathf.Pow(5f, 2f));
        xDirectionRay[3] = 0.5f / Mathf.Sqrt(Mathf.Pow(-2f, 2f));
        zDirectionRay[3] = 5f / Mathf.Sqrt(Mathf.Pow(5f, 2f));
        xDirectionRay[4] = -0.5f / Mathf.Sqrt(Mathf.Pow(-2f, 2f));
        zDirectionRay[4] = 5f / Mathf.Sqrt(Mathf.Pow(5f, 2f));

        Vector3[] ray = new Vector3[5];
        ray[1] = new Vector3(xDirectionRay[1], 0f, zDirectionRay[1]); // Far positive x
        ray[2] = new Vector3(xDirectionRay[2], 0f, zDirectionRay[2]); // Far negative x
        ray[3] = new Vector3(xDirectionRay[3], 0f, zDirectionRay[3]); // Middle positive x
        ray[4] = new Vector3(xDirectionRay[4], 0f, zDirectionRay[4]); // Middle negative x

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
            // Middle ray
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.forward, out hit[0], 5f, layerMask) && hit[0].collider.CompareTag("Player"))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.forward * hit[0].distance, Color.red);
                Debug.Log("Caught!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            // Far positive x ray
            else if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[1]), out hit[1], 3f, layerMask) && hit[1].collider.CompareTag("Player"))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[1]) * hit[1].distance, Color.red);
                Debug.Log("Caught!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            // Far negative x ray
            else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[2]), out hit[2], 3f, layerMask) && hit[2].collider.CompareTag("Player"))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[2]) * hit[2].distance, Color.red);
                Debug.Log("Caught!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            // Middle positive x ray
            else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[3]), out hit[3], 5f, layerMask) && hit[3].collider.CompareTag("Player"))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[3]) * hit[3].distance, Color.red);
                Debug.Log("Caught!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            // Middle negative x ray
            else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[4]), out hit[4], 5f, layerMask) && hit[4].collider.CompareTag("Player"))
            {
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[4]) * hit[4].distance, Color.red);
                Debug.Log("Caught!");
                // send message that you lost and send back to hub
                movement.enabled = false;
            }
            else
            {
                if (isSprinting || (xDistToPlayer < 1f && zDistToPlayer < 1f))
                {
                    transform.LookAt(player.transform);
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.forward * hit[0].distance, Color.red);
                    Debug.Log("Caught!");
                    // send message that you lost and send back to hub
                    movement.enabled = false;
                }
                else
                {
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.forward * 5f, Color.white); // Middle
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[1]) * 3f, Color.white); // Far positive x
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[2]) * 3f, Color.white); // Far negative x
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[3]) * 5f, Color.white); // Middle positive x
                    Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.55f, transform.position.z), transform.TransformDirection(ray[4]) * 5f, Color.white); // Middle negative x
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
